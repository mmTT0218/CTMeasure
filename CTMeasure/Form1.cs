using SpinnakerNET;
using SpinnakerNET.GenApi;                  // Camera Controll Class
using System;
using System.Drawing;                       // Bitmap or Color imaging
using System.IO;
using System.IO.Ports;                      // Serial Port 
using System.Security.Policy;
using System.Windows.Forms;                 // Windows Form Application Component
using Timer = System.Windows.Forms.Timer;   // Timer

namespace CTMeasure
{
    public partial class CrossTalkMeasure : Form
    {
        // Define
        Color Red = Color.Red;
        Color Green = Color.Lime;
        Color Blue = Color.DeepSkyBlue;

        // Spinnaker
        private bool cap = false;        // Cap Start/Stop Flag
        private bool rec = false;        // rec Start/Stop Flag
        private Bitmap originalBitmap = null;  // capture image
        private float zoomFactor = 1.0f;       // zoom scale
        private ManagedSystem system = null;              // Sipnnaker System Controll
        private IManagedCamera camera = null;             // Camera Controll
        private IManagedImageProcessor processor = null;  // Imaging Processor
        private Timer captureTimer = null;                // Framerate

        // Stage
        private bool isConnect = false;                   // Stage Connect Flag
        private SerialPort stagePort = null;              // SerialPort Status
        private const string STAGE_PORT_NAME = "COM2";    // Port Name
        private const int STAGE_BAUDRATE = 9600;          // BaudRate
        private const string STAGE_DELIMITER = "\r\n";    // Put "\r\n" Automatically
        private Timer stageMoveTimer;                     // Long Press 
        private string currentStageCommand = "";          // Move Direction

        public CrossTalkMeasure()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.ActiveControl = null;
            this.KeyDown += CrossTalkMeasure_KeyDown;
        }

        // Initialize
        private void CrossTalkMeasure_Load(object sender, EventArgs e)
        {
            Red = Color.Red;
            Green = Color.Lime;
            Blue = Color.DeepSkyBlue;

            // Stage Move Timer
            stageMoveTimer = new Timer();
            stageMoveTimer.Interval = 100; // 100ms
            stageMoveTimer.Tick += StageMoveTimer_Tick;
        }

        // -------------------------------------  Camera Controll Method -------------------------------------
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
                captureTimer.Interval = 17;        // 33ms cycle (30fps)
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
            if (camera == null || !cap) return;   // Check Camera Status

            try
            {
                using (IManagedImage rawImage = camera.GetNextImage(1000))  // Get Next Frame (wait until 1000ms)
                {
                    if (!rawImage.IsIncomplete)  // check rawimage
                    {
                        using (var converted = processor.Convert(rawImage, PixelFormatEnums.Mono8))  // Convert GreyScale
                        using (var bmp = new Bitmap(converted.bitmap))   // Bitmapping
                        {
                            StreamImage.Invoke((MethodInvoker)delegate {  // Invoke : Call UI Thread
                                originalBitmap?.Dispose();
                                originalBitmap = new Bitmap(bmp);  // renew originalBitmap
                                StreamImage.Invalidate();          // reDraw
                            });
                        }
                    }
                }
                // rawImage.Dispose()
            }
            // Error Process
            catch (SpinnakerException ex)
            {
                Console.WriteLine("画像取得エラー: " + ex.Message);
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

        // Key Event
        private void CrossTalkMeasure_KeyDown(object sender, KeyEventArgs e)
        {

        }

        // --------------------------------------------------------------------------------------------------
    }
}
