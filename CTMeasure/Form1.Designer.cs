namespace CTMeasure
{
    partial class CrossTalkMeasure
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.CameraControll = new System.Windows.Forms.GroupBox();
            this.EnlargeButton = new System.Windows.Forms.Button();
            this.ShrinkButton = new System.Windows.Forms.Button();
            this.PhotoButton = new System.Windows.Forms.Button();
            this.CapButton = new System.Windows.Forms.Button();
            this.StageControll = new System.Windows.Forms.GroupBox();
            this.YAxis_Value = new System.Windows.Forms.TextBox();
            this.XAxis_Value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Right = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.CalibrationControll = new System.Windows.Forms.GroupBox();
            this.Pattarn = new System.Windows.Forms.Label();
            this.MaxDetectSet = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PatternDetect = new System.Windows.Forms.Button();
            this.CalibrationProgress = new System.Windows.Forms.ProgressBar();
            this.CamCalibration = new System.Windows.Forms.Button();
            this.Movie = new System.Windows.Forms.GroupBox();
            this.StreamImage = new System.Windows.Forms.PictureBox();
            this.CameraPos = new System.Windows.Forms.GroupBox();
            this.Camera_Roll = new System.Windows.Forms.Label();
            this.Camera_Pitch = new System.Windows.Forms.Label();
            this.Camera_Yaw = new System.Windows.Forms.Label();
            this.Camera_Z = new System.Windows.Forms.Label();
            this.Camera_Y = new System.Windows.Forms.Label();
            this.Camera_X = new System.Windows.Forms.Label();
            this.Measurement = new System.Windows.Forms.GroupBox();
            this.Max = new System.Windows.Forms.Label();
            this.Min = new System.Windows.Forms.Label();
            this.Mean = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.CrossTalkRatio = new System.Windows.Forms.Label();
            this.CTR_Calculate = new System.Windows.Forms.Button();
            this.CameraControll.SuspendLayout();
            this.StageControll.SuspendLayout();
            this.CalibrationControll.SuspendLayout();
            this.Movie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StreamImage)).BeginInit();
            this.CameraPos.SuspendLayout();
            this.Measurement.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraControll
            // 
            this.CameraControll.BackColor = System.Drawing.Color.Black;
            this.CameraControll.Controls.Add(this.EnlargeButton);
            this.CameraControll.Controls.Add(this.ShrinkButton);
            this.CameraControll.Controls.Add(this.PhotoButton);
            this.CameraControll.Controls.Add(this.CapButton);
            this.CameraControll.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CameraControll.ForeColor = System.Drawing.Color.White;
            this.CameraControll.Location = new System.Drawing.Point(12, 12);
            this.CameraControll.Name = "CameraControll";
            this.CameraControll.Size = new System.Drawing.Size(1024, 200);
            this.CameraControll.TabIndex = 0;
            this.CameraControll.TabStop = false;
            this.CameraControll.Text = "CameraControll";
            // 
            // EnlargeButton
            // 
            this.EnlargeButton.BackColor = System.Drawing.Color.Transparent;
            this.EnlargeButton.BackgroundImage = global::CTMeasure.Properties.Resources.Enlarge;
            this.EnlargeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnlargeButton.Location = new System.Drawing.Point(785, 40);
            this.EnlargeButton.Name = "EnlargeButton";
            this.EnlargeButton.Size = new System.Drawing.Size(210, 140);
            this.EnlargeButton.TabIndex = 3;
            this.EnlargeButton.UseVisualStyleBackColor = false;
            this.EnlargeButton.Click += new System.EventHandler(this.EnlargeButton_Click);
            // 
            // ShrinkButton
            // 
            this.ShrinkButton.BackColor = System.Drawing.Color.Transparent;
            this.ShrinkButton.BackgroundImage = global::CTMeasure.Properties.Resources.Shrink;
            this.ShrinkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShrinkButton.Location = new System.Drawing.Point(535, 40);
            this.ShrinkButton.Name = "ShrinkButton";
            this.ShrinkButton.Size = new System.Drawing.Size(210, 140);
            this.ShrinkButton.TabIndex = 2;
            this.ShrinkButton.UseVisualStyleBackColor = false;
            this.ShrinkButton.Click += new System.EventHandler(this.ShrinkButton_Click);
            // 
            // PhotoButton
            // 
            this.PhotoButton.BackColor = System.Drawing.Color.Transparent;
            this.PhotoButton.BackgroundImage = global::CTMeasure.Properties.Resources.Photo;
            this.PhotoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PhotoButton.Location = new System.Drawing.Point(285, 40);
            this.PhotoButton.Name = "PhotoButton";
            this.PhotoButton.Size = new System.Drawing.Size(210, 140);
            this.PhotoButton.TabIndex = 1;
            this.PhotoButton.UseVisualStyleBackColor = false;
            this.PhotoButton.Click += new System.EventHandler(this.PhotoButton_Click);
            // 
            // CapButton
            // 
            this.CapButton.BackColor = System.Drawing.Color.Transparent;
            this.CapButton.BackgroundImage = global::CTMeasure.Properties.Resources.StreamON;
            this.CapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CapButton.Location = new System.Drawing.Point(35, 40);
            this.CapButton.Name = "CapButton";
            this.CapButton.Size = new System.Drawing.Size(210, 140);
            this.CapButton.TabIndex = 0;
            this.CapButton.UseVisualStyleBackColor = false;
            this.CapButton.Click += new System.EventHandler(this.CapButton_Click);
            // 
            // StageControll
            // 
            this.StageControll.Controls.Add(this.YAxis_Value);
            this.StageControll.Controls.Add(this.XAxis_Value);
            this.StageControll.Controls.Add(this.label3);
            this.StageControll.Controls.Add(this.label4);
            this.StageControll.Controls.Add(this.label2);
            this.StageControll.Controls.Add(this.label1);
            this.StageControll.Controls.Add(this.Right);
            this.StageControll.Controls.Add(this.Left);
            this.StageControll.Controls.Add(this.Down);
            this.StageControll.Controls.Add(this.Up);
            this.StageControll.Controls.Add(this.ConnectButton);
            this.StageControll.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StageControll.ForeColor = System.Drawing.Color.White;
            this.StageControll.Location = new System.Drawing.Point(12, 218);
            this.StageControll.Name = "StageControll";
            this.StageControll.Size = new System.Drawing.Size(870, 468);
            this.StageControll.TabIndex = 1;
            this.StageControll.TabStop = false;
            this.StageControll.Text = "StageControll";
            // 
            // YAxis_Value
            // 
            this.YAxis_Value.Location = new System.Drawing.Point(685, 113);
            this.YAxis_Value.Name = "YAxis_Value";
            this.YAxis_Value.Size = new System.Drawing.Size(100, 42);
            this.YAxis_Value.TabIndex = 17;
            this.YAxis_Value.Text = "1";
            this.YAxis_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // XAxis_Value
            // 
            this.XAxis_Value.Location = new System.Drawing.Point(685, 46);
            this.XAxis_Value.Name = "XAxis_Value";
            this.XAxis_Value.Size = new System.Drawing.Size(100, 42);
            this.XAxis_Value.TabIndex = 16;
            this.XAxis_Value.Text = "1";
            this.XAxis_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(791, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 37);
            this.label3.TabIndex = 15;
            this.label3.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(627, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 37);
            this.label4.TabIndex = 14;
            this.label4.Text = "Y :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(791, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 37);
            this.label2.TabIndex = 12;
            this.label2.Text = "mm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(627, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "X :";
            // 
            // Right
            // 
            this.Right.BackColor = System.Drawing.Color.Lime;
            this.Right.BackgroundImage = global::CTMeasure.Properties.Resources.Right;
            this.Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Right.Location = new System.Drawing.Point(522, 176);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(100, 170);
            this.Right.TabIndex = 4;
            this.Right.UseVisualStyleBackColor = false;
            this.Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stage_Right_MouseDown);
            this.Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Stage_Right_MouseUp);
            // 
            // Left
            // 
            this.Left.BackColor = System.Drawing.Color.Lime;
            this.Left.BackgroundImage = global::CTMeasure.Properties.Resources.Left;
            this.Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Left.Location = new System.Drawing.Point(244, 176);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(100, 170);
            this.Left.TabIndex = 3;
            this.Left.UseVisualStyleBackColor = false;
            this.Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stage_Left_MouseDown);
            this.Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Stage_Left_MouseUp);
            // 
            // Down
            // 
            this.Down.BackColor = System.Drawing.Color.Lime;
            this.Down.BackgroundImage = global::CTMeasure.Properties.Resources.Down;
            this.Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Down.Location = new System.Drawing.Point(350, 352);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(170, 100);
            this.Down.TabIndex = 2;
            this.Down.UseVisualStyleBackColor = false;
            this.Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stage_Down_MouseDown);
            this.Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Stage_Down_MouseUp);
            // 
            // Up
            // 
            this.Up.BackColor = System.Drawing.Color.Lime;
            this.Up.BackgroundImage = global::CTMeasure.Properties.Resources.Up;
            this.Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Up.Location = new System.Drawing.Point(350, 80);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(170, 100);
            this.Up.TabIndex = 1;
            this.Up.UseVisualStyleBackColor = false;
            this.Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stage_Up_MouseDown);
            this.Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Stage_Up_MouseUp);
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackgroundImage = global::CTMeasure.Properties.Resources.ConnectON;
            this.ConnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConnectButton.Location = new System.Drawing.Point(6, 41);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(186, 110);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.Connect_Stage_Click);
            // 
            // CalibrationControll
            // 
            this.CalibrationControll.BackColor = System.Drawing.Color.Black;
            this.CalibrationControll.Controls.Add(this.Pattarn);
            this.CalibrationControll.Controls.Add(this.MaxDetectSet);
            this.CalibrationControll.Controls.Add(this.button1);
            this.CalibrationControll.Controls.Add(this.PatternDetect);
            this.CalibrationControll.Controls.Add(this.CalibrationProgress);
            this.CalibrationControll.Controls.Add(this.CamCalibration);
            this.CalibrationControll.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CalibrationControll.ForeColor = System.Drawing.Color.White;
            this.CalibrationControll.Location = new System.Drawing.Point(915, 233);
            this.CalibrationControll.Name = "CalibrationControll";
            this.CalibrationControll.Size = new System.Drawing.Size(977, 163);
            this.CalibrationControll.TabIndex = 5;
            this.CalibrationControll.TabStop = false;
            this.CalibrationControll.Text = "Calibration";
            // 
            // Pattarn
            // 
            this.Pattarn.AutoSize = true;
            this.Pattarn.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Pattarn.Location = new System.Drawing.Point(664, 59);
            this.Pattarn.Name = "Pattarn";
            this.Pattarn.Size = new System.Drawing.Size(135, 37);
            this.Pattarn.TabIndex = 10;
            this.Pattarn.Text = "Pattern";
            // 
            // MaxDetectSet
            // 
            this.MaxDetectSet.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MaxDetectSet.FormattingEnabled = true;
            this.MaxDetectSet.ItemHeight = 35;
            this.MaxDetectSet.Items.AddRange(new object[] {
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80"});
            this.MaxDetectSet.Location = new System.Drawing.Point(821, 53);
            this.MaxDetectSet.Name = "MaxDetectSet";
            this.MaxDetectSet.Size = new System.Drawing.Size(72, 43);
            this.MaxDetectSet.TabIndex = 5;
            this.MaxDetectSet.Text = "40";
            this.MaxDetectSet.SelectedIndexChanged += new System.EventHandler(this.MaxDetectPatternChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::CTMeasure.Properties.Resources.Calibration_Read;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(52, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 102);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ReadCalibrationData);
            // 
            // PatternDetect
            // 
            this.PatternDetect.BackColor = System.Drawing.Color.Transparent;
            this.PatternDetect.BackgroundImage = global::CTMeasure.Properties.Resources.PatternON;
            this.PatternDetect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PatternDetect.Location = new System.Drawing.Point(252, 45);
            this.PatternDetect.Name = "PatternDetect";
            this.PatternDetect.Size = new System.Drawing.Size(170, 102);
            this.PatternDetect.TabIndex = 6;
            this.PatternDetect.UseVisualStyleBackColor = false;
            this.PatternDetect.Click += new System.EventHandler(this.TogglePattern);
            // 
            // CalibrationProgress
            // 
            this.CalibrationProgress.Location = new System.Drawing.Point(657, 108);
            this.CalibrationProgress.Name = "CalibrationProgress";
            this.CalibrationProgress.Size = new System.Drawing.Size(236, 39);
            this.CalibrationProgress.TabIndex = 5;
            // 
            // CamCalibration
            // 
            this.CamCalibration.BackColor = System.Drawing.Color.Transparent;
            this.CamCalibration.BackgroundImage = global::CTMeasure.Properties.Resources.Calibration_Start;
            this.CamCalibration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CamCalibration.Location = new System.Drawing.Point(452, 45);
            this.CamCalibration.Name = "CamCalibration";
            this.CamCalibration.Size = new System.Drawing.Size(170, 102);
            this.CamCalibration.TabIndex = 7;
            this.CamCalibration.UseVisualStyleBackColor = false;
            this.CamCalibration.Click += new System.EventHandler(this.Calibration);
            // 
            // Movie
            // 
            this.Movie.Controls.Add(this.StreamImage);
            this.Movie.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Movie.ForeColor = System.Drawing.Color.White;
            this.Movie.Location = new System.Drawing.Point(915, 421);
            this.Movie.Name = "Movie";
            this.Movie.Size = new System.Drawing.Size(977, 524);
            this.Movie.TabIndex = 6;
            this.Movie.TabStop = false;
            this.Movie.Text = "Movie";
            // 
            // StreamImage
            // 
            this.StreamImage.BackColor = System.Drawing.Color.Transparent;
            this.StreamImage.Location = new System.Drawing.Point(12, 41);
            this.StreamImage.Name = "StreamImage";
            this.StreamImage.Size = new System.Drawing.Size(948, 460);
            this.StreamImage.TabIndex = 2;
            this.StreamImage.TabStop = false;
            this.StreamImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // CameraPos
            // 
            this.CameraPos.Controls.Add(this.Camera_Roll);
            this.CameraPos.Controls.Add(this.Camera_Pitch);
            this.CameraPos.Controls.Add(this.Camera_Yaw);
            this.CameraPos.Controls.Add(this.Camera_Z);
            this.CameraPos.Controls.Add(this.Camera_Y);
            this.CameraPos.Controls.Add(this.Camera_X);
            this.CameraPos.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CameraPos.ForeColor = System.Drawing.Color.White;
            this.CameraPos.Location = new System.Drawing.Point(1053, 12);
            this.CameraPos.Name = "CameraPos";
            this.CameraPos.Size = new System.Drawing.Size(839, 200);
            this.CameraPos.TabIndex = 7;
            this.CameraPos.TabStop = false;
            this.CameraPos.Text = "CameraPoseEstimate";
            // 
            // Camera_Roll
            // 
            this.Camera_Roll.AutoSize = true;
            this.Camera_Roll.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Camera_Roll.Location = new System.Drawing.Point(557, 134);
            this.Camera_Roll.Name = "Camera_Roll";
            this.Camera_Roll.Size = new System.Drawing.Size(92, 33);
            this.Camera_Roll.TabIndex = 5;
            this.Camera_Roll.Text = "Roll : ";
            // 
            // Camera_Pitch
            // 
            this.Camera_Pitch.AutoSize = true;
            this.Camera_Pitch.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Camera_Pitch.Location = new System.Drawing.Point(292, 134);
            this.Camera_Pitch.Name = "Camera_Pitch";
            this.Camera_Pitch.Size = new System.Drawing.Size(112, 33);
            this.Camera_Pitch.TabIndex = 4;
            this.Camera_Pitch.Text = "Pitch : ";
            // 
            // Camera_Yaw
            // 
            this.Camera_Yaw.AutoSize = true;
            this.Camera_Yaw.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Camera_Yaw.Location = new System.Drawing.Point(15, 134);
            this.Camera_Yaw.Name = "Camera_Yaw";
            this.Camera_Yaw.Size = new System.Drawing.Size(97, 33);
            this.Camera_Yaw.TabIndex = 3;
            this.Camera_Yaw.Text = "Yaw : ";
            // 
            // Camera_Z
            // 
            this.Camera_Z.AutoSize = true;
            this.Camera_Z.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Camera_Z.Location = new System.Drawing.Point(557, 58);
            this.Camera_Z.Name = "Camera_Z";
            this.Camera_Z.Size = new System.Drawing.Size(60, 33);
            this.Camera_Z.TabIndex = 2;
            this.Camera_Z.Text = "Z : ";
            // 
            // Camera_Y
            // 
            this.Camera_Y.AutoSize = true;
            this.Camera_Y.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Camera_Y.Location = new System.Drawing.Point(292, 58);
            this.Camera_Y.Name = "Camera_Y";
            this.Camera_Y.Size = new System.Drawing.Size(61, 33);
            this.Camera_Y.TabIndex = 1;
            this.Camera_Y.Text = "Y : ";
            // 
            // Camera_X
            // 
            this.Camera_X.AutoSize = true;
            this.Camera_X.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Camera_X.Location = new System.Drawing.Point(15, 58);
            this.Camera_X.Name = "Camera_X";
            this.Camera_X.Size = new System.Drawing.Size(61, 33);
            this.Camera_X.TabIndex = 0;
            this.Camera_X.Text = "X : ";
            // 
            // Measurement
            // 
            this.Measurement.Controls.Add(this.Max);
            this.Measurement.Controls.Add(this.Min);
            this.Measurement.Controls.Add(this.Mean);
            this.Measurement.Controls.Add(this.button2);
            this.Measurement.Controls.Add(this.CrossTalkRatio);
            this.Measurement.Controls.Add(this.CTR_Calculate);
            this.Measurement.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Measurement.ForeColor = System.Drawing.Color.White;
            this.Measurement.Location = new System.Drawing.Point(18, 692);
            this.Measurement.Name = "Measurement";
            this.Measurement.Size = new System.Drawing.Size(864, 253);
            this.Measurement.TabIndex = 8;
            this.Measurement.TabStop = false;
            this.Measurement.Text = "Measure";
            // 
            // Max
            // 
            this.Max.AutoSize = true;
            this.Max.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Max.Location = new System.Drawing.Point(621, 168);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(183, 37);
            this.Max.TabIndex = 15;
            this.Max.Text = ", Max :      ";
            // 
            // Min
            // 
            this.Min.AutoSize = true;
            this.Min.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Min.Location = new System.Drawing.Point(409, 168);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(175, 37);
            this.Min.TabIndex = 14;
            this.Min.Text = ", Min :      ";
            // 
            // Mean
            // 
            this.Mean.AutoSize = true;
            this.Mean.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mean.Location = new System.Drawing.Point(191, 168);
            this.Mean.Name = "Mean";
            this.Mean.Size = new System.Drawing.Size(185, 37);
            this.Mean.TabIndex = 13;
            this.Mean.Text = "Mean :      ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::CTMeasure.Properties.Resources.Luminance;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(29, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 85);
            this.button2.TabIndex = 12;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.LuminanceMeasure_Click);
            // 
            // CrossTalkRatio
            // 
            this.CrossTalkRatio.AutoSize = true;
            this.CrossTalkRatio.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CrossTalkRatio.Location = new System.Drawing.Point(191, 74);
            this.CrossTalkRatio.Name = "CrossTalkRatio";
            this.CrossTalkRatio.Size = new System.Drawing.Size(323, 37);
            this.CrossTalkRatio.TabIndex = 11;
            this.CrossTalkRatio.Text = "CTR :                  %";
            // 
            // CTR_Calculate
            // 
            this.CTR_Calculate.BackColor = System.Drawing.Color.Transparent;
            this.CTR_Calculate.BackgroundImage = global::CTMeasure.Properties.Resources.CTR;
            this.CTR_Calculate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CTR_Calculate.ForeColor = System.Drawing.Color.White;
            this.CTR_Calculate.Location = new System.Drawing.Point(29, 51);
            this.CTR_Calculate.Name = "CTR_Calculate";
            this.CTR_Calculate.Size = new System.Drawing.Size(128, 85);
            this.CTR_Calculate.TabIndex = 7;
            this.CTR_Calculate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CTR_Calculate.UseVisualStyleBackColor = false;
            this.CTR_Calculate.Click += new System.EventHandler(this.CalcCrosstalkButton_Click);
            // 
            // CrossTalkMeasure
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 961);
            this.Controls.Add(this.Measurement);
            this.Controls.Add(this.CameraPos);
            this.Controls.Add(this.Movie);
            this.Controls.Add(this.CalibrationControll);
            this.Controls.Add(this.StageControll);
            this.Controls.Add(this.CameraControll);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CrossTalkMeasure";
            this.Text = "CrossTalkMeasure";
            this.Load += new System.EventHandler(this.CrossTalkMeasure_Load);
            this.CameraControll.ResumeLayout(false);
            this.StageControll.ResumeLayout(false);
            this.StageControll.PerformLayout();
            this.CalibrationControll.ResumeLayout(false);
            this.CalibrationControll.PerformLayout();
            this.Movie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StreamImage)).EndInit();
            this.CameraPos.ResumeLayout(false);
            this.CameraPos.PerformLayout();
            this.Measurement.ResumeLayout(false);
            this.Measurement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CameraControll;
        private System.Windows.Forms.Button CapButton;
        private System.Windows.Forms.Button PhotoButton;
        private System.Windows.Forms.Button ShrinkButton;
        private System.Windows.Forms.Button EnlargeButton;
        private System.Windows.Forms.GroupBox StageControll;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.PictureBox StreamImage;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button PatternDetect;
        private System.Windows.Forms.Button CamCalibration;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox CalibrationControll;
        private System.Windows.Forms.ProgressBar CalibrationProgress;
        private System.Windows.Forms.ComboBox MaxDetectSet;
        private System.Windows.Forms.Label Pattarn;
        private System.Windows.Forms.GroupBox Movie;
        private System.Windows.Forms.GroupBox CameraPos;
        private System.Windows.Forms.Label Camera_X;
        private System.Windows.Forms.Label Camera_Z;
        private System.Windows.Forms.Label Camera_Y;
        private System.Windows.Forms.Label Camera_Roll;
        private System.Windows.Forms.Label Camera_Pitch;
        private System.Windows.Forms.Label Camera_Yaw;
        private System.Windows.Forms.GroupBox Measurement;
        private System.Windows.Forms.Label CrossTalkRatio;
        private System.Windows.Forms.Button CTR_Calculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox YAxis_Value;
        private System.Windows.Forms.TextBox XAxis_Value;
        private System.Windows.Forms.Label Mean;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Min;
        private System.Windows.Forms.Label Max;
    }
}

