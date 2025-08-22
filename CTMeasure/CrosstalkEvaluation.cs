using OpenCvSharp;
using Spinnaker;
using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = OpenCvSharp.Point;

// LiveChart
using LiveCharts;
using LiveCharts.Wpf;

// pdfsharp
using PdfSharp;

using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using PdfSharp.Drawing;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace CTMeasure
{
    public partial class CrosstalkEvaluation : Form
    {
        public CameraManager CameraRef { get; set; }   // 親から渡されるカメラ管理クラスへの参照
        public StageController StageRef { get; set; }  // 親から渡されるステージ管理クラスへの参照

        private CalkCrossTalk ctr; // クロストーク比計算ライブラリ

        // TCP受信トリガー
        private TaskCompletionSource<string> responseTcs;

        // アイトラッキング機能ON/OFF
        bool EyeTrack = false;        

        // ROI座標
        private Point[] Start_roiCorners = new Point[4];   // 開始地点
        private Point[] END_roiCorners = new Point[4];     // 終了地点
        private double dx = 0, dy = 0;                     // ROI重心間の距離

        // ステージ分解能(1pulse = 0.004mm)
        private const float MoveResolution = 0.004f;

        // 輝度分布リスト
        List<double> luminanceList = new List<double>();
        // クロストーク比分布リスト
        List<double> CrosstalkList = new List<double>();
        // グラフタイトルをキーにした ChartValues 管理辞書
        private Dictionary<string, ChartValues<double>> dataSeriesDict_lum = new Dictionary<string, ChartValues<double>>();
        private Dictionary<string, ChartValues<double>> dataSeriesDict_ctr = new Dictionary<string, ChartValues<double>>();

        public CrosstalkEvaluation(double steps)
        {
            InitializeComponent();

            // --- 輝度分布 ---
            // 輝度分布管理のためのオブジェクトを生成
            LuminanceChart.Series = new SeriesCollection();
            // XY軸設定
            LuminanceChart.AxisX.Add(new Axis
            {
                Title = "Viewing position in horizontal direction (mm)",
                FontSize = 16,
                LabelFormatter = value => $"{value:F0}",
                MinValue = 0,
                MaxValue = steps,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Step = 5
                }
            });
            LuminanceChart.AxisY.Add(new Axis
            {
                Title = "Luminance (gray scale level)",
                FontSize = 16,
                LabelFormatter = value => $"{value:F2}",
                MinValue = 0,
                MaxValue = 255,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Step = 50
                }
            });
            // 凡例の位置を設定
            LuminanceChart.LegendLocation = LegendLocation.Right;
            // 拡大・縮小を許可
            LuminanceChart.Zoom = ZoomingOptions.Xy;

            // --- クロストーク比分布 ---
            // クロストーク比分布管理のためのオブジェクトを生成
            CrosstalkChart.Series = new SeriesCollection();
            // XY軸設定
            CrosstalkChart.AxisX.Add(new Axis
            {
                Title = "Viewing position in horizontal direction (mm)",
                FontSize = 16,
                LabelFormatter = value => $"{value:F0}",
                MinValue = 0,
                MaxValue = steps,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Step = 5
                }
            });
            CrosstalkChart.AxisY.Add(new Axis
            {
                Title = "Cross Talk Ratio (%)",
                FontSize = 16,
                LabelFormatter = value => $"{value:F2}",
                MinValue = 0,
                MaxValue = 100,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Step = 50
                }
            });
            // 凡例の位置を設定
            CrosstalkChart.LegendLocation = LegendLocation.Right;
            // 拡大・縮小を許可
            CrosstalkChart.Zoom = ZoomingOptions.Xy;

            ctr = new CalkCrossTalk();
        }

        // X軸値更新
        private void UpdateChartXAxis()
        {
            if (!int.TryParse(StepRange.Text, out int steps) || steps <= 0)
                return;

            LuminanceChart.AxisX[0].MinValue = 0;
            LuminanceChart.AxisX[0].MaxValue = steps;

            CrosstalkChart.AxisX[0].MinValue = 0;
            CrosstalkChart.AxisX[0].MaxValue = steps;
        }

        // ステージの移動範囲更新
        private void StepRange_TextChanged(object sender, EventArgs e)
        {
            UpdateChartXAxis();
        }

        // 開始地点のROI選択
        private void ROI_start_Click(object sender, EventArgs e)
        {
            if (CameraRef == null || CameraRef.LatestFrame == null || CameraRef.LatestFrame.Empty())
            {
                MessageBox.Show("カメラ画像が取得できません", "エラー");
                return;
            }

            Mat currentFrame = CameraRef.LatestFrame.Clone();

            // ROI選択
            Rect roi = Cv2.SelectROI("ROI選択", currentFrame);
            if (roi.Width == 0 || roi.Height == 0)
            {
                MessageBox.Show("有効なROIが選択されていません", "注意");
                return;
            }
            Cv2.DestroyWindow("ROI選択");

            // ROIの四隅を取得（必要なら別途保持）
            Start_roiCorners[0] = new Point(roi.X, roi.Y);                             // 左上
            Start_roiCorners[1] = new Point(roi.X + roi.Width, roi.Y);                // 右上
            Start_roiCorners[2] = new Point(roi.X + roi.Width, roi.Y + roi.Height);  // 右下
            Start_roiCorners[3] = new Point(roi.X, roi.Y + roi.Height);              // 左下

            // ★ ROI枠を描画してわかりやすく
            Cv2.Rectangle(currentFrame, roi, new Scalar(0, 0, 255), 2);  // 赤い枠

            // ★ 別ウィンドウで表示
            Cv2.ImShow("選択されたROI", currentFrame);
            Cv2.WaitKey(0);
            Cv2.DestroyWindow("選択されたROI");

            if (END_roiCorners != null)
            {
                (dx, dy) = CalculateROIAxisDifferences(Start_roiCorners, END_roiCorners);

                deltaROI_X.Text = dx.ToString();
                deltaROI_Y.Text = dy.ToString();
            }
        }

        // 終了地点のROI選択
        private void ROI_end_Click(object sender, EventArgs e)
        {
            if (CameraRef == null || CameraRef.LatestFrame == null || CameraRef.LatestFrame.Empty())
            {
                MessageBox.Show("カメラ画像が取得できません", "エラー");
                return;
            }

            Mat currentFrame = CameraRef.LatestFrame.Clone();

            // ROI選択
            Rect roi = Cv2.SelectROI("ROI選択", currentFrame);
            if (roi.Width == 0 || roi.Height == 0)
            {
                MessageBox.Show("有効なROIが選択されていません", "注意");
                return;
            }
            Cv2.DestroyWindow("ROI選択");

            // ROIの四隅を取得（必要なら別途保持）
            END_roiCorners[0] = new Point(roi.X, roi.Y);                             // 左上
            END_roiCorners[1] = new Point(roi.X + roi.Width, roi.Y);                // 右上
            END_roiCorners[2] = new Point(roi.X + roi.Width, roi.Y + roi.Height);  // 右下
            END_roiCorners[3] = new Point(roi.X, roi.Y + roi.Height);              // 左下

            // ★ ROI枠を描画してわかりやすく
            Cv2.Rectangle(currentFrame, roi, new Scalar(0, 0, 255), 2);  // 赤い枠

            // ★ 別ウィンドウで表示
            Cv2.ImShow("選択されたROI", currentFrame);
            Cv2.WaitKey(0);
            Cv2.DestroyWindow("選択されたROI");

            if (Start_roiCorners != null)
            {
                (dx, dy) = CalculateROIAxisDifferences(Start_roiCorners, END_roiCorners);

                deltaROI_X.Text = dx.ToString();
                deltaROI_Y.Text = dy.ToString();
            }
        }

        // 開始地点ROIと終了地点ROIから補間されたROIを生成
        private Point[] GetInterpolatedROICorners(int i, int maxIndex)
        {
            Point[] interpolated = new Point[4];

            if (maxIndex <= 0)
            {
                Array.Copy(Start_roiCorners, interpolated, 4);
                return interpolated;
            }

            double alpha = (i - 1.0) / (maxIndex - 1.0);  // 補間係数

            for (int j = 0; j < 4; j++)
            {
                int x = (int)Math.Round(Start_roiCorners[j].X + (END_roiCorners[j].X - Start_roiCorners[j].X) * alpha);
                int y = (int)Math.Round(Start_roiCorners[j].Y + (END_roiCorners[j].Y - Start_roiCorners[j].Y) * alpha);
                interpolated[j] = new Point(x, y);
            }

            return interpolated;
        }

        // 開始地点ROIと終了地点ROI間の平均距離取得
        private (double dx, double dy) CalculateROIAxisDifferences(Point[] start, Point[] end)
        {
            if (start == null || end == null || start.Length != 4 || end.Length != 4)
                throw new ArgumentException("ROIは4点である必要があります");

            double sum_dx = 0.0;
            double sum_dy = 0.0;

            for (int i = 0; i < 4; i++)
            {
                sum_dx += end[i].X - start[i].X;
                sum_dy += end[i].Y - start[i].Y;
            }

            return (sum_dx / 4, sum_dy / 4);
        }


        // ---------- 輝度測定 ----------
        // 輝度分布測定
        private async void Luminance_Start_Click(object sender, EventArgs e)
        {
            if (StageRef == null || !StageRef.IsConnected)
            {
                MessageBox.Show("ステージが接続されていません", "エラー");
                return;
            }

            if (CameraRef == null || CameraRef.LatestFrame == null)
            {
                MessageBox.Show("カメラ画像が取得できません", "エラー");
                return;
            }

            if (Start_roiCorners == null || END_roiCorners == null)
            {
                MessageBox.Show("開始・終了のROIを設定してください", "エラー");
                return;
            }

            //  --- 測定前に対象 Series を取得 ---
            string selectedSeries = LumSeriesNameComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedSeries) || !dataSeriesDict_lum.ContainsKey(selectedSeries))
            {
                MessageBox.Show("追加した凡例名を選択してください", "エラー");
                return;
            }
            var targetSeries = dataSeriesDict_lum[selectedSeries];
            targetSeries.Clear(); // 測定前にクリア

            int steps = int.Parse(StepRange.Text); // 移動距離

            luminanceList.Clear();

            for (int i = 0; i < steps; i++)
            {
                // --- 測定処理（ROI抽出 → 輝度計算） ---
                Point[] roiCorners = GetInterpolatedROICorners(i, steps);

                int minX = roiCorners.Min(p => p.X);
                int minY = roiCorners.Min(p => p.Y);
                int maxX = roiCorners.Max(p => p.X);
                int maxY = roiCorners.Max(p => p.Y);
                Rect roi = new Rect(minX, minY, maxX - minX, maxY - minY);

                Mat frame = CameraRef.LatestFrame.Clone();
                Mat roiMat = new Mat(frame, roi);

                Cv2.ImShow("InterpolatedROI", roiMat);

                Mat gray = new Mat();
                Cv2.CvtColor(roiMat, gray, ColorConversionCodes.BGR2GRAY);
                Scalar mean = Cv2.Mean(gray);
                double luminance = mean.Val0;

                // === プロット更新 ===
                luminanceList.Add(luminance);
                targetSeries.Add(luminance);  // ★ LiveChartsに即追加（リアルタイム描画）

                Console.WriteLine($"Step {i}: Luminance = {luminance:F2}");

                // ステージを1mm動かす
                StageRef.SendCommand($"MGO:A+{1.0f / MoveResolution}");
                await Task.Delay(1000);
                StageRef.SendCommand("STOP");
            }

            // 移動前に戻る
            StageRef.SendCommand($"MGO:A-{steps / MoveResolution}");
            StageRef.SendCommand("STOP");

            MessageBox.Show("輝度測定完了", "完了");
        }
        // 輝度グラフ追加ダイアログ表示
        private void AddGraph_lum_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddSeriesForm())  
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var values = new ChartValues<double>();
                    dataSeriesDict_lum[dlg.SeriesName] = values;

                    var series = new LineSeries
                    {
                        Title = dlg.SeriesName,
                        Values = values,
                        Stroke = dlg.SelectedColor,
                        StrokeDashArray = dlg.SelectedLineStyle.Dashes,
                        StrokeThickness = 2,
                        PointGeometry = DefaultGeometries.Circle,
                        PointGeometrySize = 6,
                        Fill = Brushes.Transparent
                    };

                    LuminanceChart.Series.Add(series);
                    LumSeriesNameComboBox.Items.Add(dlg.SeriesName);
                }
            }
        }
        // グラフ保存
        private void Luminance_Save_Click(object sender, EventArgs e)
        {
            if (luminanceList == null || luminanceList.Count == 0)
            {
                MessageBox.Show("保存する測定データがありません。", "エラー");
                return;
            }

            using (var dlg = new SaveForm())
            {
                var result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    SaveCSV();
                }
                else if (result == DialogResult.No)
                {
                    SavePDF();
                }
                // DialogResult.Cancel → 何もしない
            }
        }
        // CSV保存
        private void SaveCSV()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "CSVとして保存";
                saveDialog.Filter = "CSVファイル (*.csv)|*.csv";
                saveDialog.FileName = "luminance_multi_series.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                        {
                            // ヘッダー行を出力
                            var headers = new List<string> { "Step(mm)" };
                            headers.AddRange(dataSeriesDict_lum.Keys);
                            writer.WriteLine(string.Join(",", headers));

                            // 最大ステップ数を決定（系列ごとに数が異なる可能性があるため）
                            int maxSteps = dataSeriesDict_lum.Values.Max(series => series.Count);

                            // データ行を出力
                            for (int i = 0; i < maxSteps; i++)
                            {
                                var row = new List<string> { (i * 1.0).ToString("F0") }; // Step(mm)

                                foreach (var series in dataSeriesDict_lum.Values)
                                {
                                    if (i < series.Count)
                                        row.Add(series[i].ToString("F2"));
                                    else
                                        row.Add(""); // 欠損データは空欄に
                                }

                                writer.WriteLine(string.Join(",", row));
                            }
                        }

                        MessageBox.Show("CSVファイルとして保存しました。", "保存完了");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CSV保存中にエラーが発生しました: " + ex.Message, "エラー");
                    }
                }
            }
        }
        // PDF保存
        private void SavePDF()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "PDFとして保存";
                saveDialog.Filter = "PDFファイル (*.pdf)|*.pdf";
                saveDialog.FileName = "luminance_chart.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 1. グラフをBitmapに描画
                        Bitmap bmp = new Bitmap(LuminanceChart.Width, LuminanceChart.Height);
                        LuminanceChart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                        // 2. PDFドキュメント作成
                        var document = new PdfSharp.Pdf.PdfDocument();
                        var page = document.AddPage();
                        page.Size = PdfSharp.PageSize.A4;
                        page.Orientation = PdfSharp.PageOrientation.Landscape;

                        // 3. 描画用グラフィックス取得
                        var gfx = XGraphics.FromPdfPage(page);

                        // 4. Bitmap → XImage に変換
                        using (var stream = new MemoryStream())
                        {
                            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            stream.Position = 0;

                            XImage img = XImage.FromStream(stream);

                            // 5. 画像を中央に配置して描画（スケーリング調整可）
                            double x = (page.Width - img.PixelWidth * 72 / img.HorizontalResolution) / 2;
                            double y = (page.Height - img.PixelHeight * 72 / img.VerticalResolution) / 2;

                            gfx.DrawImage(img, x, y,
                                img.PixelWidth * 72 / img.HorizontalResolution,
                                img.PixelHeight * 72 / img.VerticalResolution);
                        }

                        // 6. 保存
                        document.Save(saveDialog.FileName);
                        MessageBox.Show("PDFファイルとして保存しました。", "保存完了");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PDF保存中にエラーが発生しました: " + ex.Message, "エラー");
                    }
                }
            }
        }

        // ---------- クロストーク比測定 ----------
        // クロストーク比分布測定
        private async void Crosstalk_Start_Click(object sender, EventArgs e)
        {
            if (StageRef == null || !StageRef.IsConnected)
            {
                MessageBox.Show("ステージが接続されていません", "エラー");
                return;
            }

            if (CameraRef == null || CameraRef.LatestFrame == null)
            {
                MessageBox.Show("カメラ画像が取得できません", "エラー");
                return;
            }

            if (Start_roiCorners == null || END_roiCorners == null)
            {
                MessageBox.Show("開始・終了のROIを設定してください", "エラー");
                return;
            }

            //  --- 測定前に対象 Series を取得 ---
            string selectedSeries = CtrSeriesNameComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedSeries) || !dataSeriesDict_ctr.ContainsKey(selectedSeries))
            {
                MessageBox.Show("追加した凡例名を選択してください", "エラー");
                return;
            }
            var targetSeries = dataSeriesDict_ctr[selectedSeries];
            targetSeries.Clear(); // 測定前にクリア

            int steps = int.Parse(StepRange.Text); // 移動距離

            CrosstalkList.Clear();

            for (int i = 0; i < steps; i++)
            {
                // 初期化
                Mat frame = new Mat();
                Mat black = new Mat();
                Mat white = new Mat();
                Mat bw = new Mat();

                // --- 測定処理（ROI抽出） ---
                Point[] roiCorners = GetInterpolatedROICorners(i, steps);

                int minX = roiCorners.Min(p => p.X);
                int minY = roiCorners.Min(p => p.Y);
                int maxX = roiCorners.Max(p => p.X);
                int maxY = roiCorners.Max(p => p.Y);
                Rect roi = new Rect(minX, minY, maxX - minX, maxY - minY);

                // --- TCP通信 ---
                // 黒画像リクエスト
                if (CrossTalkMeasure.lastClient != null)
                {
                    responseTcs = new TaskCompletionSource<string>();

                    string message = $"b";
                    CrossTalkMeasure.lastClient.ReplyLine(message);  // Unityに指令
                    Console.WriteLine($"送信: {message}");

                    if (await Task.WhenAny(responseTcs.Task, Task.Delay(10000)) == responseTcs.Task)
                    {
                        string reply = responseTcs.Task.Result;
                        Console.WriteLine($"Unityから返信: {reply}");

                        if (reply != "OK")
                        {
                            MessageBox.Show("Unityから想定外の返信が返されました", "警告");
                            return;
                        }
                        else
                        {
                            await Task.Delay(3000);  // 映像が更新されるまで待機
                            frame = CameraRef.LatestFrame.Clone();
                            Cv2.ImShow("InterpolatedROI", frame);
                            Cv2.CvtColor(frame, black, ColorConversionCodes.BGR2GRAY);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unityからの返信がタイムアウトしました", "エラー");
                        return;
                    }
                }
                // 白画像リクエスト
                if (CrossTalkMeasure.lastClient != null)
                {
                    responseTcs = new TaskCompletionSource<string>();

                    string message = $"w";
                    CrossTalkMeasure.lastClient.ReplyLine(message);  // Unityに指令
                    Console.WriteLine($"送信: {message}");

                    if (await Task.WhenAny(responseTcs.Task, Task.Delay(10000)) == responseTcs.Task)
                    {
                        string reply = responseTcs.Task.Result;
                        Console.WriteLine($"Unityから返信: {reply}");

                        if (reply != "OK")
                        {
                            MessageBox.Show("Unityから想定外の返信が返されました", "警告");
                            return;
                        }
                        else
                        {
                            await Task.Delay(3000);
                            frame = CameraRef.LatestFrame.Clone();
                            Cv2.ImShow("InterpolatedROI", frame);
                            Cv2.CvtColor(frame, white, ColorConversionCodes.BGR2GRAY);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unityからの返信がタイムアウトしました", "エラー");
                        return;
                    }
                }

                // --- 黒白 or 白黒 映像判断 ---
                // 黒白画像リクエスト
                if (LTex_ComboBox.SelectedItem?.ToString() == "黒" && RTex_ComboBox.SelectedItem?.ToString() == "白")
                {
                    if (CrossTalkMeasure.lastClient != null)
                    {
                        responseTcs = new TaskCompletionSource<string>();

                        string message = $"bw";
                        CrossTalkMeasure.lastClient.ReplyLine(message);  // Unityに指令
                        Console.WriteLine($"送信: {message}");

                        if (await Task.WhenAny(responseTcs.Task, Task.Delay(10000)) == responseTcs.Task)
                        {
                            string reply = responseTcs.Task.Result;
                            Console.WriteLine($"Unityから返信: {reply}");

                            if (reply != "OK")
                            {
                                MessageBox.Show("Unityから想定外の返信が返されました", "警告");
                                return;
                            }
                            else
                            {
                                await Task.Delay(3000);
                                frame = CameraRef.LatestFrame.Clone();
                                Cv2.ImShow("InterpolatedROI", frame);
                                Cv2.CvtColor(frame, bw, ColorConversionCodes.BGR2GRAY);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unityからの返信がタイムアウトしました", "エラー");
                            return;
                        }
                    }
                }
                // 白黒画像リクエスト
                if (LTex_ComboBox.SelectedItem?.ToString() == "白" && RTex_ComboBox.SelectedItem?.ToString() == "黒")
                {
                    if (CrossTalkMeasure.lastClient != null)
                    {
                        responseTcs = new TaskCompletionSource<string>();

                        string message = $"wb";
                        CrossTalkMeasure.lastClient.ReplyLine(message);  // Unityに指令
                        Console.WriteLine($"送信: {message}");

                        if (await Task.WhenAny(responseTcs.Task, Task.Delay(10000)) == responseTcs.Task)
                        {
                            string reply = responseTcs.Task.Result;
                            Console.WriteLine($"Unityから返信: {reply}");

                            if (reply != "OK")
                            {
                                MessageBox.Show("Unityから想定外の返信が返されました", "警告");
                                return;
                            }
                            else
                            {
                                await Task.Delay(3000);
                                frame = CameraRef.LatestFrame.Clone();
                                Cv2.ImShow("InterpolatedROI", frame);
                                Cv2.CvtColor(frame, bw, ColorConversionCodes.BGR2GRAY);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unityからの返信がタイムアウトしました", "エラー");
                            return;
                        }
                    }
                }

                // === クロストーク計算 ===
                var results = ctr.calcCTR(roi, black, white, bw);

                // === プロット更新 ===
                CrosstalkList.Add(results.ctr);
                targetSeries.Add(results.ctr);  // ★ LiveChartsに即追加（リアルタイム描画）

                // ステージを1mm動かす
                StageRef.SendCommand($"MGO:A+{1.0f / MoveResolution}");

                // ステージの移動をUnityに通知(EyeTrack == falseなら無視)
                if (EyeTrack)
                {
                    string message = $"EyeTracking";
                    CrossTalkMeasure.lastClient.ReplyLine(message);  // Unityに指令
                    Console.WriteLine($"送信: {message}");

                    if (await Task.WhenAny(responseTcs.Task, Task.Delay(10000)) == responseTcs.Task)
                    {
                        string reply = responseTcs.Task.Result;
                        Console.WriteLine($"Unityから返信: {reply}");

                        if (reply != "OK")
                        {
                            MessageBox.Show("Unityから想定外の返信が返されました", "警告");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unityからの返信がタイムアウトしました", "エラー");
                        return;
                    }
                }

                await Task.Delay(1000);
                StageRef.SendCommand("STOP");
            }

            // 移動前に戻る
            StageRef.SendCommand($"MGO:A-{steps / MoveResolution}");
            StageRef.SendCommand("STOP");

            MessageBox.Show("クロストーク比測定完了", "完了");
        }
        // クロストーク比グラフ追加ダイアログ表示
        private void AddGraph_ctr_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddSeriesForm())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var values = new ChartValues<double>();
                    dataSeriesDict_ctr[dlg.SeriesName] = values;

                    var series = new LineSeries
                    {
                        Title = dlg.SeriesName,
                        Values = values,
                        Stroke = dlg.SelectedColor,
                        StrokeDashArray = dlg.SelectedLineStyle.Dashes,
                        StrokeThickness = 2,
                        PointGeometry = DefaultGeometries.Circle,
                        PointGeometrySize = 6,
                        Fill = Brushes.Transparent
                    };

                    CrosstalkChart.Series.Add(series);
                    CtrSeriesNameComboBox.Items.Add(dlg.SeriesName);
                }
            }
        }
        // TCP受信確認
        public void SetTCPReply(string reply)
        {
            if (responseTcs != null && !responseTcs.Task.IsCompleted)
            {
                responseTcs.SetResult(reply);
            }
        }
        // グラフ保存
        private void Crosstalk_Save_Click(object sender, EventArgs e)
        {
            if (CrosstalkList == null || CrosstalkList.Count == 0)
            {
                MessageBox.Show("保存する測定データがありません。", "エラー");
                return;
            }

            using (var dlg = new SaveForm())
            {
                var result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    SaveCSV_ctr();
                }
                else if (result == DialogResult.No)
                {
                    SavePDF_ctr();
                }
                // DialogResult.Cancel → 何もしない
            }
        }
        // CSV保存
        private void SaveCSV_ctr()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "CSVとして保存";
                saveDialog.Filter = "CSVファイル (*.csv)|*.csv";
                saveDialog.FileName = "crosstalkmulti_series.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                        {
                            // ヘッダー行を出力
                            var headers = new List<string> { "Step(mm)" };
                            headers.AddRange(dataSeriesDict_ctr.Keys);
                            writer.WriteLine(string.Join(",", headers));

                            // 最大ステップ数を決定（系列ごとに数が異なる可能性があるため）
                            int maxSteps = dataSeriesDict_ctr.Values.Max(series => series.Count);

                            // データ行を出力
                            for (int i = 0; i < maxSteps; i++)
                            {
                                var row = new List<string> { (i * 1.0).ToString("F0") }; // Step(mm)

                                foreach (var series in dataSeriesDict_ctr.Values)
                                {
                                    if (i < series.Count)
                                        row.Add(series[i].ToString("F2"));
                                    else
                                        row.Add(""); // 欠損データは空欄に
                                }

                                writer.WriteLine(string.Join(",", row));
                            }
                        }

                        MessageBox.Show("CSVファイルとして保存しました。", "保存完了");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CSV保存中にエラーが発生しました: " + ex.Message, "エラー");
                    }
                }
            }
        }
        // PDF保存
        private void SavePDF_ctr()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "PDFとして保存";
                saveDialog.Filter = "PDFファイル (*.pdf)|*.pdf";
                saveDialog.FileName = "crosstalk_chart.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 1. グラフをBitmapに描画
                        Bitmap bmp = new Bitmap(CrosstalkChart.Width, CrosstalkChart.Height);
                        CrosstalkChart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                        // 2. PDFドキュメント作成
                        var document = new PdfSharp.Pdf.PdfDocument();
                        var page = document.AddPage();
                        page.Size = PdfSharp.PageSize.A4;
                        page.Orientation = PdfSharp.PageOrientation.Landscape;

                        // 3. 描画用グラフィックス取得
                        var gfx = XGraphics.FromPdfPage(page);

                        // 4. Bitmap → XImage に変換
                        using (var stream = new MemoryStream())
                        {
                            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            stream.Position = 0;

                            XImage img = XImage.FromStream(stream);

                            // 5. 画像を中央に配置して描画（スケーリング調整可）
                            double x = (page.Width - img.PixelWidth * 72 / img.HorizontalResolution) / 2;
                            double y = (page.Height - img.PixelHeight * 72 / img.VerticalResolution) / 2;

                            gfx.DrawImage(img, x, y,
                                img.PixelWidth * 72 / img.HorizontalResolution,
                                img.PixelHeight * 72 / img.VerticalResolution);
                        }

                        // 6. 保存
                        document.Save(saveDialog.FileName);
                        MessageBox.Show("PDFファイルとして保存しました。", "保存完了");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PDF保存中にエラーが発生しました: " + ex.Message, "エラー");
                    }
                }
            }
        }

        // Eyetracking 測定機能ON/OFF
        private void Eyetracking_Click(object sender, EventArgs e)
        {
            if (EyeTrack == false)
            {
                EyeTrack = true;
                Eyetracking.BackgroundImage = Properties.Resources.EyetrackingOFF;
            }
            else
            {
                EyeTrack = false;
                Eyetracking.BackgroundImage = Properties.Resources.EyetrackingON;
            }
        }
    }
}
