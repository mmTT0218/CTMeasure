using CTMeasure;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CTMeasure
{
    public class CameraManager : IDisposable
    {
        private ManagedSystem system;
        private IManagedCamera camera;
        private IManagedImageProcessor processor;
        private Timer captureTimer;

        public event Action<Bitmap> OnFrameCaptured;
        public bool IsRunning { get; private set; } = false;

        public void Start()
        {
            try
            {
                system = new ManagedSystem();
                var camList = system.GetCameras();

                if (camList.Count == 0)
                {
                    throw new InvalidOperationException("カメラが検出されませんでした。");
                }

                camera = camList[0];
                camera.Init();

                var nodeMap = camera.GetNodeMap();

                // AcquisitionMode
                var acquisitionMode = nodeMap.GetNode<IEnum>("AcquisitionMode");
                acquisitionMode.Value = acquisitionMode.GetEntryByName("Continuous").Symbolic;

                // ExposureAuto OFF
                var exposureAuto = nodeMap.GetNode<IEnum>("ExposureAuto");
                if (exposureAuto?.IsWritable == true)
                    exposureAuto.Value = exposureAuto.GetEntryByName("Off").Value;

                // ExposureTime
                var exposureTimeNode = nodeMap.GetNode<IFloat>("ExposureTime");
                if (exposureTimeNode?.IsWritable == true)
                    exposureTimeNode.Value = Math.Min(100000.0, exposureTimeNode.Max);

                // GainAuto OFF
                var gainAuto = nodeMap.GetNode<IEnum>("GainAuto");
                if (gainAuto?.IsWritable == true)
                    gainAuto.Value = gainAuto.GetEntryByName("Off").Value;

                // Gain
                var gainNode = nodeMap.GetNode<IFloat>("Gain");
                if (gainNode?.IsWritable == true)
                    gainNode.Value = 0.0;

                // Width/Height
                var widthNode = nodeMap.GetNode<IInteger>("Width");
                var heightNode = nodeMap.GetNode<IInteger>("Height");
                if (widthNode?.IsWritable == true) widthNode.Value = widthNode.Max;
                if (heightNode?.IsWritable == true) heightNode.Value = heightNode.Max;

                // OffsetX/Y
                var offsetXNode = nodeMap.GetNode<IInteger>("OffsetX");
                var offsetYNode = nodeMap.GetNode<IInteger>("OffsetY");
                if (offsetXNode?.IsWritable == true) offsetXNode.Value = 0;
                if (offsetYNode?.IsWritable == true) offsetYNode.Value = 0;

                camera.BeginAcquisition();

                processor = new ManagedImageProcessor();
                processor.SetColorProcessing(ColorProcessingAlgorithm.HQ_LINEAR);

                captureTimer = new Timer();
                captureTimer.Interval = 8;
                captureTimer.Tick += CaptureTimer_Tick;
                captureTimer.Start();

                IsRunning = true;
            }
            catch (SpinnakerException ex)
            {
                throw new InvalidOperationException("カメラ初期化エラー: " + ex.Message);
            }
        }

        private void CaptureTimer_Tick(object sender, EventArgs e)
        {
            if (camera == null || !IsRunning) return;

            try
            {
                using (IManagedImage rawImage = camera.GetNextImage(1000))
                {
                    if (!rawImage.IsIncomplete)
                    {
                        using (var converted = processor.Convert(rawImage, PixelFormatEnums.Mono8))
                        {
                            Bitmap bmp = new Bitmap(converted.bitmap);
                            OnFrameCaptured?.Invoke(bmp);
                        }
                    }
                }
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("画像取得エラー: " + ex.Message);
            }
        }

        public Bitmap CaptureSingleFrame()
        {
            if (camera == null || !IsRunning)
                throw new InvalidOperationException("カメラが起動していません。");

            using (IManagedImage rawImage = camera.GetNextImage(1000))
            {
                if (!rawImage.IsIncomplete)
                {
                    using (var converted = processor.Convert(rawImage, PixelFormatEnums.Mono8))
                    {
                        return new Bitmap(converted.bitmap);
                    }
                }
                else
                {
                    throw new InvalidOperationException("画像が不完全です。");
                }
            }
        }

        public void SaveFrame(string path)
        {
            using (Bitmap bmp = CaptureSingleFrame())
            {
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void Stop()
        {
            captureTimer?.Stop();
            captureTimer?.Dispose();
            captureTimer = null;

            if (camera != null)
            {
                camera.EndAcquisition();
                camera.DeInit();
                camera.Dispose();
                camera = null;
            }

            system?.Dispose();
            system = null;

            IsRunning = false;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
