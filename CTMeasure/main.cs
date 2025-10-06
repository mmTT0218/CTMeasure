using System;
using System.Drawing;                       // Bitmap or Color imaging
using System.IO;
using System.Windows.Forms;                 // Windows Form Application Component
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SimpleTCP;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace CTMeasure
{
    public partial class CrossTalkMeasure : Form
    {
        // Library import
        private CameraManager camera;
        private StageController stage;
        private CalkCrossTalk ctr;
        private SimpleTcpServer simpleServer;

        public CrossTalkMeasure()
        {
            InitializeComponent();
        }

        // Initialize
        private void CrossTalkMeasure_Load(object sender, EventArgs e)
        {
            // CameraManager
            camera = new CameraManager(StreamImage);
            camera.OnImageCaptured += mat => {
                originalBitmap?.Dispose();
                originalBitmap = BitmapConverter.ToBitmap(mat);
                StreamImage.Invalidate();
            };
            camera.OnPoseUpdated += pose =>
            {
                //Camera_X.Text = $"X : {pose.X:F3} mm";
                //Camera_Y.Text = $"Y : {pose.Y:F3} mm";
                //Camera_Z.Text = $"Z : {pose.Z:F3} mm";
                //Camera_Yaw.Text = $"Yaw : {pose.Yaw:F3}°";
                //Camera_Pitch.Text = $"Pitch : {pose.Pitch:F3}°";
                //Camera_Roll.Text = $"Roll : {pose.Roll:F3}°";
            };
            camera.OnError += msg => MessageBox.Show(msg);
            // StageController
            stage = new StageController();
            stage.OnStatusChanged += (status) =>
            {
                // UI反映
                if (status == "connected")
                {
                    ConnectButton.BackgroundImage = Properties.Resources.ConnectOFF;
                }
                else
                {
                    ConnectButton.BackgroundImage = Properties.Resources.ConnectON;
                }
            };
            // CalkCrossTalk
            ctr = new CalkCrossTalk();
        }

        // -------------------------------------  Camera Controll Method (Spinnaker) -------------------------------------
        // Spinnaker Camera
        private bool cap = false;              // Cap Start/Stop Flag
        private Bitmap originalBitmap = null;  // capture image
        private float zoomFactor = 0.5f;       // zoom scale

        // Cap Start/Stop
        private void CapButton_Click(object sender, EventArgs e)
        {
            // Cap Start
            if (!cap)
            {
                camera.StartCamera();
                cap = true;
                this.CapButton.BackgroundImage = Properties.Resources.StreamOFF;
            }
            // Cap Stop
            else
            {
                camera.StopCamera();
                cap = false;
                this.CapButton.BackgroundImage = Properties.Resources.StreamON;
            }
        }

        // Photo Shot
        private void PhotoButton_Click(object sender, EventArgs e)
        {
            camera.SaveImage();
        }

        // Image Shrink
        private void ShrinkButton_Click(object sender, EventArgs e)
        {
            zoomFactor = Math.Max(0.5f, zoomFactor - 0.1f);
            StreamImage.Invalidate(); // call StreamImage_Paint
        }

        // Image Enlarge
        private void EnlargeButton_Click(object sender, EventArgs e)
        {
            zoomFactor = Math.Min(100.0f, zoomFactor + 0.1f);
            StreamImage.Invalidate(); // call StreamImage_Paint
        }

        // Paint method
        private void StreamImage_Paint(object sender, PaintEventArgs e)
        {

            if (originalBitmap == null) return;   // originImage check

            // size change
            int newWidth = (int)(originalBitmap.Width * zoomFactor);
            int newHeight = (int)(originalBitmap.Height * zoomFactor);

            // align center
            int x = (StreamImage.Width - newWidth) / 2;
            int y = (StreamImage.Height - newHeight) / 2;

            // Draw
            e.Graphics.Clear(StreamImage.BackColor);  // Clear
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // Interpolatopn
            e.Graphics.DrawImage(originalBitmap, new Rectangle(x, y, newWidth, newHeight)); // Draw center position
        }
        // --------------------------------------------------------------------------------------------------

        // -------------------------------------  Stage Controll Method -------------------------------------        // Connect/DisConnect Stage
        private void Connect_Stage_Click(object sender, EventArgs e)
        {
            if (!stage.IsConnected)
                stage.Connect();
            else
                stage.Disconnect();
        }

        // UP
        private void Stage_Up_MouseDown(object sender, MouseEventArgs e)
        {
            float value = float.Parse(YAxis_Value.Text);
            stage.StartMove("B", value, true);
            Up.BackColor = Color.Red;
        }

        private void Stage_Up_MouseUp(object sender, MouseEventArgs e)
        {
            stage.StopMove();
            Up.BackColor = Color.Lime;
        }

        // DOWN
        private void Stage_Down_MouseDown(object sender, MouseEventArgs e)
        {
            float value = float.Parse(YAxis_Value.Text);
            stage.StartMove("B", value, false);
            Down.BackColor = Color.Red;
        }

        private void Stage_Down_MouseUp(object sender, MouseEventArgs e)
        {
            stage.StopMove();
            Down.BackColor = Color.Lime;
        }

        // LEFT
        private void Stage_Left_MouseDown(object sender, MouseEventArgs e)
        {
            float value = float.Parse(XAxis_Value.Text);
            stage.StartMove("A", value, true);
            Left.BackColor = Color.Red;
        }

        private void Stage_Left_MouseUp(object sender, MouseEventArgs e)
        {
            stage.StopMove();
            Left.BackColor = Color.Lime;
        }

        // RIGHT
        private void Stage_Right_MouseDown(object sender, MouseEventArgs e)
        {
            float value = float.Parse(XAxis_Value.Text);
            stage.StartMove("A", value, false);
            Right.BackColor = Color.Red;
        }

        private void Stage_Right_MouseUp(object sender, MouseEventArgs e)
        {
            stage.StopMove();
            Right.BackColor = Color.Lime;
        }

        // --------------------------------------------------------------------------------------------------

        // -------------------------------------   Camera Calibration Method -------------------------------------
        // detect pattern
        List<Point2f[]> imagePointsList = new List<Point2f[]>();
        List<Point3f[]> objectPointsList = new List<Point3f[]>();
        private int detectPattenSet = 40;
        // stage controll
        private CancellationTokenSource stageIterationCTS = null;
        private bool isIteration = false;   // Iteration flag
        private const int MaxRight = 20;    // Max Roght Pos
        private const int MaxLeft = -20;    // Max Left Pos

        // Pattern ON/OFF Button
        private void TogglePattern(object sender, EventArgs e)
        {
            // カメラ接続確認
            if (!cap)
            {
                MessageBox.Show("カメラが接続されていません。", "注意");
                return;
            }

            // 状態反転
            camera.pattern = !camera.pattern;

            // ボタンの見た目を切り替え
            if (camera.pattern)
            {
                PatternDetect.BackgroundImage = Properties.Resources.PatternOFF;
            }
            else
            {
                PatternDetect.BackgroundImage = Properties.Resources.PatternON;
            }
        }

        // detectPattenSet change
        private void MaxDetectPatternChanged(object sender, EventArgs e)
        {
            detectPattenSet = int.Parse(MaxDetectSet.Text);
        }

        // 使いまわす3Dパターン
        private Point3f[] objectPoints = null;

        // Calibration data Collect Start
        private void Calibration(object sender, EventArgs e)
        {
            // chack stage & camera connect
            if (!stage.IsConnected || !cap)
            {
                MessageBox.Show("ステージまたはカメラが接続されていません。", "注意");
                return;
            }

            // PointList Initialize
            imagePointsList = new List<Point2f[]>();    // All Pattern Detect Point on Image 2D Coordinate
            objectPointsList = new List<Point3f[]>();   // True Pattern on 3D Coordinate

            // 初回のみ3D点を生成
            if (objectPoints == null)
                objectPoints = camera.Generate3DPatternPoints();   // True Pattern on 3D Coordinate

            // ProgressBar Initialize
            CalibrationProgress.Minimum = 0;
            CalibrationProgress.Maximum = detectPattenSet;
            CalibrationProgress.Value = 0;

            // iteration move start
            if (!isIteration)
            {
                stageIterationCTS = new CancellationTokenSource();
                var token = stageIterationCTS.Token;
                int count = 0;
                bool moveRight = true;

                Task.Run(async () =>
                {
                    try
                    {
                        while (!token.IsCancellationRequested)
                        {
                            // pattern detect check & Add corner
                            if (camera.patternFound && camera.latestCorners != null)
                            {
                                // p → Saved All 2D point
                                // latestCorners → New 2D point
                                bool isDuplicate = imagePointsList.Exists(p => Enumerable.SequenceEqual(p, camera.latestCorners));

                                if (!isDuplicate)  // prevent duplicate
                                {
                                    // image coordinate add
                                    imagePointsList.Add((Point2f[])camera.latestCorners.Clone());

                                    // make true 3d coordinate data
                                    objectPointsList.Add(objectPoints);

                                    Console.WriteLine($"検出パターンを追加: {imagePointsList.Count} / {detectPattenSet}");
                                    CalibrationProgress.Value = imagePointsList.Count;   // renew CalibrationProgress

                                    // End Data Collection & Save Yaml
                                    if (imagePointsList.Count >= detectPattenSet)
                                    {
                                        string saveFolder = @"C:\Users\admin\Documents\GitHub\CTMeasure\CalibrationData";
                                        Directory.CreateDirectory(saveFolder);
                                        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                                        string fileName = Path.Combine(saveFolder, $"calibration_{timestamp}.yml");

                                        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write | FileStorage.Modes.FormatYaml))
                                        {
                                            fs.Write("image_points_count", imagePointsList.Count);
                                            for (int i = 0; i < imagePointsList.Count; i++)
                                            {
                                                Point2f[] imagePoints = imagePointsList[i];
                                                Point3f[] objectPoints = objectPointsList[i];

                                                using (var imgMat = Mat.FromArray<Point2f>(imagePoints))
                                                using (var objMat = Mat.FromArray<Point3f>(objectPoints))
                                                {
                                                    fs.Write($"image_points_{i}", imgMat);
                                                    fs.Write($"object_points_{i}", objMat);
                                                }
                                            }
                                        }

                                        // Stage pause
                                        Invoke((MethodInvoker)(() =>
                                        {
                                            stageIterationCTS.Cancel();
                                            stageIterationCTS.Dispose();
                                            stageIterationCTS = null;
                                            isIteration = false;
                                            MessageBox.Show($"{detectPattenSet}パターンを取得し、ファイルに保存しました：{fileName}", "完了");

                                            // Calibration 実行
                                            try
                                            {
                                                var result = camera.ExecuteCalibration(saveFolder);
                                                MessageBox.Show($"キャリブレーション完了！\n誤差: {result.ReprojectionError:F4}\nファイル保存: {result.SavedFilePath}", "完了");
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("キャリブレーション実行中にエラーが発生しました: " + ex.Message, "エラー");
                                            }

                                            this.CamCalibration.BackgroundImage = Properties.Resources.Calibration_Start;
                                        }));
                                    }
                                }
                            }

                            // stage move process
                            if (moveRight)
                            {
                                stage.StartMove("A", 1000, false); // 正方向
                                count++;
                                if (count >= MaxRight)
                                {
                                    moveRight = false;
                                }
                            }
                            else
                            {
                                stage.StartMove("A", 1000, true); // 負方向
                                count--;
                                if (count <= MaxLeft)
                                {
                                    moveRight = true;
                                }
                            }

                            await Task.Delay(1000, token);
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        // Safe stop
                    }
                }, token);

                isIteration = true;
                MessageBox.Show("キャリブレーションを開始しました。", "実行中");
                this.CamCalibration.BackgroundImage = Properties.Resources.Calibration_Stop;
            }
            else
            {
                stageIterationCTS.Cancel();
                stageIterationCTS.Dispose();
                stageIterationCTS = null;
                isIteration = false;
                MessageBox.Show("キャリブレーションを停止しました。", "停止");
                this.CamCalibration.BackgroundImage = Properties.Resources.Calibration_Start;
            }

        }

        // Read Calibration Parameter ( Internal Calibration )
        private void ReadCalibrationData(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "キャリブレーションパラメータを選択";
                ofd.Filter = "YAMLファイル (*.yml)|*.yml";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var fs = new FileStorage(ofd.FileName, FileStorage.Modes.Read))
                        {
                            camera.cameraMatrixUndistort = fs["camera_matrix"].ReadMat();
                            camera.distCoeffsUndistort = fs["dist_coeffs"].ReadMat();
                        }

                        MessageBox.Show("キャリブレーションパラメータを読み込みました。\n" +
                                        $"ファイル名: {Path.GetFileName(ofd.FileName)}", "読み込み成功");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("読み込みに失敗しました: " + ex.Message, "エラー");
                    }
                }
            }
        }

        // -------------------------------------   CrossTalk Method -------------------------------------
        // 測定用フォーム表示
        private void CTR_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                CrosstalkEvaluation ctr = new CrosstalkEvaluation(70.0);
                ctr.CameraRef = camera;  // CameraManagerインスタンスを渡す
                ctr.StageRef = stage;    // StageControllerインスタンスを渡す
                ctr.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("UIの初期化中にエラーが発生しました: " + ex.Message, "エラー");
            }
        }

        private void CalcCrosstalkButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 画像ファイル選択
                string blackPath = SelectImage("黒画像を選択してください");
                if (blackPath == null) return;

                string whitePath = SelectImage("白画像を選択してください");
                if (whitePath == null) return;

                string bwPath = SelectImage("黒白画像を選択してください");
                if (bwPath == null) return;

                // 画像読み込み
                Mat black = Cv2.ImRead(blackPath, ImreadModes.Grayscale);
                Mat white = Cv2.ImRead(whitePath, ImreadModes.Grayscale);
                Mat bw = Cv2.ImRead(bwPath, ImreadModes.Grayscale);

                if (black.Empty() || white.Empty() || bw.Empty())
                {
                    MessageBox.Show("画像の読み込みに失敗しました。", "エラー");
                    return;
                }

                // ROI選択
                Rect roi = Cv2.SelectROI("クロストーク領域選択", bw);
                if (roi.Width == 0 || roi.Height == 0)
                {
                    MessageBox.Show("ROIが無効です。", "エラー");
                    return;
                }
                Mat blackROI = new Mat(black, roi);
                Mat whiteROI = new Mat(white, roi);
                Mat bwROI = new Mat(bw, roi);

                // ROI画像を保存
                //try
                //{
                //    string saveFolder = @"C:\Users\admin\Documents\GitHub\CTMeasure\ROI_Data";
                //    Directory.CreateDirectory(saveFolder);
                //    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                //    Mat blackROI = new Mat(black, roi);
                //    Mat whiteROI = new Mat(white, roi);
                //    Mat bwROI = new Mat(bw, roi);

                //    Cv2.ImWrite(Path.Combine(saveFolder, $"black_roi_{timestamp}.png"), blackROI);
                //    Cv2.ImWrite(Path.Combine(saveFolder, $"white_roi_{timestamp}.png"), whiteROI);
                //    Cv2.ImWrite(Path.Combine(saveFolder, $"bw_roi_{timestamp}.png"), bwROI);

                //    MessageBox.Show($"ROI領域の画像を保存しました。\n保存先: {saveFolder}", "保存完了");
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("ROI画像保存中にエラーが発生しました: " + ex.Message, "エラー");
                //}

                // クロストーク計算
                var results = ctr.calcCTR(roi, black, white, bw);

                string message = $"クロストーク率: {results.ctr:F2} %\n"
                               + $"黒画像平均: {results.ave_b:F2}\n"
                               + $"白画像平均: {results.ave_w:F2}\n"
                               + $"黒白画像平均: {results.ave_bw:F2}";

                MessageBox.Show(message, "計算結果");
            }
            catch (Exception ex)
            {
                MessageBox.Show("計算中にエラーが発生しました: " + ex.Message);
            }
        }

        // 画像選択ダイアログ
        private string SelectImage(string title)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = title;
                ofd.Filter = "画像ファイル (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";

                if (ofd.ShowDialog() == DialogResult.OK)
                    return ofd.FileName;
            }
            return null;
        }

        // ------------------------------------   Luminance Method -------------------------------------
        // 輝度測定用（既存のSelectImage()は共通利用）
        private void LuminanceMeasure_Click(object sender, EventArgs e)
        {
            string imagePath = SelectImage("輝度を測定する画像を選択してください");
            if (imagePath == null) return;

            try
            {
                // 画像読み込み（グレースケールとして読み込む）
                Mat img = Cv2.ImRead(imagePath, ImreadModes.Grayscale);
                if (img.Empty())
                {
                    MessageBox.Show("画像の読み込みに失敗しました。", "エラー");
                    return;
                }

                // 輝度統計計算
                Scalar meanScalar = Cv2.Mean(img);
                double meanLuminance = meanScalar.Val0;

                double minLuminance, maxLuminance;
                Cv2.MinMaxLoc(img, out minLuminance, out maxLuminance);
            }
            catch (Exception ex)
            {
                MessageBox.Show("輝度測定中にエラーが発生しました: " + ex.Message, "エラー");
            }
        }

        // ------------------------------------- TCP communication -------------------------------------
        private bool isTCPConnected = false;
        private bool isClient = false;
        private string[] tokens;
        private string clinetInfo;
        public static SimpleTCP.Message lastClient; // 最後に受信したクライアント情報

        // サーバー起動
        private void ConnectUnityButton_Click(object sender, EventArgs e)
        {
            if (!isTCPConnected)
            {
                try
                {
                    simpleServer = new SimpleTcpServer()
                    {
                        StringEncoder = Encoding.UTF8,
                        Delimiter = 0x0A
                    };

                    // 接続通知
                    simpleServer.ClientConnected += (s, client) =>
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            clinetInfo = client.Client.RemoteEndPoint.ToString();
                            MessageBox.Show($"Unityが接続しました：{clinetInfo}");

                            if (!isClient)
                            {
                                isClient = true;
                            }

                            // client 追加
                            ClientList.Items.Add(clinetInfo);
                        }));
                    };

                    // 切断通知
                    simpleServer.ClientDisconnected += (s, client) =>
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            MessageBox.Show($"Unityが切断されました：{client.Client.RemoteEndPoint}");
                        }));
                    };

                    // メッセージ受信通知
                    simpleServer.DataReceived += (s, msg) =>
                    {
                        lastClient = msg;

                        string received = msg.MessageString.Trim();
                        Invoke((MethodInvoker)(() =>
                        {
                            //MessageBox.Show($"Unityから受信: {received}");
                            tokens = received.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                            // 「Hello」受信時に「request」送信
                            if (tokens.Length > 0 && tokens[0].StartsWith("Hello"))
                            {
                                msg.ReplyLine("request");
                                Console.WriteLine("Hello を受信 → request 送信");
                                return;
                            }

                            // データスプリット
                            if (tokens.Length > 0 && tokens[0] == "current")
                            {
                                if (tokens.Length >= 24)
                                {
                                    MessageBox.Show("パラメータ受信");
                                }
                                else
                                {
                                    MessageBox.Show("受信データの数が不足しています", "エラー");
                                }
                            }

                            // クロストーク比測定時に使うTCP通信
                            if (tokens.Length > 0 && tokens[0] == "ACK")  // 返信が "ACK" の場合
                            {
                                // CrosstalkEvaluation.cs 側に通知
                                if (Application.OpenForms["CrosstalkEvaluation"] is CTMeasure.CrosstalkEvaluation form)
                                {
                                    form.SetTCPReply("OK");   // 応答を渡す
                                }
                            }
                        }));
                    };


                    simpleServer.Start(System.Net.IPAddress.Any, 5005);
                    isTCPConnected = true;
                    ConnectTCP.BackgroundImage = Properties.Resources.DisConnectTCP;
                    MessageBox.Show("Unityからの接続を待ち受けています（ポート5005）");

                    // IP表示
                    string ip = "";
                    string hostname = Dns.GetHostName();

                    IPAddress[] ips = Dns.GetHostAddresses(hostname);
                    //一覧からIPv4アドレスのみ抽出する
                    foreach (IPAddress a in ips)
                    {
                        //IPv4を対象とする
                        if (a.AddressFamily.Equals(AddressFamily.InterNetwork))
                        {
                            ip = a.ToString() + " : 5005";
                            break;
                        }
                    }
                    Server.Text = ip;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("サーバー起動エラー: " + ex.Message);
                }
            }
            else
            {
                simpleServer.Stop();
                simpleServer = null;
                isTCPConnected = false;
                ConnectTCP.BackgroundImage = Properties.Resources.ConnectTCP;
                MessageBox.Show("Unity接続を停止しました");
            }
        }

        // 自動停止
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (simpleServer != null)
            {
                simpleServer.Stop();
                simpleServer = null;
            }
            base.OnFormClosing(e);
        }

        // 3Dディスプレイコントロール用UI表示
        private void Show_UI(object sender, EventArgs e)
        {
            if (!isClient)
            {
                MessageBox.Show("クライアントがいません");
                return;
            }

            // パラメータが不足しているときの安全対策
            if (tokens == null || tokens.Length < 25)
            {
                MessageBox.Show("Unityからのパラメータをまだ受信していません。", "エラー");
                return;
            }

            try
            {
                // パラメータを渡してUIフォームを生成・表示
                UIctrl ui = new UIctrl(
                    clinetInfo,
                    tokens[1], tokens[2], tokens[3],
                    tokens[4], tokens[5], tokens[6],
                    tokens[7], tokens[8], tokens[9],
                    tokens[10], tokens[11], tokens[12],
                    tokens[13], tokens[14], tokens[15],
                    tokens[16], tokens[17], tokens[18],
                    tokens[19], tokens[20], tokens[21],
                    tokens[22], tokens[23], tokens[24]
                );

                ui.Show();         // モードレス表示
                ui.SetClientInfo(); // クライアントIP表示など
            }
            catch (Exception ex)
            {
                MessageBox.Show("UIの初期化中にエラーが発生しました: " + ex.Message, "エラー");
            }
        }

        
    }
}
