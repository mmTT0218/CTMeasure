namespace CTMeasure
{
    partial class UIctrl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lx_Bar = new System.Windows.Forms.TrackBar();
            this.LeftEye = new System.Windows.Forms.GroupBox();
            this.Lz_Int = new System.Windows.Forms.CheckBox();
            this.Lz_Reset = new System.Windows.Forms.Button();
            this.Lz_Box = new System.Windows.Forms.TextBox();
            this.Lz = new System.Windows.Forms.Label();
            this.Lz_Bar = new System.Windows.Forms.TrackBar();
            this.Ly_Int = new System.Windows.Forms.CheckBox();
            this.Ly_Reset = new System.Windows.Forms.Button();
            this.Ly_Box = new System.Windows.Forms.TextBox();
            this.Ly = new System.Windows.Forms.Label();
            this.Ly_Bar = new System.Windows.Forms.TrackBar();
            this.Lx_Int = new System.Windows.Forms.CheckBox();
            this.Lx_Reset = new System.Windows.Forms.Button();
            this.Lx_Box = new System.Windows.Forms.TextBox();
            this.Lx = new System.Windows.Forms.Label();
            this.RightEye = new System.Windows.Forms.GroupBox();
            this.Rz_Int = new System.Windows.Forms.CheckBox();
            this.Rz_Reset = new System.Windows.Forms.Button();
            this.Rz_Box = new System.Windows.Forms.TextBox();
            this.Rz = new System.Windows.Forms.Label();
            this.Rz_Bar = new System.Windows.Forms.TrackBar();
            this.Ry_Int = new System.Windows.Forms.CheckBox();
            this.Ry_Reset = new System.Windows.Forms.Button();
            this.Ry_Box = new System.Windows.Forms.TextBox();
            this.Ry = new System.Windows.Forms.Label();
            this.Ry_Bar = new System.Windows.Forms.TrackBar();
            this.Rx_Int = new System.Windows.Forms.CheckBox();
            this.Rx_Reset = new System.Windows.Forms.Button();
            this.Rx_Box = new System.Windows.Forms.TextBox();
            this.Rx = new System.Windows.Forms.Label();
            this.Rx_Bar = new System.Windows.Forms.TrackBar();
            this.Ex = new System.Windows.Forms.GroupBox();
            this.BarrierPitch_Int = new System.Windows.Forms.CheckBox();
            this.OnDotNum_Int = new System.Windows.Forms.CheckBox();
            this.BarrierPitch_Reset = new System.Windows.Forms.Button();
            this.OnDotNum_Reset = new System.Windows.Forms.Button();
            this.BarrierPitch_Box = new System.Windows.Forms.TextBox();
            this.OnDotNum_Box = new System.Windows.Forms.TextBox();
            this.BarrierPitch = new System.Windows.Forms.Label();
            this.OnDotNum = new System.Windows.Forms.Label();
            this.BarrierPitch_Bar = new System.Windows.Forms.TrackBar();
            this.OnDotNum_Bar = new System.Windows.Forms.TrackBar();
            this.Origin_Int = new System.Windows.Forms.CheckBox();
            this.Origin_Reset = new System.Windows.Forms.Button();
            this.Origin_Box = new System.Windows.Forms.TextBox();
            this.Origin = new System.Windows.Forms.Label();
            this.Origin_Bar = new System.Windows.Forms.TrackBar();
            this.Material_Int = new System.Windows.Forms.CheckBox();
            this.Material_Reset = new System.Windows.Forms.Button();
            this.Material_Box = new System.Windows.Forms.TextBox();
            this.Material = new System.Windows.Forms.Label();
            this.Material_Bar = new System.Windows.Forms.TrackBar();
            this.Picture_Int = new System.Windows.Forms.CheckBox();
            this.Picture_Reset = new System.Windows.Forms.Button();
            this.Picture_Box = new System.Windows.Forms.TextBox();
            this.Picture = new System.Windows.Forms.Label();
            this.Picture_Bar = new System.Windows.Forms.TrackBar();
            this.ClientInfo = new System.Windows.Forms.Label();
            this.UI_toggle = new System.Windows.Forms.CheckBox();
            this.Theta = new System.Windows.Forms.GroupBox();
            this.dTheta_Int = new System.Windows.Forms.CheckBox();
            this.dTheta_Reset = new System.Windows.Forms.Button();
            this.dTheta_Box = new System.Windows.Forms.TextBox();
            this.dTheta = new System.Windows.Forms.Label();
            this.dTheta_Bar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Lx_Bar)).BeginInit();
            this.LeftEye.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lz_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ly_Bar)).BeginInit();
            this.RightEye.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rz_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ry_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rx_Bar)).BeginInit();
            this.Ex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierPitch_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnDotNum_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Origin_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Material_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Bar)).BeginInit();
            this.Theta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTheta_Bar)).BeginInit();
            this.SuspendLayout();
            // 
            // Lx_Bar
            // 
            this.Lx_Bar.Location = new System.Drawing.Point(207, 32);
            this.Lx_Bar.Maximum = 3000;
            this.Lx_Bar.Minimum = -3000;
            this.Lx_Bar.Name = "Lx_Bar";
            this.Lx_Bar.Size = new System.Drawing.Size(278, 45);
            this.Lx_Bar.TabIndex = 0;
            this.Lx_Bar.Scroll += new System.EventHandler(this.Lx_Bar_Scroll);
            // 
            // LeftEye
            // 
            this.LeftEye.Controls.Add(this.Lz_Int);
            this.LeftEye.Controls.Add(this.Lz_Reset);
            this.LeftEye.Controls.Add(this.Lz_Box);
            this.LeftEye.Controls.Add(this.Lz);
            this.LeftEye.Controls.Add(this.Lz_Bar);
            this.LeftEye.Controls.Add(this.Ly_Int);
            this.LeftEye.Controls.Add(this.Ly_Reset);
            this.LeftEye.Controls.Add(this.Ly_Box);
            this.LeftEye.Controls.Add(this.Ly);
            this.LeftEye.Controls.Add(this.Ly_Bar);
            this.LeftEye.Controls.Add(this.Lx_Int);
            this.LeftEye.Controls.Add(this.Lx_Reset);
            this.LeftEye.Controls.Add(this.Lx_Box);
            this.LeftEye.Controls.Add(this.Lx);
            this.LeftEye.Controls.Add(this.Lx_Bar);
            this.LeftEye.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LeftEye.Location = new System.Drawing.Point(15, 84);
            this.LeftEye.Name = "LeftEye";
            this.LeftEye.Size = new System.Drawing.Size(655, 198);
            this.LeftEye.TabIndex = 1;
            this.LeftEye.TabStop = false;
            this.LeftEye.Text = "Eye(L)";
            // 
            // Lz_Int
            // 
            this.Lz_Int.AutoSize = true;
            this.Lz_Int.Location = new System.Drawing.Point(572, 135);
            this.Lz_Int.Name = "Lz_Int";
            this.Lz_Int.Size = new System.Drawing.Size(55, 25);
            this.Lz_Int.TabIndex = 14;
            this.Lz_Int.Text = "Int";
            this.Lz_Int.UseVisualStyleBackColor = true;
            this.Lz_Int.CheckedChanged += new System.EventHandler(this.Lz_Int_CheckedChanged);
            // 
            // Lz_Reset
            // 
            this.Lz_Reset.Location = new System.Drawing.Point(491, 128);
            this.Lz_Reset.Name = "Lz_Reset";
            this.Lz_Reset.Size = new System.Drawing.Size(75, 32);
            this.Lz_Reset.TabIndex = 13;
            this.Lz_Reset.Text = "Reset";
            this.Lz_Reset.UseVisualStyleBackColor = true;
            this.Lz_Reset.Click += new System.EventHandler(this.Lz_Reset_Click);
            // 
            // Lz_Box
            // 
            this.Lz_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Lz_Box.Location = new System.Drawing.Point(107, 131);
            this.Lz_Box.Name = "Lz_Box";
            this.Lz_Box.Size = new System.Drawing.Size(92, 28);
            this.Lz_Box.TabIndex = 12;
            // 
            // Lz
            // 
            this.Lz.AutoSize = true;
            this.Lz.Location = new System.Drawing.Point(16, 135);
            this.Lz.Name = "Lz";
            this.Lz.Size = new System.Drawing.Size(23, 21);
            this.Lz.TabIndex = 11;
            this.Lz.Text = "Z";
            // 
            // Lz_Bar
            // 
            this.Lz_Bar.Location = new System.Drawing.Point(207, 134);
            this.Lz_Bar.Maximum = 10000;
            this.Lz_Bar.Name = "Lz_Bar";
            this.Lz_Bar.Size = new System.Drawing.Size(278, 45);
            this.Lz_Bar.TabIndex = 10;
            this.Lz_Bar.Scroll += new System.EventHandler(this.Lz_Bar_Scroll);
            // 
            // Ly_Int
            // 
            this.Ly_Int.AutoSize = true;
            this.Ly_Int.Location = new System.Drawing.Point(572, 84);
            this.Ly_Int.Name = "Ly_Int";
            this.Ly_Int.Size = new System.Drawing.Size(55, 25);
            this.Ly_Int.TabIndex = 9;
            this.Ly_Int.Text = "Int";
            this.Ly_Int.UseVisualStyleBackColor = true;
            this.Ly_Int.CheckedChanged += new System.EventHandler(this.Ly_Int_CheckedChanged);
            // 
            // Ly_Reset
            // 
            this.Ly_Reset.Location = new System.Drawing.Point(491, 77);
            this.Ly_Reset.Name = "Ly_Reset";
            this.Ly_Reset.Size = new System.Drawing.Size(75, 32);
            this.Ly_Reset.TabIndex = 8;
            this.Ly_Reset.Text = "Reset";
            this.Ly_Reset.UseVisualStyleBackColor = true;
            this.Ly_Reset.Click += new System.EventHandler(this.Ly_Reset_Click);
            // 
            // Ly_Box
            // 
            this.Ly_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ly_Box.Location = new System.Drawing.Point(107, 80);
            this.Ly_Box.Name = "Ly_Box";
            this.Ly_Box.Size = new System.Drawing.Size(92, 28);
            this.Ly_Box.TabIndex = 7;
            // 
            // Ly
            // 
            this.Ly.AutoSize = true;
            this.Ly.Location = new System.Drawing.Point(16, 84);
            this.Ly.Name = "Ly";
            this.Ly.Size = new System.Drawing.Size(23, 21);
            this.Ly.TabIndex = 6;
            this.Ly.Text = "Y";
            // 
            // Ly_Bar
            // 
            this.Ly_Bar.Location = new System.Drawing.Point(207, 83);
            this.Ly_Bar.Maximum = 3000;
            this.Ly_Bar.Minimum = -3000;
            this.Ly_Bar.Name = "Ly_Bar";
            this.Ly_Bar.Size = new System.Drawing.Size(278, 45);
            this.Ly_Bar.TabIndex = 5;
            this.Ly_Bar.Scroll += new System.EventHandler(this.Ly_Bar_Scroll);
            // 
            // Lx_Int
            // 
            this.Lx_Int.AutoSize = true;
            this.Lx_Int.Location = new System.Drawing.Point(572, 33);
            this.Lx_Int.Name = "Lx_Int";
            this.Lx_Int.Size = new System.Drawing.Size(55, 25);
            this.Lx_Int.TabIndex = 4;
            this.Lx_Int.Text = "Int";
            this.Lx_Int.UseVisualStyleBackColor = true;
            this.Lx_Int.CheckedChanged += new System.EventHandler(this.Lx_Int_CheckedChanged);
            // 
            // Lx_Reset
            // 
            this.Lx_Reset.Location = new System.Drawing.Point(491, 26);
            this.Lx_Reset.Name = "Lx_Reset";
            this.Lx_Reset.Size = new System.Drawing.Size(75, 32);
            this.Lx_Reset.TabIndex = 3;
            this.Lx_Reset.Text = "Reset";
            this.Lx_Reset.UseVisualStyleBackColor = true;
            this.Lx_Reset.Click += new System.EventHandler(this.Lx_Reset_Click);
            // 
            // Lx_Box
            // 
            this.Lx_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Lx_Box.Location = new System.Drawing.Point(107, 29);
            this.Lx_Box.Name = "Lx_Box";
            this.Lx_Box.Size = new System.Drawing.Size(92, 28);
            this.Lx_Box.TabIndex = 2;
            // 
            // Lx
            // 
            this.Lx.AutoSize = true;
            this.Lx.Location = new System.Drawing.Point(16, 33);
            this.Lx.Name = "Lx";
            this.Lx.Size = new System.Drawing.Size(24, 21);
            this.Lx.TabIndex = 1;
            this.Lx.Text = "X";
            // 
            // RightEye
            // 
            this.RightEye.Controls.Add(this.Rz_Int);
            this.RightEye.Controls.Add(this.Rz_Reset);
            this.RightEye.Controls.Add(this.Rz_Box);
            this.RightEye.Controls.Add(this.Rz);
            this.RightEye.Controls.Add(this.Rz_Bar);
            this.RightEye.Controls.Add(this.Ry_Int);
            this.RightEye.Controls.Add(this.Ry_Reset);
            this.RightEye.Controls.Add(this.Ry_Box);
            this.RightEye.Controls.Add(this.Ry);
            this.RightEye.Controls.Add(this.Ry_Bar);
            this.RightEye.Controls.Add(this.Rx_Int);
            this.RightEye.Controls.Add(this.Rx_Reset);
            this.RightEye.Controls.Add(this.Rx_Box);
            this.RightEye.Controls.Add(this.Rx);
            this.RightEye.Controls.Add(this.Rx_Bar);
            this.RightEye.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RightEye.Location = new System.Drawing.Point(688, 84);
            this.RightEye.Name = "RightEye";
            this.RightEye.Size = new System.Drawing.Size(655, 198);
            this.RightEye.TabIndex = 15;
            this.RightEye.TabStop = false;
            this.RightEye.Text = "Eye(R)";
            // 
            // Rz_Int
            // 
            this.Rz_Int.AutoSize = true;
            this.Rz_Int.Location = new System.Drawing.Point(586, 136);
            this.Rz_Int.Name = "Rz_Int";
            this.Rz_Int.Size = new System.Drawing.Size(55, 25);
            this.Rz_Int.TabIndex = 14;
            this.Rz_Int.Text = "Int";
            this.Rz_Int.UseVisualStyleBackColor = true;
            this.Rz_Int.CheckedChanged += new System.EventHandler(this.Rz_Int_CheckedChanged);
            // 
            // Rz_Reset
            // 
            this.Rz_Reset.Location = new System.Drawing.Point(505, 129);
            this.Rz_Reset.Name = "Rz_Reset";
            this.Rz_Reset.Size = new System.Drawing.Size(75, 32);
            this.Rz_Reset.TabIndex = 13;
            this.Rz_Reset.Text = "Reset";
            this.Rz_Reset.UseVisualStyleBackColor = true;
            this.Rz_Reset.Click += new System.EventHandler(this.Rz_Reset_Click);
            // 
            // Rz_Box
            // 
            this.Rz_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Rz_Box.Location = new System.Drawing.Point(121, 132);
            this.Rz_Box.Name = "Rz_Box";
            this.Rz_Box.Size = new System.Drawing.Size(92, 28);
            this.Rz_Box.TabIndex = 12;
            // 
            // Rz
            // 
            this.Rz.AutoSize = true;
            this.Rz.Location = new System.Drawing.Point(16, 135);
            this.Rz.Name = "Rz";
            this.Rz.Size = new System.Drawing.Size(23, 21);
            this.Rz.TabIndex = 11;
            this.Rz.Text = "Z";
            // 
            // Rz_Bar
            // 
            this.Rz_Bar.Location = new System.Drawing.Point(221, 135);
            this.Rz_Bar.Maximum = 10000;
            this.Rz_Bar.Name = "Rz_Bar";
            this.Rz_Bar.Size = new System.Drawing.Size(278, 45);
            this.Rz_Bar.TabIndex = 10;
            this.Rz_Bar.Scroll += new System.EventHandler(this.Rz_Bar_Scroll);
            // 
            // Ry_Int
            // 
            this.Ry_Int.AutoSize = true;
            this.Ry_Int.Location = new System.Drawing.Point(586, 85);
            this.Ry_Int.Name = "Ry_Int";
            this.Ry_Int.Size = new System.Drawing.Size(55, 25);
            this.Ry_Int.TabIndex = 9;
            this.Ry_Int.Text = "Int";
            this.Ry_Int.UseVisualStyleBackColor = true;
            this.Ry_Int.CheckedChanged += new System.EventHandler(this.Ry_Int_CheckedChanged);
            // 
            // Ry_Reset
            // 
            this.Ry_Reset.Location = new System.Drawing.Point(505, 78);
            this.Ry_Reset.Name = "Ry_Reset";
            this.Ry_Reset.Size = new System.Drawing.Size(75, 32);
            this.Ry_Reset.TabIndex = 8;
            this.Ry_Reset.Text = "Reset";
            this.Ry_Reset.UseVisualStyleBackColor = true;
            this.Ry_Reset.Click += new System.EventHandler(this.Ry_Reset_Click);
            // 
            // Ry_Box
            // 
            this.Ry_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ry_Box.Location = new System.Drawing.Point(121, 81);
            this.Ry_Box.Name = "Ry_Box";
            this.Ry_Box.Size = new System.Drawing.Size(92, 28);
            this.Ry_Box.TabIndex = 7;
            // 
            // Ry
            // 
            this.Ry.AutoSize = true;
            this.Ry.Location = new System.Drawing.Point(16, 84);
            this.Ry.Name = "Ry";
            this.Ry.Size = new System.Drawing.Size(23, 21);
            this.Ry.TabIndex = 6;
            this.Ry.Text = "Y";
            // 
            // Ry_Bar
            // 
            this.Ry_Bar.Location = new System.Drawing.Point(221, 84);
            this.Ry_Bar.Maximum = 3000;
            this.Ry_Bar.Minimum = -3000;
            this.Ry_Bar.Name = "Ry_Bar";
            this.Ry_Bar.Size = new System.Drawing.Size(278, 45);
            this.Ry_Bar.TabIndex = 5;
            this.Ry_Bar.Scroll += new System.EventHandler(this.Ry_Bar_Scroll);
            // 
            // Rx_Int
            // 
            this.Rx_Int.AutoSize = true;
            this.Rx_Int.Location = new System.Drawing.Point(586, 34);
            this.Rx_Int.Name = "Rx_Int";
            this.Rx_Int.Size = new System.Drawing.Size(55, 25);
            this.Rx_Int.TabIndex = 4;
            this.Rx_Int.Text = "Int";
            this.Rx_Int.UseVisualStyleBackColor = true;
            this.Rx_Int.CheckedChanged += new System.EventHandler(this.Rx_Int_CheckedChanged);
            // 
            // Rx_Reset
            // 
            this.Rx_Reset.Location = new System.Drawing.Point(505, 27);
            this.Rx_Reset.Name = "Rx_Reset";
            this.Rx_Reset.Size = new System.Drawing.Size(75, 32);
            this.Rx_Reset.TabIndex = 3;
            this.Rx_Reset.Text = "Reset";
            this.Rx_Reset.UseVisualStyleBackColor = true;
            this.Rx_Reset.Click += new System.EventHandler(this.Rx_Reset_Click);
            // 
            // Rx_Box
            // 
            this.Rx_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Rx_Box.Location = new System.Drawing.Point(121, 30);
            this.Rx_Box.Name = "Rx_Box";
            this.Rx_Box.Size = new System.Drawing.Size(92, 28);
            this.Rx_Box.TabIndex = 2;
            // 
            // Rx
            // 
            this.Rx.AutoSize = true;
            this.Rx.Location = new System.Drawing.Point(16, 33);
            this.Rx.Name = "Rx";
            this.Rx.Size = new System.Drawing.Size(24, 21);
            this.Rx.TabIndex = 1;
            this.Rx.Text = "X";
            // 
            // Rx_Bar
            // 
            this.Rx_Bar.Location = new System.Drawing.Point(221, 33);
            this.Rx_Bar.Maximum = 3000;
            this.Rx_Bar.Minimum = -3000;
            this.Rx_Bar.Name = "Rx_Bar";
            this.Rx_Bar.Size = new System.Drawing.Size(278, 45);
            this.Rx_Bar.TabIndex = 0;
            this.Rx_Bar.Scroll += new System.EventHandler(this.Rx_Bar_Scroll);
            // 
            // Ex
            // 
            this.Ex.Controls.Add(this.BarrierPitch_Int);
            this.Ex.Controls.Add(this.OnDotNum_Int);
            this.Ex.Controls.Add(this.BarrierPitch_Reset);
            this.Ex.Controls.Add(this.OnDotNum_Reset);
            this.Ex.Controls.Add(this.BarrierPitch_Box);
            this.Ex.Controls.Add(this.OnDotNum_Box);
            this.Ex.Controls.Add(this.BarrierPitch);
            this.Ex.Controls.Add(this.OnDotNum);
            this.Ex.Controls.Add(this.BarrierPitch_Bar);
            this.Ex.Controls.Add(this.OnDotNum_Bar);
            this.Ex.Controls.Add(this.Origin_Int);
            this.Ex.Controls.Add(this.Origin_Reset);
            this.Ex.Controls.Add(this.Origin_Box);
            this.Ex.Controls.Add(this.Origin);
            this.Ex.Controls.Add(this.Origin_Bar);
            this.Ex.Controls.Add(this.Material_Int);
            this.Ex.Controls.Add(this.Material_Reset);
            this.Ex.Controls.Add(this.Material_Box);
            this.Ex.Controls.Add(this.Material);
            this.Ex.Controls.Add(this.Material_Bar);
            this.Ex.Controls.Add(this.Picture_Int);
            this.Ex.Controls.Add(this.Picture_Reset);
            this.Ex.Controls.Add(this.Picture_Box);
            this.Ex.Controls.Add(this.Picture);
            this.Ex.Controls.Add(this.Picture_Bar);
            this.Ex.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ex.Location = new System.Drawing.Point(688, 288);
            this.Ex.Name = "Ex";
            this.Ex.Size = new System.Drawing.Size(655, 301);
            this.Ex.TabIndex = 16;
            this.Ex.TabStop = false;
            this.Ex.Text = "Ex";
            // 
            // BarrierPitch_Int
            // 
            this.BarrierPitch_Int.AutoSize = true;
            this.BarrierPitch_Int.Location = new System.Drawing.Point(586, 237);
            this.BarrierPitch_Int.Name = "BarrierPitch_Int";
            this.BarrierPitch_Int.Size = new System.Drawing.Size(55, 25);
            this.BarrierPitch_Int.TabIndex = 14;
            this.BarrierPitch_Int.Text = "Int";
            this.BarrierPitch_Int.UseVisualStyleBackColor = true;
            // 
            // OnDotNum_Int
            // 
            this.OnDotNum_Int.AutoSize = true;
            this.OnDotNum_Int.Location = new System.Drawing.Point(588, 186);
            this.OnDotNum_Int.Name = "OnDotNum_Int";
            this.OnDotNum_Int.Size = new System.Drawing.Size(55, 25);
            this.OnDotNum_Int.TabIndex = 19;
            this.OnDotNum_Int.Text = "Int";
            this.OnDotNum_Int.UseVisualStyleBackColor = true;
            this.OnDotNum_Int.CheckedChanged += new System.EventHandler(this.OnDotNum_Int_CheckedChanged);
            // 
            // BarrierPitch_Reset
            // 
            this.BarrierPitch_Reset.Location = new System.Drawing.Point(505, 230);
            this.BarrierPitch_Reset.Name = "BarrierPitch_Reset";
            this.BarrierPitch_Reset.Size = new System.Drawing.Size(75, 32);
            this.BarrierPitch_Reset.TabIndex = 13;
            this.BarrierPitch_Reset.Text = "Reset";
            this.BarrierPitch_Reset.UseVisualStyleBackColor = true;
            this.BarrierPitch_Reset.Click += new System.EventHandler(this.BarrierPitch_Reset_Click);
            // 
            // OnDotNum_Reset
            // 
            this.OnDotNum_Reset.Location = new System.Drawing.Point(507, 179);
            this.OnDotNum_Reset.Name = "OnDotNum_Reset";
            this.OnDotNum_Reset.Size = new System.Drawing.Size(75, 32);
            this.OnDotNum_Reset.TabIndex = 18;
            this.OnDotNum_Reset.Text = "Reset";
            this.OnDotNum_Reset.UseVisualStyleBackColor = true;
            this.OnDotNum_Reset.Click += new System.EventHandler(this.OnDotNum_Reset_Click);
            // 
            // BarrierPitch_Box
            // 
            this.BarrierPitch_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BarrierPitch_Box.Location = new System.Drawing.Point(121, 233);
            this.BarrierPitch_Box.Name = "BarrierPitch_Box";
            this.BarrierPitch_Box.Size = new System.Drawing.Size(92, 28);
            this.BarrierPitch_Box.TabIndex = 12;
            // 
            // OnDotNum_Box
            // 
            this.OnDotNum_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OnDotNum_Box.Location = new System.Drawing.Point(123, 182);
            this.OnDotNum_Box.Name = "OnDotNum_Box";
            this.OnDotNum_Box.Size = new System.Drawing.Size(92, 28);
            this.OnDotNum_Box.TabIndex = 17;
            // 
            // BarrierPitch
            // 
            this.BarrierPitch.AutoSize = true;
            this.BarrierPitch.Location = new System.Drawing.Point(38, 236);
            this.BarrierPitch.Name = "BarrierPitch";
            this.BarrierPitch.Size = new System.Drawing.Size(35, 21);
            this.BarrierPitch.TabIndex = 11;
            this.BarrierPitch.Text = "Bp";
            // 
            // OnDotNum
            // 
            this.OnDotNum.AutoSize = true;
            this.OnDotNum.Location = new System.Drawing.Point(6, 189);
            this.OnDotNum.Name = "OnDotNum";
            this.OnDotNum.Size = new System.Drawing.Size(115, 21);
            this.OnDotNum.TabIndex = 16;
            this.OnDotNum.Text = "OnDotNum";
            // 
            // BarrierPitch_Bar
            // 
            this.BarrierPitch_Bar.Location = new System.Drawing.Point(221, 236);
            this.BarrierPitch_Bar.Maximum = 2600000;
            this.BarrierPitch_Bar.Minimum = 2500000;
            this.BarrierPitch_Bar.Name = "BarrierPitch_Bar";
            this.BarrierPitch_Bar.Size = new System.Drawing.Size(278, 45);
            this.BarrierPitch_Bar.TabIndex = 10;
            this.BarrierPitch_Bar.Value = 2500000;
            this.BarrierPitch_Bar.Scroll += new System.EventHandler(this.BarrierPitch_Bar_Scroll);
            // 
            // OnDotNum_Bar
            // 
            this.OnDotNum_Bar.Location = new System.Drawing.Point(223, 185);
            this.OnDotNum_Bar.Maximum = 20;
            this.OnDotNum_Bar.Name = "OnDotNum_Bar";
            this.OnDotNum_Bar.Size = new System.Drawing.Size(278, 45);
            this.OnDotNum_Bar.TabIndex = 15;
            this.OnDotNum_Bar.Scroll += new System.EventHandler(this.OnDotNum_Bar_Scroll);
            // 
            // Origin_Int
            // 
            this.Origin_Int.AutoSize = true;
            this.Origin_Int.Location = new System.Drawing.Point(588, 136);
            this.Origin_Int.Name = "Origin_Int";
            this.Origin_Int.Size = new System.Drawing.Size(55, 25);
            this.Origin_Int.TabIndex = 14;
            this.Origin_Int.Text = "Int";
            this.Origin_Int.UseVisualStyleBackColor = true;
            this.Origin_Int.CheckedChanged += new System.EventHandler(this.Origin_Int_CheckedChanged);
            // 
            // Origin_Reset
            // 
            this.Origin_Reset.Location = new System.Drawing.Point(507, 129);
            this.Origin_Reset.Name = "Origin_Reset";
            this.Origin_Reset.Size = new System.Drawing.Size(75, 32);
            this.Origin_Reset.TabIndex = 13;
            this.Origin_Reset.Text = "Reset";
            this.Origin_Reset.UseVisualStyleBackColor = true;
            this.Origin_Reset.Click += new System.EventHandler(this.Origin_Reset_Click);
            // 
            // Origin_Box
            // 
            this.Origin_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Origin_Box.Location = new System.Drawing.Point(123, 132);
            this.Origin_Box.Name = "Origin_Box";
            this.Origin_Box.Size = new System.Drawing.Size(92, 28);
            this.Origin_Box.TabIndex = 12;
            // 
            // Origin
            // 
            this.Origin.AutoSize = true;
            this.Origin.Location = new System.Drawing.Point(16, 135);
            this.Origin.Name = "Origin";
            this.Origin.Size = new System.Drawing.Size(67, 21);
            this.Origin.TabIndex = 11;
            this.Origin.Text = "Origin";
            // 
            // Origin_Bar
            // 
            this.Origin_Bar.Location = new System.Drawing.Point(223, 135);
            this.Origin_Bar.Maximum = 100;
            this.Origin_Bar.Minimum = -100;
            this.Origin_Bar.Name = "Origin_Bar";
            this.Origin_Bar.Size = new System.Drawing.Size(278, 45);
            this.Origin_Bar.TabIndex = 10;
            this.Origin_Bar.Scroll += new System.EventHandler(this.Origin_Bar_Scroll);
            // 
            // Material_Int
            // 
            this.Material_Int.AutoSize = true;
            this.Material_Int.Location = new System.Drawing.Point(588, 85);
            this.Material_Int.Name = "Material_Int";
            this.Material_Int.Size = new System.Drawing.Size(55, 25);
            this.Material_Int.TabIndex = 9;
            this.Material_Int.Text = "Int";
            this.Material_Int.UseVisualStyleBackColor = true;
            this.Material_Int.CheckedChanged += new System.EventHandler(this.Material_Int_CheckedChanged);
            // 
            // Material_Reset
            // 
            this.Material_Reset.Location = new System.Drawing.Point(507, 78);
            this.Material_Reset.Name = "Material_Reset";
            this.Material_Reset.Size = new System.Drawing.Size(75, 32);
            this.Material_Reset.TabIndex = 8;
            this.Material_Reset.Text = "Reset";
            this.Material_Reset.UseVisualStyleBackColor = true;
            this.Material_Reset.Click += new System.EventHandler(this.Material_Reset_Click);
            // 
            // Material_Box
            // 
            this.Material_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Material_Box.Location = new System.Drawing.Point(123, 81);
            this.Material_Box.Name = "Material_Box";
            this.Material_Box.Size = new System.Drawing.Size(92, 28);
            this.Material_Box.TabIndex = 7;
            // 
            // Material
            // 
            this.Material.AutoSize = true;
            this.Material.Location = new System.Drawing.Point(16, 84);
            this.Material.Name = "Material";
            this.Material.Size = new System.Drawing.Size(87, 21);
            this.Material.TabIndex = 6;
            this.Material.Text = "Material";
            // 
            // Material_Bar
            // 
            this.Material_Bar.Location = new System.Drawing.Point(223, 84);
            this.Material_Bar.Name = "Material_Bar";
            this.Material_Bar.Size = new System.Drawing.Size(278, 45);
            this.Material_Bar.TabIndex = 5;
            this.Material_Bar.Scroll += new System.EventHandler(this.Material_Bar_Scroll);
            // 
            // Picture_Int
            // 
            this.Picture_Int.AutoSize = true;
            this.Picture_Int.Location = new System.Drawing.Point(588, 34);
            this.Picture_Int.Name = "Picture_Int";
            this.Picture_Int.Size = new System.Drawing.Size(55, 25);
            this.Picture_Int.TabIndex = 4;
            this.Picture_Int.Text = "Int";
            this.Picture_Int.UseVisualStyleBackColor = true;
            this.Picture_Int.CheckedChanged += new System.EventHandler(this.Picture_Int_CheckedChanged);
            // 
            // Picture_Reset
            // 
            this.Picture_Reset.Location = new System.Drawing.Point(507, 27);
            this.Picture_Reset.Name = "Picture_Reset";
            this.Picture_Reset.Size = new System.Drawing.Size(75, 32);
            this.Picture_Reset.TabIndex = 3;
            this.Picture_Reset.Text = "Reset";
            this.Picture_Reset.UseVisualStyleBackColor = true;
            this.Picture_Reset.Click += new System.EventHandler(this.Picture_Reset_Click);
            // 
            // Picture_Box
            // 
            this.Picture_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Picture_Box.Location = new System.Drawing.Point(123, 30);
            this.Picture_Box.Name = "Picture_Box";
            this.Picture_Box.Size = new System.Drawing.Size(92, 28);
            this.Picture_Box.TabIndex = 2;
            // 
            // Picture
            // 
            this.Picture.AutoSize = true;
            this.Picture.Location = new System.Drawing.Point(16, 33);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(81, 21);
            this.Picture.TabIndex = 1;
            this.Picture.Text = "Picture";
            // 
            // Picture_Bar
            // 
            this.Picture_Bar.Location = new System.Drawing.Point(223, 33);
            this.Picture_Bar.Name = "Picture_Bar";
            this.Picture_Bar.Size = new System.Drawing.Size(278, 45);
            this.Picture_Bar.TabIndex = 0;
            this.Picture_Bar.Scroll += new System.EventHandler(this.Picture_Bar_Scroll);
            // 
            // ClientInfo
            // 
            this.ClientInfo.AutoSize = true;
            this.ClientInfo.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ClientInfo.Location = new System.Drawing.Point(26, 27);
            this.ClientInfo.Name = "ClientInfo";
            this.ClientInfo.Size = new System.Drawing.Size(167, 37);
            this.ClientInfo.TabIndex = 17;
            this.ClientInfo.Text = "ClientInfo";
            // 
            // UI_toggle
            // 
            this.UI_toggle.AutoSize = true;
            this.UI_toggle.Checked = true;
            this.UI_toggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UI_toggle.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UI_toggle.Location = new System.Drawing.Point(1260, 26);
            this.UI_toggle.Name = "UI_toggle";
            this.UI_toggle.Size = new System.Drawing.Size(69, 41);
            this.UI_toggle.TabIndex = 19;
            this.UI_toggle.Text = "UI";
            this.UI_toggle.UseVisualStyleBackColor = true;
            this.UI_toggle.CheckedChanged += new System.EventHandler(this.UI_toggle_CheckedChanged);
            // 
            // Theta
            // 
            this.Theta.Controls.Add(this.dTheta_Int);
            this.Theta.Controls.Add(this.dTheta_Bar);
            this.Theta.Controls.Add(this.dTheta_Reset);
            this.Theta.Controls.Add(this.dTheta);
            this.Theta.Controls.Add(this.dTheta_Box);
            this.Theta.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Theta.Location = new System.Drawing.Point(15, 288);
            this.Theta.Name = "Theta";
            this.Theta.Size = new System.Drawing.Size(655, 301);
            this.Theta.TabIndex = 20;
            this.Theta.TabStop = false;
            this.Theta.Text = "Theta";
            // 
            // dTheta_Int
            // 
            this.dTheta_Int.AutoSize = true;
            this.dTheta_Int.Location = new System.Drawing.Point(572, 148);
            this.dTheta_Int.Name = "dTheta_Int";
            this.dTheta_Int.Size = new System.Drawing.Size(55, 25);
            this.dTheta_Int.TabIndex = 24;
            this.dTheta_Int.Text = "Int";
            this.dTheta_Int.UseVisualStyleBackColor = true;
            // 
            // dTheta_Reset
            // 
            this.dTheta_Reset.Location = new System.Drawing.Point(491, 141);
            this.dTheta_Reset.Name = "dTheta_Reset";
            this.dTheta_Reset.Size = new System.Drawing.Size(75, 32);
            this.dTheta_Reset.TabIndex = 23;
            this.dTheta_Reset.Text = "Reset";
            this.dTheta_Reset.UseVisualStyleBackColor = true;
            this.dTheta_Reset.Click += new System.EventHandler(this.dTheta_Reset_Click);
            // 
            // dTheta_Box
            // 
            this.dTheta_Box.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dTheta_Box.Location = new System.Drawing.Point(107, 144);
            this.dTheta_Box.Name = "dTheta_Box";
            this.dTheta_Box.Size = new System.Drawing.Size(92, 28);
            this.dTheta_Box.TabIndex = 22;
            // 
            // dTheta
            // 
            this.dTheta.AutoSize = true;
            this.dTheta.Location = new System.Drawing.Point(24, 147);
            this.dTheta.Name = "dTheta";
            this.dTheta.Size = new System.Drawing.Size(77, 21);
            this.dTheta.TabIndex = 21;
            this.dTheta.Text = "dTheta";
            // 
            // dTheta_Bar
            // 
            this.dTheta_Bar.Location = new System.Drawing.Point(207, 147);
            this.dTheta_Bar.Maximum = 2600000;
            this.dTheta_Bar.Minimum = 2500000;
            this.dTheta_Bar.Name = "dTheta_Bar";
            this.dTheta_Bar.Size = new System.Drawing.Size(278, 45);
            this.dTheta_Bar.TabIndex = 20;
            this.dTheta_Bar.Value = 2500000;
            this.dTheta_Bar.Scroll += new System.EventHandler(this.dTheta_Bar_Scroll);
            // 
            // UIctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 601);
            this.Controls.Add(this.Theta);
            this.Controls.Add(this.UI_toggle);
            this.Controls.Add(this.ClientInfo);
            this.Controls.Add(this.Ex);
            this.Controls.Add(this.RightEye);
            this.Controls.Add(this.LeftEye);
            this.Name = "UIctrl";
            this.Text = "UI-ctrl";
            ((System.ComponentModel.ISupportInitialize)(this.Lx_Bar)).EndInit();
            this.LeftEye.ResumeLayout(false);
            this.LeftEye.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lz_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ly_Bar)).EndInit();
            this.RightEye.ResumeLayout(false);
            this.RightEye.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rz_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ry_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rx_Bar)).EndInit();
            this.Ex.ResumeLayout(false);
            this.Ex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierPitch_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnDotNum_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Origin_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Material_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Bar)).EndInit();
            this.Theta.ResumeLayout(false);
            this.Theta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTheta_Bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar Lx_Bar;
        private System.Windows.Forms.GroupBox LeftEye;
        private System.Windows.Forms.CheckBox Lx_Int;
        private System.Windows.Forms.Button Lx_Reset;
        private System.Windows.Forms.TextBox Lx_Box;
        private System.Windows.Forms.Label Lx;
        private System.Windows.Forms.CheckBox Lz_Int;
        private System.Windows.Forms.Button Lz_Reset;
        private System.Windows.Forms.TextBox Lz_Box;
        private System.Windows.Forms.Label Lz;
        private System.Windows.Forms.TrackBar Lz_Bar;
        private System.Windows.Forms.CheckBox Ly_Int;
        private System.Windows.Forms.Button Ly_Reset;
        private System.Windows.Forms.TextBox Ly_Box;
        private System.Windows.Forms.Label Ly;
        private System.Windows.Forms.TrackBar Ly_Bar;
        private System.Windows.Forms.GroupBox RightEye;
        private System.Windows.Forms.CheckBox Rz_Int;
        private System.Windows.Forms.Button Rz_Reset;
        private System.Windows.Forms.TextBox Rz_Box;
        private System.Windows.Forms.Label Rz;
        private System.Windows.Forms.TrackBar Rz_Bar;
        private System.Windows.Forms.CheckBox Ry_Int;
        private System.Windows.Forms.Button Ry_Reset;
        private System.Windows.Forms.TextBox Ry_Box;
        private System.Windows.Forms.Label Ry;
        private System.Windows.Forms.TrackBar Ry_Bar;
        private System.Windows.Forms.CheckBox Rx_Int;
        private System.Windows.Forms.Button Rx_Reset;
        private System.Windows.Forms.TextBox Rx_Box;
        private System.Windows.Forms.Label Rx;
        private System.Windows.Forms.TrackBar Rx_Bar;
        private System.Windows.Forms.GroupBox Ex;
        private System.Windows.Forms.CheckBox Origin_Int;
        private System.Windows.Forms.Button Origin_Reset;
        private System.Windows.Forms.TextBox Origin_Box;
        private System.Windows.Forms.Label Origin;
        private System.Windows.Forms.TrackBar Origin_Bar;
        private System.Windows.Forms.CheckBox Material_Int;
        private System.Windows.Forms.Button Material_Reset;
        private System.Windows.Forms.TextBox Material_Box;
        private System.Windows.Forms.Label Material;
        private System.Windows.Forms.TrackBar Material_Bar;
        private System.Windows.Forms.CheckBox Picture_Int;
        private System.Windows.Forms.Button Picture_Reset;
        private System.Windows.Forms.TextBox Picture_Box;
        private System.Windows.Forms.Label Picture;
        private System.Windows.Forms.TrackBar Picture_Bar;
        private System.Windows.Forms.Label ClientInfo;
        private System.Windows.Forms.CheckBox UI_toggle;
        private System.Windows.Forms.CheckBox OnDotNum_Int;
        private System.Windows.Forms.Button OnDotNum_Reset;
        private System.Windows.Forms.TextBox OnDotNum_Box;
        private System.Windows.Forms.Label OnDotNum;
        private System.Windows.Forms.TrackBar OnDotNum_Bar;
        private System.Windows.Forms.GroupBox Theta;
        private System.Windows.Forms.CheckBox BarrierPitch_Int;
        private System.Windows.Forms.Button BarrierPitch_Reset;
        private System.Windows.Forms.TextBox BarrierPitch_Box;
        private System.Windows.Forms.Label BarrierPitch;
        private System.Windows.Forms.TrackBar BarrierPitch_Bar;
        private System.Windows.Forms.CheckBox dTheta_Int;
        private System.Windows.Forms.TrackBar dTheta_Bar;
        private System.Windows.Forms.Button dTheta_Reset;
        private System.Windows.Forms.Label dTheta;
        private System.Windows.Forms.TextBox dTheta_Box;
    }
}