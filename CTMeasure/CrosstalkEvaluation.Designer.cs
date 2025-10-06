namespace CTMeasure
{
    partial class CrosstalkEvaluation
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
            this.Luminance_Start = new System.Windows.Forms.Button();
            this.Luminance_Save = new System.Windows.Forms.Button();
            this.Crosstalk_Save = new System.Windows.Forms.Button();
            this.Crosstalk_Start = new System.Windows.Forms.Button();
            this.ROI_start = new System.Windows.Forms.Button();
            this.ROI_end = new System.Windows.Forms.Button();
            this.Step = new System.Windows.Forms.Label();
            this.StepRange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ROI = new System.Windows.Forms.Label();
            this.deltaROI_X = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deltaROI_Y = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AddGraph_lum = new System.Windows.Forms.Button();
            this.LuminanceChart = new LiveCharts.WinForms.CartesianChart();
            this.AddGraph_ctr = new System.Windows.Forms.Button();
            this.LumSeriesNameComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CrosstalkChart = new LiveCharts.WinForms.CartesianChart();
            this.label9 = new System.Windows.Forms.Label();
            this.CtrSeriesNameComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LTex_ComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RTex_ComboBox = new System.Windows.Forms.ComboBox();
            this.border = new System.Windows.Forms.Label();
            this.CameraMove_D = new System.Windows.Forms.Button();
            this.CameraMove_H = new System.Windows.Forms.Button();
            this.Eyetracking = new System.Windows.Forms.Button();
            this.StopMeasure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Luminance_Start
            // 
            this.Luminance_Start.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Luminance_Start.ForeColor = System.Drawing.Color.Black;
            this.Luminance_Start.Location = new System.Drawing.Point(33, 241);
            this.Luminance_Start.Name = "Luminance_Start";
            this.Luminance_Start.Size = new System.Drawing.Size(124, 67);
            this.Luminance_Start.TabIndex = 1;
            this.Luminance_Start.Text = "LUM";
            this.Luminance_Start.UseVisualStyleBackColor = true;
            this.Luminance_Start.Click += new System.EventHandler(this.Luminance_Start_Click);
            // 
            // Luminance_Save
            // 
            this.Luminance_Save.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Luminance_Save.ForeColor = System.Drawing.Color.Black;
            this.Luminance_Save.Location = new System.Drawing.Point(33, 392);
            this.Luminance_Save.Name = "Luminance_Save";
            this.Luminance_Save.Size = new System.Drawing.Size(124, 67);
            this.Luminance_Save.TabIndex = 2;
            this.Luminance_Save.Text = "Save";
            this.Luminance_Save.UseVisualStyleBackColor = true;
            this.Luminance_Save.Click += new System.EventHandler(this.Luminance_Save_Click);
            // 
            // Crosstalk_Save
            // 
            this.Crosstalk_Save.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Crosstalk_Save.ForeColor = System.Drawing.Color.Black;
            this.Crosstalk_Save.Location = new System.Drawing.Point(33, 682);
            this.Crosstalk_Save.Name = "Crosstalk_Save";
            this.Crosstalk_Save.Size = new System.Drawing.Size(124, 67);
            this.Crosstalk_Save.TabIndex = 5;
            this.Crosstalk_Save.Text = "Save";
            this.Crosstalk_Save.UseVisualStyleBackColor = true;
            this.Crosstalk_Save.Click += new System.EventHandler(this.Crosstalk_Save_Click);
            // 
            // Crosstalk_Start
            // 
            this.Crosstalk_Start.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Crosstalk_Start.ForeColor = System.Drawing.Color.Black;
            this.Crosstalk_Start.Location = new System.Drawing.Point(33, 536);
            this.Crosstalk_Start.Name = "Crosstalk_Start";
            this.Crosstalk_Start.Size = new System.Drawing.Size(124, 67);
            this.Crosstalk_Start.TabIndex = 4;
            this.Crosstalk_Start.Text = "CTR";
            this.Crosstalk_Start.UseVisualStyleBackColor = true;
            this.Crosstalk_Start.Click += new System.EventHandler(this.Crosstalk_Start_Click);
            // 
            // ROI_start
            // 
            this.ROI_start.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ROI_start.ForeColor = System.Drawing.Color.Black;
            this.ROI_start.Location = new System.Drawing.Point(28, 12);
            this.ROI_start.Name = "ROI_start";
            this.ROI_start.Size = new System.Drawing.Size(201, 77);
            this.ROI_start.TabIndex = 6;
            this.ROI_start.Text = "START";
            this.ROI_start.UseVisualStyleBackColor = true;
            this.ROI_start.Click += new System.EventHandler(this.ROI_start_Click);
            // 
            // ROI_end
            // 
            this.ROI_end.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ROI_end.ForeColor = System.Drawing.Color.Black;
            this.ROI_end.Location = new System.Drawing.Point(251, 12);
            this.ROI_end.Name = "ROI_end";
            this.ROI_end.Size = new System.Drawing.Size(201, 77);
            this.ROI_end.TabIndex = 7;
            this.ROI_end.Text = "END";
            this.ROI_end.UseVisualStyleBackColor = true;
            this.ROI_end.Click += new System.EventHandler(this.ROI_end_Click);
            // 
            // Step
            // 
            this.Step.AutoSize = true;
            this.Step.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Step.ForeColor = System.Drawing.Color.White;
            this.Step.Location = new System.Drawing.Point(465, 59);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(155, 29);
            this.Step.TabIndex = 12;
            this.Step.Text = "Distance : ";
            // 
            // StepRange
            // 
            this.StepRange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepRange.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StepRange.FormattingEnabled = true;
            this.StepRange.ItemHeight = 27;
            this.StepRange.Items.AddRange(new object[] {
            "50",
            "60",
            "70",
            "80",
            "90",
            "100",
            "110",
            "120",
            "130",
            "140",
            "150"});
            this.StepRange.Location = new System.Drawing.Point(626, 53);
            this.StepRange.Name = "StepRange";
            this.StepRange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StepRange.Size = new System.Drawing.Size(196, 35);
            this.StepRange.TabIndex = 11;
            this.StepRange.Text = "70";
            this.StepRange.SelectedIndexChanged += new System.EventHandler(this.StepRange_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(828, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 27);
            this.label1.TabIndex = 13;
            this.label1.Text = "mm";
            // 
            // ROI
            // 
            this.ROI.AutoSize = true;
            this.ROI.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ROI.ForeColor = System.Drawing.Color.White;
            this.ROI.Location = new System.Drawing.Point(501, 16);
            this.ROI.Name = "ROI";
            this.ROI.Size = new System.Drawing.Size(119, 29);
            this.ROI.TabIndex = 14;
            this.ROI.Text = "ΔROI : ";
            // 
            // deltaROI_X
            // 
            this.deltaROI_X.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deltaROI_X.Location = new System.Drawing.Point(640, 11);
            this.deltaROI_X.Name = "deltaROI_X";
            this.deltaROI_X.Size = new System.Drawing.Size(129, 34);
            this.deltaROI_X.TabIndex = 15;
            this.deltaROI_X.Text = "0";
            this.deltaROI_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(958, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 27);
            this.label3.TabIndex = 16;
            this.label3.Text = "pixel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1156, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 27);
            this.label2.TabIndex = 19;
            this.label2.Text = "mm";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(1025, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 34);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(919, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Step : ";
            // 
            // deltaROI_Y
            // 
            this.deltaROI_Y.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deltaROI_Y.Location = new System.Drawing.Point(796, 11);
            this.deltaROI_Y.Name = "deltaROI_Y";
            this.deltaROI_Y.Size = new System.Drawing.Size(129, 34);
            this.deltaROI_Y.TabIndex = 20;
            this.deltaROI_Y.Text = "0";
            this.deltaROI_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(772, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 27);
            this.label5.TabIndex = 21;
            this.label5.Text = ",";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(616, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 27);
            this.label6.TabIndex = 22;
            this.label6.Text = "(";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(931, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 27);
            this.label7.TabIndex = 23;
            this.label7.Text = ")";
            // 
            // AddGraph_lum
            // 
            this.AddGraph_lum.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AddGraph_lum.ForeColor = System.Drawing.Color.Black;
            this.AddGraph_lum.Location = new System.Drawing.Point(33, 314);
            this.AddGraph_lum.Name = "AddGraph_lum";
            this.AddGraph_lum.Size = new System.Drawing.Size(124, 67);
            this.AddGraph_lum.TabIndex = 25;
            this.AddGraph_lum.Text = "Add";
            this.AddGraph_lum.UseVisualStyleBackColor = true;
            this.AddGraph_lum.Click += new System.EventHandler(this.AddGraph_lum_Click);
            // 
            // LuminanceChart
            // 
            this.LuminanceChart.BackColor = System.Drawing.Color.White;
            this.LuminanceChart.ForeColor = System.Drawing.Color.White;
            this.LuminanceChart.Location = new System.Drawing.Point(215, 241);
            this.LuminanceChart.Name = "LuminanceChart";
            this.LuminanceChart.Size = new System.Drawing.Size(1098, 218);
            this.LuminanceChart.TabIndex = 24;
            this.LuminanceChart.Text = "cartesianChart1";
            // 
            // AddGraph_ctr
            // 
            this.AddGraph_ctr.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AddGraph_ctr.ForeColor = System.Drawing.Color.Black;
            this.AddGraph_ctr.Location = new System.Drawing.Point(33, 609);
            this.AddGraph_ctr.Name = "AddGraph_ctr";
            this.AddGraph_ctr.Size = new System.Drawing.Size(124, 67);
            this.AddGraph_ctr.TabIndex = 26;
            this.AddGraph_ctr.Text = "Add";
            this.AddGraph_ctr.UseVisualStyleBackColor = true;
            this.AddGraph_ctr.Click += new System.EventHandler(this.AddGraph_ctr_Click);
            // 
            // LumSeriesNameComboBox
            // 
            this.LumSeriesNameComboBox.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LumSeriesNameComboBox.FormattingEnabled = true;
            this.LumSeriesNameComboBox.Location = new System.Drawing.Point(962, 203);
            this.LumSeriesNameComboBox.Name = "LumSeriesNameComboBox";
            this.LumSeriesNameComboBox.Size = new System.Drawing.Size(208, 32);
            this.LumSeriesNameComboBox.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(761, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 29);
            this.label8.TabIndex = 28;
            this.label8.Text = "SeriesName : ";
            // 
            // CrosstalkChart
            // 
            this.CrosstalkChart.BackColor = System.Drawing.Color.White;
            this.CrosstalkChart.ForeColor = System.Drawing.Color.White;
            this.CrosstalkChart.Location = new System.Drawing.Point(215, 536);
            this.CrosstalkChart.Name = "CrosstalkChart";
            this.CrosstalkChart.Size = new System.Drawing.Size(1098, 218);
            this.CrosstalkChart.TabIndex = 29;
            this.CrosstalkChart.Text = "cartesianChart1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(761, 495);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 29);
            this.label9.TabIndex = 31;
            this.label9.Text = "SeriesName : ";
            // 
            // CtrSeriesNameComboBox
            // 
            this.CtrSeriesNameComboBox.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CtrSeriesNameComboBox.FormattingEnabled = true;
            this.CtrSeriesNameComboBox.Location = new System.Drawing.Point(962, 492);
            this.CtrSeriesNameComboBox.Name = "CtrSeriesNameComboBox";
            this.CtrSeriesNameComboBox.Size = new System.Drawing.Size(208, 32);
            this.CtrSeriesNameComboBox.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(218, 495);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 29);
            this.label10.TabIndex = 33;
            this.label10.Text = "L :";
            // 
            // LTex_ComboBox
            // 
            this.LTex_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LTex_ComboBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LTex_ComboBox.FormattingEnabled = true;
            this.LTex_ComboBox.ItemHeight = 27;
            this.LTex_ComboBox.Items.AddRange(new object[] {
            "黒",
            "白"});
            this.LTex_ComboBox.Location = new System.Drawing.Point(271, 489);
            this.LTex_ComboBox.Name = "LTex_ComboBox";
            this.LTex_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LTex_ComboBox.Size = new System.Drawing.Size(114, 35);
            this.LTex_ComboBox.TabIndex = 32;
            this.LTex_ComboBox.Text = "黒";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(400, 495);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 29);
            this.label11.TabIndex = 35;
            this.label11.Text = "R :";
            // 
            // RTex_ComboBox
            // 
            this.RTex_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTex_ComboBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RTex_ComboBox.FormattingEnabled = true;
            this.RTex_ComboBox.ItemHeight = 27;
            this.RTex_ComboBox.Items.AddRange(new object[] {
            "白",
            "黒"});
            this.RTex_ComboBox.Location = new System.Drawing.Point(455, 489);
            this.RTex_ComboBox.Name = "RTex_ComboBox";
            this.RTex_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RTex_ComboBox.Size = new System.Drawing.Size(114, 35);
            this.RTex_ComboBox.TabIndex = 34;
            this.RTex_ComboBox.Text = "白";
            // 
            // border
            // 
            this.border.AutoSize = true;
            this.border.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.border.ForeColor = System.Drawing.Color.White;
            this.border.Location = new System.Drawing.Point(23, 109);
            this.border.Name = "border";
            this.border.Size = new System.Drawing.Size(1277, 29);
            this.border.TabIndex = 36;
            this.border.Text = "-------------------------------------------------------------------------------";
            // 
            // CameraMove_D
            // 
            this.CameraMove_D.BackColor = System.Drawing.Color.Transparent;
            this.CameraMove_D.BackgroundImage = global::CTMeasure.Properties.Resources.CameraTrackingOFF_Depth;
            this.CameraMove_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CameraMove_D.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CameraMove_D.ForeColor = System.Drawing.Color.Black;
            this.CameraMove_D.Location = new System.Drawing.Point(271, 141);
            this.CameraMove_D.Name = "CameraMove_D";
            this.CameraMove_D.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CameraMove_D.Size = new System.Drawing.Size(97, 78);
            this.CameraMove_D.TabIndex = 39;
            this.CameraMove_D.UseVisualStyleBackColor = false;
            this.CameraMove_D.Click += new System.EventHandler(this.CameraMove_D_Click);
            // 
            // CameraMove_H
            // 
            this.CameraMove_H.BackColor = System.Drawing.Color.Transparent;
            this.CameraMove_H.BackgroundImage = global::CTMeasure.Properties.Resources.CameraTrackingOFF_Horizontal;
            this.CameraMove_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CameraMove_H.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CameraMove_H.ForeColor = System.Drawing.Color.Black;
            this.CameraMove_H.Location = new System.Drawing.Point(153, 143);
            this.CameraMove_H.Name = "CameraMove_H";
            this.CameraMove_H.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CameraMove_H.Size = new System.Drawing.Size(97, 78);
            this.CameraMove_H.TabIndex = 38;
            this.CameraMove_H.UseVisualStyleBackColor = false;
            this.CameraMove_H.Click += new System.EventHandler(this.CameraMove_H_Click);
            // 
            // Eyetracking
            // 
            this.Eyetracking.BackColor = System.Drawing.Color.Transparent;
            this.Eyetracking.BackgroundImage = global::CTMeasure.Properties.Resources.EyetrackingON;
            this.Eyetracking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Eyetracking.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Eyetracking.ForeColor = System.Drawing.Color.Black;
            this.Eyetracking.Location = new System.Drawing.Point(33, 143);
            this.Eyetracking.Name = "Eyetracking";
            this.Eyetracking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Eyetracking.Size = new System.Drawing.Size(97, 78);
            this.Eyetracking.TabIndex = 37;
            this.Eyetracking.UseVisualStyleBackColor = false;
            this.Eyetracking.Click += new System.EventHandler(this.Eyetracking_Click);
            // 
            // StopMeasure
            // 
            this.StopMeasure.BackColor = System.Drawing.Color.Transparent;
            this.StopMeasure.BackgroundImage = global::CTMeasure.Properties.Resources.StopMeasure;
            this.StopMeasure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StopMeasure.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StopMeasure.ForeColor = System.Drawing.Color.Black;
            this.StopMeasure.Location = new System.Drawing.Point(393, 141);
            this.StopMeasure.Name = "StopMeasure";
            this.StopMeasure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StopMeasure.Size = new System.Drawing.Size(97, 78);
            this.StopMeasure.TabIndex = 40;
            this.StopMeasure.UseVisualStyleBackColor = false;
            this.StopMeasure.Click += new System.EventHandler(this.StopMeasure_Click);
            // 
            // CrosstalkEvaluation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1347, 769);
            this.Controls.Add(this.StopMeasure);
            this.Controls.Add(this.CameraMove_D);
            this.Controls.Add(this.CameraMove_H);
            this.Controls.Add(this.Eyetracking);
            this.Controls.Add(this.border);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.RTex_ComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LTex_ComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CtrSeriesNameComboBox);
            this.Controls.Add(this.CrosstalkChart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LumSeriesNameComboBox);
            this.Controls.Add(this.AddGraph_ctr);
            this.Controls.Add(this.AddGraph_lum);
            this.Controls.Add(this.LuminanceChart);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.deltaROI_Y);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deltaROI_X);
            this.Controls.Add(this.ROI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Step);
            this.Controls.Add(this.StepRange);
            this.Controls.Add(this.ROI_end);
            this.Controls.Add(this.ROI_start);
            this.Controls.Add(this.Crosstalk_Save);
            this.Controls.Add(this.Crosstalk_Start);
            this.Controls.Add(this.Luminance_Save);
            this.Controls.Add(this.Luminance_Start);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CrosstalkEvaluation";
            this.Text = "CrossTalkEvaluatiobn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Luminance_Start;
        private System.Windows.Forms.Button Luminance_Save;
        private System.Windows.Forms.Button Crosstalk_Save;
        private System.Windows.Forms.Button Crosstalk_Start;
        private System.Windows.Forms.Button ROI_start;
        private System.Windows.Forms.Button ROI_end;
        private System.Windows.Forms.Label Step;
        private System.Windows.Forms.ComboBox StepRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ROI;
        private System.Windows.Forms.TextBox deltaROI_X;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox deltaROI_Y;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AddGraph_lum;
        private LiveCharts.WinForms.CartesianChart LuminanceChart;
        private System.Windows.Forms.Button AddGraph_ctr;
        private System.Windows.Forms.ComboBox LumSeriesNameComboBox;
        private System.Windows.Forms.Label label8;
        private LiveCharts.WinForms.CartesianChart CrosstalkChart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CtrSeriesNameComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox LTex_ComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox RTex_ComboBox;
        private System.Windows.Forms.Label border;
        private System.Windows.Forms.Button CameraMove_H;
        private System.Windows.Forms.Button CameraMove_D;
        private System.Windows.Forms.Button Eyetracking;
        private System.Windows.Forms.Button StopMeasure;
    }
}