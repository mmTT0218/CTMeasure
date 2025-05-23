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
            this.Right = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CamCalibration = new System.Windows.Forms.Button();
            this.PatternDetect = new System.Windows.Forms.Button();
            this.StreamImage = new System.Windows.Forms.PictureBox();
            this.CalibrationControll = new System.Windows.Forms.GroupBox();
            this.MaxDetectSet = new System.Windows.Forms.ComboBox();
            this.CalibrationProgress = new System.Windows.Forms.ProgressBar();
            this.Pattarn = new System.Windows.Forms.Label();
            this.Movie = new System.Windows.Forms.GroupBox();
            this.CameraControll.SuspendLayout();
            this.StageControll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StreamImage)).BeginInit();
            this.CalibrationControll.SuspendLayout();
            this.Movie.SuspendLayout();
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
            this.CameraControll.Location = new System.Drawing.Point(18, 12);
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
            this.StageControll.Controls.Add(this.Right);
            this.StageControll.Controls.Add(this.Left);
            this.StageControll.Controls.Add(this.Down);
            this.StageControll.Controls.Add(this.Up);
            this.StageControll.Controls.Add(this.ConnectButton);
            this.StageControll.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StageControll.ForeColor = System.Drawing.Color.White;
            this.StageControll.Location = new System.Drawing.Point(12, 218);
            this.StageControll.Name = "StageControll";
            this.StageControll.Size = new System.Drawing.Size(934, 731);
            this.StageControll.TabIndex = 1;
            this.StageControll.TabStop = false;
            this.StageControll.Text = "StageControll";
            // 
            // Right
            // 
            this.Right.BackColor = System.Drawing.Color.Lime;
            this.Right.BackgroundImage = global::CTMeasure.Properties.Resources.Right;
            this.Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Right.Location = new System.Drawing.Point(550, 360);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(220, 149);
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
            this.Left.Location = new System.Drawing.Point(97, 360);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(220, 149);
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
            this.Down.Location = new System.Drawing.Point(326, 529);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(220, 149);
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
            this.Up.Location = new System.Drawing.Point(326, 190);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(220, 149);
            this.Up.TabIndex = 1;
            this.Up.UseVisualStyleBackColor = false;
            this.Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stage_Up_MouseDown);
            this.Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Stage_Up_MouseUp);
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackgroundImage = global::CTMeasure.Properties.Resources.ConnectON;
            this.ConnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConnectButton.Location = new System.Drawing.Point(20, 52);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(220, 149);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.Connect_Stage_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::CTMeasure.Properties.Resources.Calibration_Read;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(30, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 102);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ReadCalibrationData);
            // 
            // CamCalibration
            // 
            this.CamCalibration.BackColor = System.Drawing.Color.Transparent;
            this.CamCalibration.BackgroundImage = global::CTMeasure.Properties.Resources.Calibration_Start;
            this.CamCalibration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CamCalibration.Location = new System.Drawing.Point(430, 45);
            this.CamCalibration.Name = "CamCalibration";
            this.CamCalibration.Size = new System.Drawing.Size(170, 102);
            this.CamCalibration.TabIndex = 7;
            this.CamCalibration.UseVisualStyleBackColor = false;
            this.CamCalibration.Click += new System.EventHandler(this.Calibration);
            // 
            // PatternDetect
            // 
            this.PatternDetect.BackColor = System.Drawing.Color.Transparent;
            this.PatternDetect.BackgroundImage = global::CTMeasure.Properties.Resources.PatternON;
            this.PatternDetect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PatternDetect.Location = new System.Drawing.Point(230, 45);
            this.PatternDetect.Name = "PatternDetect";
            this.PatternDetect.Size = new System.Drawing.Size(170, 102);
            this.PatternDetect.TabIndex = 6;
            this.PatternDetect.UseVisualStyleBackColor = false;
            this.PatternDetect.Click += new System.EventHandler(this.TogglePattern);
            // 
            // StreamImage
            // 
            this.StreamImage.BackColor = System.Drawing.Color.Transparent;
            this.StreamImage.Location = new System.Drawing.Point(12, 41);
            this.StreamImage.Name = "StreamImage";
            this.StreamImage.Size = new System.Drawing.Size(899, 460);
            this.StreamImage.TabIndex = 2;
            this.StreamImage.TabStop = false;
            this.StreamImage.Click += new System.EventHandler(this.StreamImage_Click);
            this.StreamImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
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
            this.CalibrationControll.Location = new System.Drawing.Point(969, 218);
            this.CalibrationControll.Name = "CalibrationControll";
            this.CalibrationControll.Size = new System.Drawing.Size(923, 163);
            this.CalibrationControll.TabIndex = 5;
            this.CalibrationControll.TabStop = false;
            this.CalibrationControll.Text = "Calibration";
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
            this.MaxDetectSet.Location = new System.Drawing.Point(809, 52);
            this.MaxDetectSet.Name = "MaxDetectSet";
            this.MaxDetectSet.Size = new System.Drawing.Size(72, 43);
            this.MaxDetectSet.TabIndex = 5;
            this.MaxDetectSet.Text = "40";
            this.MaxDetectSet.SelectedIndexChanged += new System.EventHandler(this.MaxDetectPatternChanged);
            // 
            // CalibrationProgress
            // 
            this.CalibrationProgress.Location = new System.Drawing.Point(657, 108);
            this.CalibrationProgress.Name = "CalibrationProgress";
            this.CalibrationProgress.Size = new System.Drawing.Size(236, 39);
            this.CalibrationProgress.TabIndex = 5;
            // 
            // Pattarn
            // 
            this.Pattarn.AutoSize = true;
            this.Pattarn.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Pattarn.Location = new System.Drawing.Point(668, 53);
            this.Pattarn.Name = "Pattarn";
            this.Pattarn.Size = new System.Drawing.Size(135, 37);
            this.Pattarn.TabIndex = 10;
            this.Pattarn.Text = "Pattern";
            // 
            // Movie
            // 
            this.Movie.Controls.Add(this.StreamImage);
            this.Movie.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Movie.ForeColor = System.Drawing.Color.White;
            this.Movie.Location = new System.Drawing.Point(969, 409);
            this.Movie.Name = "Movie";
            this.Movie.Size = new System.Drawing.Size(923, 522);
            this.Movie.TabIndex = 6;
            this.Movie.TabStop = false;
            this.Movie.Text = "Movie";
            // 
            // CrossTalkMeasure
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 961);
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
            ((System.ComponentModel.ISupportInitialize)(this.StreamImage)).EndInit();
            this.CalibrationControll.ResumeLayout(false);
            this.CalibrationControll.PerformLayout();
            this.Movie.ResumeLayout(false);
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
    }
}

