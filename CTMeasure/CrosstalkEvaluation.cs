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

namespace CTMeasure
{
    public partial class CrosstalkEvaluation : Form
    {
        public CameraManager CameraRef { get; set; }   // 親から渡されるカメラ管理クラスへの参照
        public StageController StageRef { get; set; }  // 親から渡されるステージ管理クラスへの参照

        // ROI座標
        private Point[] Start_roiCorners = new Point[4];   // 開始地点
        private Point[] END_roiCorners = new Point[4];     // 終了地点
        private double dx = 0, dy = 0;                     // ROI重心間の距離

        // ステージ分解能(1pulse = 0.004mm)
        private const float MoveResolution = 0.004f;

        // 輝度分布リスト
        List<double> luminanceList = new List<double>();
        private ChartValues<double> realTimeValues = new ChartValues<double>();
        // グラフタイトルをキーにした ChartValues 管理辞書
        private Dictionary<string, ChartValues<double>> dataSeriesDict = new Dictionary<string, ChartValues<double>>();

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
        }

        // X軸値更新
        private void UpdateChartXAxis()
        {
            if (!int.TryParse(StepRange.Text, out int steps) || steps <= 0)
                return;

            LuminanceChart.AxisX[0].MinValue = 0;
            LuminanceChart.AxisX[0].MaxValue = steps;
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

        // グラフ追加ダイアログ表示
        private void AddGraph_lum_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddSeriesForm())  
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var values = new ChartValues<double>();
                    dataSeriesDict[dlg.SeriesName] = values;

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
                    SeriesNameComboBox.Items.Add(dlg.SeriesName);
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
            var saveDlg = new SaveFileDialog
            {
                Title = "CSVとして保存",
                Filter = "CSVファイル (*.csv)|*.csv",
                FileName = "LuminanceData.csv"
            };

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveDlg.FileName, false, Encoding.UTF8))
                {
                    writer.WriteLine("Step,Luminance");
                    for (int i = 0; i < luminanceList.Count; i++)
                        writer.WriteLine($"{i},{luminanceList[i]:F2}");
                }

                MessageBox.Show("CSV保存完了", "保存");
            }
        }

        private Bitmap CaptureChartImage()
        {
            Bitmap bmp = new Bitmap(LuminanceChart.Width, LuminanceChart.Height);
            LuminanceChart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }

        // PDF保存
        private void SavePDF()
        {
            var saveDlg = new SaveFileDialog
            {
                Title = "PDFとして保存",
                Filter = "PDFファイル (*.pdf)|*.pdf",
                FileName = "LuminanceReport.pdf"
            };

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                var doc = new PdfSharp.Pdf.PdfDocument();
                var page = doc.AddPage();
                page.Size = PdfSharp.PageSize.A4;

                using (var gfx = XGraphics.FromPdfPage(page))
                {
                    // タイトル文字列
                    var titleFont = new XFont("Arial", 16);
                    gfx.DrawString("Luminance Report", titleFont, XBrushes.Black,
                        new XRect(0, 20, page.Width, 40), XStringFormats.TopCenter);

                    // === グラフ画像の挿入 ===
                    Bitmap chartBmp = CaptureChartImage();
                    using (var ms = new MemoryStream())
                    {
                        chartBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.Seek(0, SeekOrigin.Begin);

                        XImage chartImg = XImage.FromStream(ms);

                        double imgWidth = page.Width - 100;
                        double imgHeight = chartImg.PixelHeight * imgWidth / chartImg.PixelWidth;

                        gfx.DrawImage(chartImg, 50, 70, imgWidth, imgHeight); // 余白をつけて描画
                    }

                    // === 測定値も簡易的に出力（任意） ===
                    var font = new XFont("Arial", 10);
                    double y = 80 + 300; // グラフの下に配置
                    for (int i = 0; i < luminanceList.Count && y < page.Height - 50; i++)
                    {
                        gfx.DrawString($"Step {i}: {luminanceList[i]:F2}",
                            font, XBrushes.Black, new XRect(60, y, 500, 20), XStringFormats.TopLeft);
                        y += 15;
                    }
                }

                doc.Save(saveDlg.FileName);
                MessageBox.Show("PDF保存完了", "保存");
            }
        }

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
            string selectedSeries = SeriesNameComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedSeries) || !dataSeriesDict.ContainsKey(selectedSeries))
            {
                MessageBox.Show("追加した凡例名を選択してください", "エラー");
                return;
            }
            var targetSeries = dataSeriesDict[selectedSeries];
            targetSeries.Clear(); // 測定前にクリア

            int steps = int.Parse(StepRange.Text); // 移動距離

            luminanceList.Clear();
            realTimeValues.Clear();  // ★リセット

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
            
            // 必要なら CSV 保存も可（オプション）
            // SaveLuminanceToCSV(luminanceList);
        }
    }
}
