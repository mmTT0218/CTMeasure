using SpinnakerNET;
using SpinnakerNET.GenApi;                  // Camera Controll Class
using System;
using System.Drawing;                       // Bitmap or Color imaging
using System.IO;
using System.IO.Ports;                      // Serial Port 
using System.Security.Policy;
using System.Windows.Forms;                 // Windows Form Application Component
using Timer = System.Windows.Forms.Timer;   // Timer
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Collections.Generic;
using Size = OpenCvSharp.Size;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace CTMeasure
{
    public partial class CrossTalkMeasure : Form
    {
        // Define
        Color Red = Color.Red;
        Color Green = Color.Lime;

        public CrossTalkMeasure()
        {
            InitializeComponent();
        }

        // Initialize
        private void CrossTalkMeasure_Load(object sender, EventArgs e)
        {
            Red = Color.Red;
            Green = Color.Lime;


            // Stage Move Timer
            stageMoveTimer = new Timer();
            stageMoveTimer.Interval = 100; // 100ms
            stageMoveTimer.Tick += StageMoveTimer_Tick;
        }

        // -------------------------------------  Camera Controll Method (Spinnaker) -------------------------------------
        // Spinnaker
        private bool cap = false;              // Cap Start/Stop Flag
        private bool pattern = false;          // pattern drawing ON/OFF
        private int counter = 0;               // Nframe Counter
        private const int detectInterval = 2;  // Pattern Drawing Interval
        private Bitmap originalBitmap = null;  // capture image
        private float zoomFactor = 0.5f;       // zoom scale
        private ManagedSystem system = null;              // Sipnnaker System Controll
        private IManagedCamera camera = null;             // Camera Controll
        private IManagedImageProcessor processor = null;  // Imaging Processor
        private Timer captureTimer = null;                // Framerate
        
        // Cap Start/Stop
        private void CapButton_Click(object sender, EventArgs e)
        {
            // Cap Start
            if (!cap)
            {
                this.CapButton.BackgroundImage = Properties.Resources.StreamOFF;
                cap = true;
                startCam();
            }
            // Cap Stop
            else
            {
                this.CapButton.BackgroundImage = Properties.Resources.StreamON;
                cap = false;
                stopCam();
            }
        }

        // Photo Shot
        private void PhotoButton_Click(object sender, EventArgs e)
        {
            // Camera check
            if (camera == null || !cap)
            {
                MessageBox.Show("カメラが起動していません。", "注意");
                return;
            }
            // try process
            try
            {
                using (IManagedImage rawImage = camera.GetNextImage(1000)) // 1 frame get (wait 1000ms)
                {
                    if (!rawImage.IsIncomplete)  // image Check
                    {
                        using (var converted = processor.Convert(rawImage, PixelFormatEnums.Mono8))  // convert Mono8 format
                        using (var bmp = new Bitmap(converted.bitmap))   // convert bitmap
                        {
                            // named photo file
                            string saveFolder = @"C:\Users\admin\Documents\GitHub\CTMeasure\PhotoData";  // save to folder
                            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");         // time stamp
                            string filename = Path.Combine(saveFolder, $"photo_{timestamp}.jpg");

                            // save file
                            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                            MessageBox.Show($"画像を保存しました: {filename}", "保存成功");
                        }
                    }
                    else
                    {
                        MessageBox.Show("画像が不完全のため、保存されませんでした。", "警告");
                    }
                }
                // rawimage.Dispose() called
            }
            // Error process
            catch (SpinnakerException ex)
            {
                MessageBox.Show("写真保存中にエラーが発生しました: " + ex.Message, "エラー");
            }
        }

        // Image Shrink
        private void ShrinkButton_Click(object sender, EventArgs e)
        {
            zoomFactor = Math.Max(0.5f, zoomFactor - 0.1f);
            StreamImage.Invalidate(); // call pictureBox1_Paint
        }

        // Image Enlarge
        private void EnlargeButton_Click(object sender, EventArgs e)
        {
            zoomFactor = Math.Min(5.0f, zoomFactor + 0.1f);
            StreamImage.Invalidate(); // call pictureBox1_Paint
        }

        // shrink/enlarge method
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
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

        // Cam Start Method
        private void startCam()
        {
            try
            {
                system = new ManagedSystem();
                var camList = system.GetCameras();  // Get Camera List through ManagedSystem

                // Cam Check
                if (camList.Count == 0)
                {
                    MessageBox.Show("カメラが検出されませんでした。", "エラー");
                    return;
                }

                camera = camList[0];  // First Camera Get
                camera.Init();        // Camera Initialize

                // Mode Setting
                var acquisitionMode = camera.GetNodeMap().GetNode<IEnum>("AcquisitionMode"); // Set AcquisitionMode
                var continuous = acquisitionMode.GetEntryByName("Continuous");               // Continuos Image
                acquisitionMode.Value = continuous.Symbolic;                    // Apply Continuos Mode

                camera.BeginAcquisition();   // Begin Capture

                // Create Imaging Processor 
                processor = new ManagedImageProcessor();
                processor.SetColorProcessing(ColorProcessingAlgorithm.HQ_LINEAR); // Linear Interpolation Processing

                // ColorProcessingAlgorithm
                //{
                //    NONE,
                //    NEAREST_NEIGHBOR,
                //    NEAREST_NEIGHBOR_AVG,
                //    BILINEAR,
                //    EDGE_SENSING,
                //    HQ_LINEAR,
                //    IPP,
                //    DIRECTIONAL_FILTER,
                //    RIGOROUS,
                //    WEIGHTED_DIRECTIONAL_FILTER 
                //}

                // Create Timer
                captureTimer = new Timer();        // Timer Initialize
                captureTimer.Interval = 8;        // 8ms cycle ( ~= 120fps)
                captureTimer.Tick += CaptureFrame; // Tick Event
                captureTimer.Start();              // Start captureTimer
            }
            // Error Process
            catch (SpinnakerException ex)
            {
                MessageBox.Show("カメラ初期化エラー: " + ex.Message, "エラー");
            }
        }

        // Timer Capture Frame
        private void CaptureFrame(object sender, EventArgs e)
        {
            if (camera == null || !cap) return;

            try
            {
                using (IManagedImage rawImage = camera.GetNextImage(1000))   // wait until 1000ms
                {
                    if (!rawImage.IsIncomplete)
                    {
                        using (var converted = processor.Convert(rawImage, PixelFormatEnums.Mono8))
                        using (var bmp = new Bitmap(converted.bitmap))
                        {
                            StreamImage.Invoke((MethodInvoker)delegate
                            {
                                Mat mat = BitmapConverter.ToMat(bmp);

                                // Apply Calibration
                                if (cameraMatrixUndistort != null && distCoeffsUndistort != null)
                                {
                                    Mat undistorted = new Mat();
                                    Cv2.Undistort(mat, undistorted, cameraMatrixUndistort, distCoeffsUndistort);
                                    mat = undistorted;
                                }

                                // Pattern Drawing
                                if (pattern)
                                {
                                    Mat gray = new Mat();
                                    Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);

                                    if (!isDetecting)
                                        StartAsyncPatternDetection(gray.Clone());

                                    if (patternFound && latestCorners != null)
                                    {
                                        Cv2.DrawChessboardCorners(mat, patternSize, latestCorners, patternFound);
                                    }
                                }

                                originalBitmap?.Dispose();
                                originalBitmap = BitmapConverter.ToBitmap(mat);
                                StreamImage.Invalidate();
                            });
                        }
                    }
                }
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("画像取得エラー: " + ex.Message);
            }
        }

        // Pattern ON/OFF Button
        private void TogglePattern(object sender, EventArgs e)
        {   
            // camera check
            if (camera == null && !cap)
            {
                MessageBox.Show("カメラが接続されていません。", "注意");
                return;
            }

            pattern = !pattern; //reverse
            if (pattern)
            {
                PatternDetect.BackgroundImage = Properties.Resources.PatternOFF;
            }
            if (!pattern)
            {
                PatternDetect.BackgroundImage = Properties.Resources.PatternON;
                pattern = false;
            }
        }

        // Cap Stop Method
        private void stopCam()
        {
            try
            {
                captureTimer?.Stop();     // captureTimer stop
                captureTimer?.Dispose();  // resource release
                captureTimer = null;

                // camera stop process
                if (camera != null)
                {
                    camera.EndAcquisition();  // end image acquisition
                    camera.DeInit();          // initialize release
                    camera.Dispose();         // resource release
                    camera = null;
                }

                // Spinnaker system resource release
                system?.Dispose();
                system = null;
            }
            // Erroe process
            catch (SpinnakerException ex)
            {
                MessageBox.Show("カメラ停止エラー: " + ex.Message, "エラー");
            }
        }
        // --------------------------------------------------------------------------------------------------

        // -------------------------------------  Stage Controll Method -------------------------------------
        // Stage
        private bool isConnect = false;                   // Stage Connect Flag
        private SerialPort stagePort = null;              // SerialPort Status
        private const string STAGE_PORT_NAME = "COM2";    // Port Name
        private const int STAGE_BAUDRATE = 9600;          // BaudRate
        private const string STAGE_DELIMITER = "\r\n";    // Put "\r\n" Automatically
        private Timer stageMoveTimer;                     // Long Press 
        private string currentStageCommand = "";          // Move Axis
        // Connect Stage
        private void Connect_Stage_Click(object sender, EventArgs e)
        {
            // Connect Stage
            if (!isConnect)
            {
                try
                {
                    stagePort = new SerialPort(STAGE_PORT_NAME, STAGE_BAUDRATE, Parity.None, 8, StopBits.One);
                    stagePort.NewLine = STAGE_DELIMITER;
                    stagePort.ReadTimeout = 1000;
                    stagePort.WriteTimeout = 1000;
                    stagePort.Open();
                    MessageBox.Show($"ステージに接続しました: {STAGE_PORT_NAME}");

                    isConnect = true;
                    this.ConnectButton.BackColor = Red;
                    this.ConnectButton.BackgroundImage = Properties.Resources.ConnectOFF;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ステージ接続エラー: " + ex.Message);
                }
            }
            // DisConnect Stage
            else
            {
                try
                {
                    stagePort?.Close();
                    stagePort = null;

                    MessageBox.Show("ステージとの接続を解除しました。");

                    isConnect = false;
                    this.ConnectButton.BackColor = Green;
                    this.ConnectButton.BackgroundImage = Properties.Resources.ConnectON;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ステージ切断エラー: " + ex.Message);
                }
            }
        }

        // Send Command to Stage
        private void SendStageCommand(string cmd)
        {
            if (stagePort == null || !stagePort.IsOpen) return;
            try
            {
                stagePort.WriteLine(cmd);
                Console.WriteLine($"送信: {cmd}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("コマンド送信エラー: " + ex.Message, "エラー");
            }
        }

        // Stage Move Timer
        private void StageMoveTimer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentStageCommand))
                SendStageCommand(currentStageCommand);
        }

        // UP
        private void Stage_Up_MouseDown(object sender, MouseEventArgs e)
        {
            currentStageCommand = "MGO:B-1000";
            stageMoveTimer.Start();
            this.Up.BackColor = Red;
        }

        private void Stage_Up_MouseUp(object sender, MouseEventArgs e)
        {
            stageMoveTimer.Stop();
            currentStageCommand = "";
            this.Up.BackColor = Green;
        }

        // DOWN
        private void Stage_Down_MouseDown(object sender, MouseEventArgs e)
        {
            currentStageCommand = "MGO:B+1000";
            stageMoveTimer.Start();
            this.Down.BackColor = Red;
        }

        private void Stage_Down_MouseUp(object sender, MouseEventArgs e)
        {
            stageMoveTimer.Stop();
            currentStageCommand = "";
            this.Down.BackColor = Green;
        }

        // LEFT
        private void Stage_Left_MouseDown(object sender, MouseEventArgs e)
        {
            currentStageCommand = "MGO:A-1000";
            stageMoveTimer.Start();
            this.Left.BackColor = Red;
        }

        private void Stage_Left_MouseUp(object sender, MouseEventArgs e)
        {
            stageMoveTimer.Stop();
            currentStageCommand = "";
            this.Left.BackColor = Green;
        }

        // RIGHT
        private void Stage_Right_MouseDown(object sender, MouseEventArgs e)
        {
            currentStageCommand = "MGO:A+1000";
            stageMoveTimer.Start();
            this.Right.BackColor = Red;
        }

        private void Stage_Right_MouseUp(object sender, MouseEventArgs e)
        {
            stageMoveTimer.Stop();
            currentStageCommand = "";
            this.Right.BackColor = Green;
        }

        // --------------------------------------------------------------------------------------------------

        // -------------------------------------   Camera Calibration Method -------------------------------------
        // detect pattern
        List<Point2f[]> imagePointsList = new List<Point2f[]>();
        List<Point3f[]> objectPointsList = new List<Point3f[]>();
        Size patternSize = new Size(11, 4);                        // Asymmetry-CircleGrid（row x col）
        float circleSpacing = 20.0f;                               // circle space [mm]
        private volatile Point2f[] latestCorners = null;
        private volatile bool patternFound = false;
        private volatile bool isDetecting = false;
        private int detectPattenSet = 40;
        // stage controll
        private CancellationTokenSource stageIterationCTS = null;
        private bool isIteration = false;   // Iteration flag
        private const int MaxRight = 20;    // Max Roght Pos
        private const int MaxLeft = -20;    // Max Left Pos
        // calibration data
        private Mat cameraMatrixUndistort = null;  // camera matrix
        private Mat distCoeffsUndistort = null;    // distorted matrix

        // detectPattenSet change
        private void MaxDetectPatternChanged(object sender, EventArgs e)
        {
            detectPattenSet = int.Parse(MaxDetectSet.Text);
        }

        // Calibration data Collect Start
        private void Calibration(object sender, EventArgs e)
        {
            // chack stage & camera connect
            if (!isConnect || stagePort == null || !stagePort.IsOpen || camera == null || !cap)
            {
                MessageBox.Show("ステージまたはカメラが接続されていません。", "注意");
                return;
            }


            // PointList Initialize
            imagePointsList = new List<Point2f[]>();
            objectPointsList = new List<Point3f[]>();

            // ProgressBar Initialize
            CalibrationProgress.Minimum = 0;
            CalibrationProgress.Maximum = detectPattenSet;
            CalibrationProgress.Value = 0;

            // iteration move start
            if (!isIteration)
            {
                stageIterationCTS = new CancellationTokenSource();
                var token = stageIterationCTS.Token;
                int count = 1;

                Task.Run(async () =>
                {
                    try
                    { 
                        while (!token.IsCancellationRequested)
                        {
                            // pattern detect check & Add corner
                            if (patternFound && latestCorners != null)
                            {
                                bool isDuplicate = imagePointsList.Exists(p => Enumerable.SequenceEqual(p, latestCorners));

                                if (!isDuplicate)
                                {
                                    // image coordinate add
                                    imagePointsList.Add((Point2f[])latestCorners.Clone());

                                    // object detect
                                    Point3f[] objPoints = new Point3f[patternSize.Width * patternSize.Height];
                                    for (int i = 0; i < patternSize.Height; i++)
                                    {
                                        for (int j = 0; j < patternSize.Width; j++)
                                        {
                                            objPoints[i * patternSize.Width + j] = new Point3f(
                                                j * circleSpacing,
                                                i * circleSpacing,
                                                0
                                            );
                                        }
                                    }
                                    objectPointsList.Add(objPoints);
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
                                        }));

                                        // Get CameraMatrix & DistortionMatrix by latest data
                                        ExecutCalibration();
                                        this.CamCalibration.BackgroundImage = Properties.Resources.Calibration_Start;
                                        return;
                                    }
                                }
                            }

                            // stage move process
                            if (count > 0 && count <= MaxRight)
                            {
                                SendStageCommand("MGO:A+1000");
                                count++;
                                if (count > MaxRight)
                                {
                                    count = -1;
                                }
                            }
                            else if (count < 0 && count >= MaxLeft)
                            {
                                SendStageCommand("MGO:A-1000");
                                count--;
                                if (count < MaxLeft)
                                {
                                    count = 1;
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

        // PatternDetect
        private void StartAsyncPatternDetection(Mat inputGray)
        {
            if (isDetecting) return; // multiple prevent

            isDetecting = true;

            Task.Run(() =>
            {
                try
                {
                    Point2f[] corners;
                    bool found = Cv2.FindCirclesGrid(
                        inputGray,
                        patternSize,
                        out corners,
                        FindCirclesGridFlags.AsymmetricGrid);

                    if (found)
                    {
                        latestCorners = corners;
                        patternFound = true;
                    }
                    else
                    {
                        patternFound = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("パターン検出エラー: " + ex.Message);
                }
                finally
                {
                    isDetecting = false;
                }
            });
        }

        // Run Calibration
        private void ExecutCalibration()
        {
            try
            {
                // YML File Read
                string folderPath = @"C:\Users\admin\Documents\GitHub\CTMeasure\CalibrationData";
                string[] files = Directory.GetFiles(folderPath, "calibration_*.yml");
                if (files.Length == 0)
                {
                    MessageBox.Show("キャリブレーションデータが見つかりませんでした。", "エラー");
                    return;
                }

                // latest file get
                string filePath = files.OrderByDescending(f => f).First();

                List<Point2f[]> imagePointsList = new List<Point2f[]>();
                List<Point3f[]> objectPointsList = new List<Point3f[]>();

                // ProgressBar Initialize
                CalibrationProgress.Minimum = 0;
                CalibrationProgress.Maximum = detectPattenSet;
                CalibrationProgress.Value = 0;

                using (var fs = new FileStorage(filePath, FileStorage.Modes.Read))
                {
                    int count = (int)fs["image_points_count"].ReadInt();
                    for (int i = 0; i < count; i++)
                    {
                        Mat imgMat = fs[$"image_points_{i}"].ReadMat();
                        Mat objMat = fs[$"object_points_{i}"].ReadMat();

                        Point2f[] imagePoints;
                        Point3f[] objectPoints;

                        imgMat.GetArray(out imagePoints);
                        objMat.GetArray(out objectPoints);

                        imagePointsList.Add(imagePoints);
                        objectPointsList.Add(objectPoints);

                        CalibrationProgress.Value = i + 1;
                    }
                }

                // 2. カメラ画像サイズ（使用しているカメラに合わせてください）
                Size imageSize = new Size(2048, 1536);

                // 3. キャリブレーション実行
                Mat cameraMatrix = new Mat();
                Mat distCoeffs = new Mat();
                Mat[] rvecs, tvecs;

                List<Mat> objectPointsMatList = objectPointsList
                    .Select(pts => InputArray.Create(pts).GetMat()).ToList();

                List<Mat> imagePointsMatList = imagePointsList
                    .Select(pts => InputArray.Create(pts).GetMat()).ToList();

                double error = Cv2.CalibrateCamera(
                    objectPointsMatList,     // IEnumerable<Mat>
                    imagePointsMatList,      // IEnumerable<Mat>
                    imageSize,
                    cameraMatrix,
                    distCoeffs,
                    out rvecs,
                    out tvecs,
                    CalibrationFlags.None
                );

                // 4. 結果保存
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string savePath = Path.Combine(folderPath, $"calib_result_{timestamp}.yml");

                using (var fsOut = new FileStorage(savePath, FileStorage.Modes.Write | FileStorage.Modes.FormatYaml))
                {
                    fsOut.Write("camera_matrix", cameraMatrix);
                    fsOut.Write("dist_coeffs", distCoeffs);
                    fsOut.Write("reprojection_error", error);
                }

                MessageBox.Show($"キャリブレーション完了！\n誤差: {error:F4}\nファイル保存: {savePath}", "完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show("キャリブレーション実行中にエラーが発生しました: " + ex.Message, "エラー");
            }
        }

        // Read Calibration data
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
                            cameraMatrixUndistort = fs["camera_matrix"].ReadMat();
                            distCoeffsUndistort = fs["dist_coeffs"].ReadMat();
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

        private void StreamImage_Click(object sender, EventArgs e)
        {

        }
    }
}
