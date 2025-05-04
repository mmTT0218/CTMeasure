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
            this.StreamImage = new System.Windows.Forms.PictureBox();
            this.CameraControll.SuspendLayout();
            this.StageControll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StreamImage)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraControll
            // 
            this.CameraControll.Controls.Add(this.EnlargeButton);
            this.CameraControll.Controls.Add(this.ShrinkButton);
            this.CameraControll.Controls.Add(this.PhotoButton);
            this.CameraControll.Controls.Add(this.CapButton);
            this.CameraControll.Location = new System.Drawing.Point(12, 12);
            this.CameraControll.Name = "CameraControll";
            this.CameraControll.Size = new System.Drawing.Size(1880, 200);
            this.CameraControll.TabIndex = 0;
            this.CameraControll.TabStop = false;
            this.CameraControll.Text = "CameraControll";
            // 
            // EnlargeButton
            // 
            this.EnlargeButton.BackColor = System.Drawing.Color.Transparent;
            this.EnlargeButton.BackgroundImage = global::CTMeasure.Properties.Resources.Enlarge;
            this.EnlargeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnlargeButton.Location = new System.Drawing.Point(846, 20);
            this.EnlargeButton.Name = "EnlargeButton";
            this.EnlargeButton.Size = new System.Drawing.Size(260, 165);
            this.EnlargeButton.TabIndex = 3;
            this.EnlargeButton.UseVisualStyleBackColor = false;
            this.EnlargeButton.Click += new System.EventHandler(this.EnlargeButton_Click);
            // 
            // ShrinkButton
            // 
            this.ShrinkButton.BackColor = System.Drawing.Color.Transparent;
            this.ShrinkButton.BackgroundImage = global::CTMeasure.Properties.Resources.Shrink;
            this.ShrinkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShrinkButton.Location = new System.Drawing.Point(566, 20);
            this.ShrinkButton.Name = "ShrinkButton";
            this.ShrinkButton.Size = new System.Drawing.Size(260, 165);
            this.ShrinkButton.TabIndex = 2;
            this.ShrinkButton.UseVisualStyleBackColor = false;
            this.ShrinkButton.Click += new System.EventHandler(this.ShrinkButton_Click);
            // 
            // PhotoButton
            // 
            this.PhotoButton.BackColor = System.Drawing.Color.Transparent;
            this.PhotoButton.BackgroundImage = global::CTMeasure.Properties.Resources.Photo;
            this.PhotoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PhotoButton.Location = new System.Drawing.Point(286, 20);
            this.PhotoButton.Name = "PhotoButton";
            this.PhotoButton.Size = new System.Drawing.Size(260, 165);
            this.PhotoButton.TabIndex = 1;
            this.PhotoButton.UseVisualStyleBackColor = false;
            this.PhotoButton.Click += new System.EventHandler(this.PhotoButton_Click);
            // 
            // CapButton
            // 
            this.CapButton.BackColor = System.Drawing.Color.Transparent;
            this.CapButton.BackgroundImage = global::CTMeasure.Properties.Resources.StreamON;
            this.CapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CapButton.Location = new System.Drawing.Point(6, 18);
            this.CapButton.Name = "CapButton";
            this.CapButton.Size = new System.Drawing.Size(260, 165);
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
            this.StageControll.Location = new System.Drawing.Point(12, 246);
            this.StageControll.Name = "StageControll";
            this.StageControll.Size = new System.Drawing.Size(934, 703);
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
            this.ConnectButton.Location = new System.Drawing.Point(6, 18);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(220, 149);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.Connect_Stage_Click);
            // 
            // StreamImage
            // 
            this.StreamImage.BackColor = System.Drawing.Color.Transparent;
            this.StreamImage.Location = new System.Drawing.Point(969, 278);
            this.StreamImage.Name = "StreamImage";
            this.StreamImage.Size = new System.Drawing.Size(923, 534);
            this.StreamImage.TabIndex = 2;
            this.StreamImage.TabStop = false;
            this.StreamImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // CrossTalkMeasure
            // 
            this.ClientSize = new System.Drawing.Size(1904, 961);
            this.Controls.Add(this.StreamImage);
            this.Controls.Add(this.StageControll);
            this.Controls.Add(this.CameraControll);
            this.Name = "CrossTalkMeasure";
            this.Text = "CrossTalkMeasure";
            this.Load += new System.EventHandler(this.CrossTalkMeasure_Load);
            this.CameraControll.ResumeLayout(false);
            this.StageControll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StreamImage)).EndInit();
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
    }
}

