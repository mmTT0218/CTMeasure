﻿using SpinnakerNET;
using SpinnakerNET.GenApi;                  // Camera Controll Class
using System;
using System.Drawing;                       // Bitmap or Color imaging
using System.IO; 
using System.Windows.Forms;                 // Windows Form Application Component
using Timer = System.Windows.Forms.Timer;   // Timer
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Size = OpenCvSharp.Size;
using System.Linq;

namespace CTMeasure
{
    public class CameraManager : IDisposable
    {
        public Mat LatestFrame { get; private set; } = null;
        // Spinnaker 管理
        private ManagedSystem system = null;
        private IManagedCamera camera = null;
        private IManagedImageProcessor processor = null;
        private Timer captureTimer = null;
        private PictureBox StreamImage;
        private Bitmap currentBitmap;

        public Mat cameraMatrixUndistort = null;
        public Mat distCoeffsUndistort = null;

        // イベント
        public event Action<Mat> OnImageCaptured;
        public event Action<string> OnError;
        public event Action<CameraPose> OnPoseUpdated;

        public volatile bool patternFound = false;
        public volatile Point2f[] latestCorners = null;
        public volatile bool isDetecting = false;
        public volatile bool isSolvingPnP = false;

        // パターン検出トグル
        public bool pattern = false;

        // 非対称サークルグリッドパターン(pixelPitch = 0.09597)
        public Size patternSize = new Size(4, 11);
        private float circleSpacing_x = 21.1134f;
        private float circleSpacing_y = 12.66804f;

        private CameraPose currentPose = null;

        public CameraManager(PictureBox pictureBox)
        {
            StreamImage = pictureBox;
        }

        // ---------------- カメラ制御 -----------------------
        public void StartCamera()
        {
            try
            {
                system = new ManagedSystem();
                var camList = system.GetCameras();
                if (camList.Count == 0) throw new Exception("カメラが検出されません。");

                camera = camList[0];
                camera.Init();

                var nodeMap = camera.GetNodeMap();
                nodeMap.GetNode<IEnum>("AcquisitionMode").Value = "Continuous";
                nodeMap.GetNode<IEnum>("ExposureAuto").Value = "Off";
                nodeMap.GetNode<IFloat>("ExposureTime").Value = Math.Min(100000.0, nodeMap.GetNode<IFloat>("ExposureTime").Max);
                nodeMap.GetNode<IEnum>("GainAuto").Value = "Off";
                nodeMap.GetNode<IFloat>("Gain").Value = 0.0;
                nodeMap.GetNode<IInteger>("Width").Value = nodeMap.GetNode<IInteger>("Width").Max;
                nodeMap.GetNode<IInteger>("Height").Value = nodeMap.GetNode<IInteger>("Height").Max;
                nodeMap.GetNode<IInteger>("OffsetX").Value = 0;
                nodeMap.GetNode<IInteger>("OffsetY").Value = 0;

                camera.BeginAcquisition();

                processor = new ManagedImageProcessor();
                processor.SetColorProcessing(ColorProcessingAlgorithm.HQ_LINEAR);

                captureTimer = new Timer { Interval = 8 };
                captureTimer.Tick += CaptureFrame;
                captureTimer.Start();
            }
            catch (Exception ex)
            {
                OnError?.Invoke("カメラ初期化エラー: " + ex.Message);
            }
        }

        private void CaptureFrame(object sender, EventArgs e)
        {
            if (camera == null) return;

            try
            {
                using (var rawImage = camera.GetNextImage(1000))
                {
                    if (rawImage.IsIncomplete) return;

                    using (var converted = processor.Convert(rawImage, PixelFormatEnums.Mono8))
                    using (var bmp = new Bitmap(converted.bitmap))
                    {
                        StreamImage.Invoke((MethodInvoker)(() =>
                        {
                            Mat mat = BitmapConverter.ToMat(bmp);

                            // 歪み補正
                            if (cameraMatrixUndistort != null && distCoeffsUndistort != null)
                            {
                                Mat undistorted = new Mat();
                                Cv2.Undistort(mat, undistorted, cameraMatrixUndistort, distCoeffsUndistort);
                                mat = undistorted;
                            }

                            // 非対称サークルグリッド検出＆描画
                            if (pattern)
                            {
                                Mat gray = new Mat();
                                Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);
                                if (!isDetecting) StartAsyncPatternDetection(gray.Clone());

                                if (patternFound && latestCorners != null)
                                {
                                    Cv2.DrawChessboardCorners(mat, patternSize, latestCorners, patternFound);
                                }
                            }

                            // XYZ軸描画
                            if (currentPose != null && cameraMatrixUndistort != null && distCoeffsUndistort != null)
                            {
                                DrawXYZAxes(ref mat);
                            }

                            currentBitmap?.Dispose();
                            currentBitmap = BitmapConverter.ToBitmap(mat);
                            StreamImage.Invalidate();

                            // フレーム更新
                            LatestFrame = mat.Clone();
                            OnImageCaptured?.Invoke(mat);
                        }));

                        // PnP問題
                        if (cameraMatrixUndistort != null && distCoeffsUndistort != null && patternFound && latestCorners != null && !isSolvingPnP)
                        {
                            isSolvingPnP = true;
                            Task.Run(() =>
                            {
                                try
                                {
                                    var cornersCopy = (Point2f[])latestCorners.Clone();
                                    var pose = CameraPose.FromSolvePnP(Generate3DPatternPoints(), cornersCopy, cameraMatrixUndistort, distCoeffsUndistort);
                                    if (pose != null)
                                    {
                                        currentPose = pose;
                                        OnPoseUpdated?.Invoke(pose);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("SolvePnP エラー: " + ex.Message);
                                }
                                finally
                                {
                                    isSolvingPnP = false;
                                }
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke("画像取得エラー: " + ex.Message);
            }
        }

        public void StopCamera()
        {
            try
            {
                // Capture 停止
                captureTimer?.Stop();
                captureTimer?.Dispose();
                captureTimer = null;

                // カメラ停止
                camera?.EndAcquisition();
                camera?.DeInit();
                camera?.Dispose();
                camera = null;

                // SpinnakerのManagedSystem破棄
                system?.Dispose();
                system = null;
            }
            catch (Exception ex)
            {
                OnError?.Invoke("カメラ停止エラー: " + ex.Message);
            }
        }

        public void SaveImage()
        {
            try
            {
                using (var rawImage = camera.GetNextImage(1000))
                {
                    if (rawImage.IsIncomplete) return;

                    using (var converted = processor.Convert(rawImage, PixelFormatEnums.Mono8))
                    {
                        // Bitmap → Mat 
                        using (var bmp = new Bitmap(converted.bitmap))
                        {
                            Mat mat = BitmapConverter.ToMat(bmp);

                            // 歪み補正
                            if (cameraMatrixUndistort != null && distCoeffsUndistort != null)
                            {
                                Mat undistorted = new Mat();
                                Cv2.Undistort(mat, undistorted, cameraMatrixUndistort, distCoeffsUndistort);
                                mat = undistorted;
                            }

                            // 保存処理
                            string folder = @"C:\Users\admin\Documents\GitHub\CTMeasure\PhotoData";
                            Directory.CreateDirectory(folder);
                            string filename = Path.Combine(folder, $"photo_{DateTime.Now:yyyyMMdd_HHmmss_fff}.jpg");

                            Cv2.ImWrite(filename, mat);  // OpenCVで保存
                            OnError?.Invoke($"画像を保存しました: {filename}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke("写真保存エラー: " + ex.Message);
            }
        }

        //
        // カメラ外部パラメータ推定クラス
        public class CameraPose
        {
            public double X { get; set; }      // mm
            public double Y { get; set; }
            public double Z { get; set; }

            public double Yaw { get; set; }    // °
            public double Pitch { get; set; }
            public double Roll { get; set; }

            public static CameraPose FromSolvePnP(Point3f[] objectPoints, Point2f[] imagePoints, Mat cameraMatrix, Mat distCoeffs)
            {
                CameraPose pose = null;

                using (var objMat = Mat.FromArray(objectPoints))
                using (var imgMat = Mat.FromArray(imagePoints))
                {
                    Mat rvec = new Mat();
                    Mat tvec = new Mat();

                    Cv2.SolvePnP(objMat, imgMat, cameraMatrix, distCoeffs, rvec, tvec);

                    double x = tvec.At<double>(0);
                    double y = tvec.At<double>(1);
                    double z = tvec.At<double>(2);

                    Mat rotMat = new Mat();
                    Cv2.Rodrigues(rvec, rotMat);
                    double[,] R = new double[3, 3];
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            R[i, j] = rotMat.At<double>(i, j);

                    double yaw = Math.Atan2(R[1, 0], R[0, 0]) * 180.0 / Math.PI;
                    double pitch = Math.Atan2(-R[2, 0], Math.Sqrt(R[2, 1] * R[2, 1] + R[2, 2] * R[2, 2])) * 180.0 / Math.PI;
                    double roll = Math.Atan2(R[2, 1], R[2, 2]) * 180.0 / Math.PI;

                    pose = new CameraPose
                    {
                        X = x,
                        Y = y,
                        Z = z,
                        Yaw = yaw,
                        Pitch = pitch,
                        Roll = roll
                    };
                }

                return pose;
            }

        }

        // 非対称サークルグリッド検出
        private void StartAsyncPatternDetection(Mat inputGray)
        {
            isDetecting = true;
            Task.Run(() =>
            {
                try
                {
                    Point2f[] corners;
                    bool found = Cv2.FindCirclesGrid(inputGray, patternSize, out corners, FindCirclesGridFlags.AsymmetricGrid);
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

        // 非対称サークルグリッドパターンの3D座標（モデル座標系）を生成
        public Point3f[] Generate3DPatternPoints()
        {
            var list = new List<Point3f>();
            for (int i = 0; i < patternSize.Height; i++)  // 行（縦）
            {
                for (int j = 0; j < patternSize.Width; j++)  // 列（横）
                {
                    float x = j * circleSpacing_x + (i % 2) * (circleSpacing_x / 2.0f);
                    float y = i * circleSpacing_y;
                    list.Add(new Point3f(x, y, 0));
                }
            }
            return list.ToArray();
        }


        // XYZ 軸描画処理
        private void DrawXYZAxes(ref Mat mat)
        {
            Point3f[] axisPoints = new Point3f[]
            {
                new Point3f(0, 0, 0),
                new Point3f(50, 0, 0),
                new Point3f(0, 50, 0),
                new Point3f(0, 0, 50)
            };

            Mat tvec = new Mat(3, 1, MatType.CV_64F);
            tvec.Set(0, 0, currentPose.X);
            tvec.Set(1, 0, currentPose.Y);
            tvec.Set(2, 0, currentPose.Z);

            double yaw = currentPose.Yaw * Math.PI / 180.0;
            double pitch = currentPose.Pitch * Math.PI / 180.0;
            double roll = currentPose.Roll * Math.PI / 180.0;

            double cy = Math.Cos(yaw), sy = Math.Sin(yaw);
            double cp = Math.Cos(pitch), sp = Math.Sin(pitch);
            double cr = Math.Cos(roll), sr = Math.Sin(roll);

            double[,] R = new double[3, 3]
            {
                { cy * cp, cy * sp * sr - sy * cr, cy * sp * cr + sy * sr },
                { sy * cp, sy * sp * sr + cy * cr, sy * sp * cr - cy * sr },
                { -sp, cp * sr, cp * cr }
            };

            Mat rotMat = new Mat(3, 3, MatType.CV_64F);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    rotMat.Set(i, j, R[i, j]);

            Mat rvec = new Mat();
            Cv2.Rodrigues(rotMat, rvec);

            Mat imagePointsMat = new Mat();
            Cv2.ProjectPoints(Mat.FromArray(axisPoints), rvec, tvec, cameraMatrixUndistort, distCoeffsUndistort, imagePointsMat);

            Point2f[] imagePoints = new Point2f[imagePointsMat.Rows];
            for (int i = 0; i < imagePointsMat.Rows; i++)
                imagePoints[i] = imagePointsMat.At<Point2f>(i);

            Cv2.Line(mat, imagePoints[0].ToPoint(), imagePoints[1].ToPoint(), Scalar.Red, 2);
            Cv2.Line(mat, imagePoints[0].ToPoint(), imagePoints[2].ToPoint(), Scalar.Green, 2);
            Cv2.Line(mat, imagePoints[0].ToPoint(), imagePoints[3].ToPoint(), Scalar.Blue, 2);
        }

        // Out Calibration Parameter File
        public class CameraCalibrationResult
        {
            public Mat CameraMatrix { get; set; }
            public Mat DistCoeffs { get; set; }
            public double ReprojectionError { get; set; }
            public string SavedFilePath { get; set; }
        }

        public CameraCalibrationResult ExecuteCalibration(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath, "calibration_*.yml");
            if (files.Length == 0)
                throw new FileNotFoundException("キャリブレーションデータが見つかりません。");

            string filePath = files.OrderByDescending(f => f).First();

            var imagePointsList = new List<Point2f[]>();
            var objectPointsList = new List<Point3f[]>();

            using (var fs = new FileStorage(filePath, FileStorage.Modes.Read))
            {
                int count = (int)fs["image_points_count"].ReadInt();
                for (int i = 0; i < count; i++)
                {
                    Mat imgMat = fs[$"image_points_{i}"].ReadMat();
                    Mat objMat = fs[$"object_points_{i}"].ReadMat();

                    imgMat.GetArray(out Point2f[] imagePoints);
                    objMat.GetArray(out Point3f[] objectPoints);

                    imagePointsList.Add(imagePoints);
                    objectPointsList.Add(objectPoints);
                }
            }

            Mat cameraMatrix = new Mat();
            Mat distCoeffs = new Mat();
            Mat[] rvecs, tvecs;

            var objectPointsMatList = objectPointsList.Select(pts => InputArray.Create(pts).GetMat()).ToList();
            var imagePointsMatList = imagePointsList.Select(pts => InputArray.Create(pts).GetMat()).ToList();

            // camera resolution
            Size imageSize = new Size(currentBitmap.Width, currentBitmap.Height);

            double error = Cv2.CalibrateCamera(
                objectPointsMatList,
                imagePointsMatList,
                imageSize,
                cameraMatrix,
                distCoeffs,
                out rvecs,
                out tvecs,
                CalibrationFlags.None
            );

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string savePath = Path.Combine(folderPath, $"calib_result_{timestamp}.yml");

            using (var fsOut = new FileStorage(savePath, FileStorage.Modes.Write | FileStorage.Modes.FormatYaml))
            {
                fsOut.Write("camera_matrix", cameraMatrix);
                fsOut.Write("dist_coeffs", distCoeffs);
                fsOut.Write("reprojection_error", error);
            }

            return new CameraCalibrationResult
            {
                CameraMatrix = cameraMatrix,
                DistCoeffs = distCoeffs,
                ReprojectionError = error,
                SavedFilePath = savePath
            };
        }

        public void Dispose()
        {
            StopCamera();
            currentBitmap?.Dispose();
        }
    }
}