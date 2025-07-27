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

using LiveCharts;
using LiveCharts.Wpf;

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

        public CrosstalkEvaluation(double steps)
        {
            InitializeComponent();

            // --- 輝度分布 ---
            // 輝度分布管理のためのオブジェクトを生成
            LuminanceChart.Series = new SeriesCollection();
            // 折れ線グラフ設定
            LineSeries lum = new LineSeries
            {
                Title = "輝度(0 - 255)",
                Values = realTimeValues,
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 6,
                StrokeThickness = 2,
                Fill = System.Windows.Media.Brushes.Transparent
            };
            // 折れ線グラフ追加
            LuminanceChart.Series.Add(lum);
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
                realTimeValues.Add(luminance);  // ★ LiveChartsに即追加（リアルタイム描画）

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
