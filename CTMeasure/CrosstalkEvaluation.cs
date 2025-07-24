using OpenCvSharp;
using Spinnaker;
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

namespace CTMeasure
{
    public partial class CrosstalkEvaluation : Form
    {
        public CameraManager CameraRef { get; set; }  // 親から渡されるカメラ管理クラスへの参照

        // ROI座標
        private Point[] Start_roiCorners = new Point[4];   // 開始地点
        private Point[] END_roiCorners = new Point[4];     // 終了地点
        private double dx = 0, dy = 0;                     // ROI重心間の距離

        public CrosstalkEvaluation()
        {
            InitializeComponent();
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
            }
        }

        // 開始地点ROIと終了地点ROIから補間されたROIを生成
        private Point[] GetInterpolatedROICorners(int i, int maxIndex)
        {
            Point[] interpolatedCorners = new Point[4];

            if (maxIndex <= 0)
            {
                // 補間不要の場合は開始座標をそのまま返す
                Array.Copy(Start_roiCorners, interpolatedCorners, 4);
                return interpolatedCorners;
            }

            double alpha = (i - 1.0) / (maxIndex - 1.0); // 線形補間係数

            for (int j = 0; j < 4; j++)
            {
                int x = (int)Math.Round(Start_roiCorners[j].X + (END_roiCorners[j].X - Start_roiCorners[j].X) * alpha);
                int y = (int)Math.Round(Start_roiCorners[j].Y + (END_roiCorners[j].Y - Start_roiCorners[j].Y) * alpha);
                interpolatedCorners[j] = new Point(x, y);
            }

            return interpolatedCorners;
        }
    }
}
