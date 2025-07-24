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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Luminance_Start = new System.Windows.Forms.Button();
            this.Luminance_Save = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Crosstalk_Save = new System.Windows.Forms.Button();
            this.Crosstalk_Start = new System.Windows.Forms.Button();
            this.ROI_start = new System.Windows.Forms.Button();
            this.ROI_end = new System.Windows.Forms.Button();
            this.Step = new System.Windows.Forms.Label();
            this.StepRange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ROI = new System.Windows.Forms.Label();
            this.deltaROI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(251, 99);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(981, 274);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Luminance_Start
            // 
            this.Luminance_Start.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Luminance_Start.Location = new System.Drawing.Point(28, 145);
            this.Luminance_Start.Name = "Luminance_Start";
            this.Luminance_Start.Size = new System.Drawing.Size(201, 77);
            this.Luminance_Start.TabIndex = 1;
            this.Luminance_Start.Text = "LUM";
            this.Luminance_Start.UseVisualStyleBackColor = true;
            // 
            // Luminance_Save
            // 
            this.Luminance_Save.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Luminance_Save.Location = new System.Drawing.Point(28, 242);
            this.Luminance_Save.Name = "Luminance_Save";
            this.Luminance_Save.Size = new System.Drawing.Size(201, 77);
            this.Luminance_Save.TabIndex = 2;
            this.Luminance_Save.Text = "Save";
            this.Luminance_Save.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(251, 388);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(981, 274);
            this.chart2.TabIndex = 3;
            this.chart2.Text = "chart2";
            // 
            // Crosstalk_Save
            // 
            this.Crosstalk_Save.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Crosstalk_Save.Location = new System.Drawing.Point(28, 541);
            this.Crosstalk_Save.Name = "Crosstalk_Save";
            this.Crosstalk_Save.Size = new System.Drawing.Size(201, 77);
            this.Crosstalk_Save.TabIndex = 5;
            this.Crosstalk_Save.Text = "Save";
            this.Crosstalk_Save.UseVisualStyleBackColor = true;
            // 
            // Crosstalk_Start
            // 
            this.Crosstalk_Start.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Crosstalk_Start.Location = new System.Drawing.Point(28, 442);
            this.Crosstalk_Start.Name = "Crosstalk_Start";
            this.Crosstalk_Start.Size = new System.Drawing.Size(201, 77);
            this.Crosstalk_Start.TabIndex = 4;
            this.Crosstalk_Start.Text = "CTR";
            this.Crosstalk_Start.UseVisualStyleBackColor = true;
            // 
            // ROI_start
            // 
            this.ROI_start.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80"});
            this.StepRange.Location = new System.Drawing.Point(626, 53);
            this.StepRange.Name = "StepRange";
            this.StepRange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StepRange.Size = new System.Drawing.Size(107, 35);
            this.StepRange.TabIndex = 11;
            this.StepRange.Text = "70";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(739, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 27);
            this.label1.TabIndex = 13;
            this.label1.Text = "mm";
            // 
            // ROI
            // 
            this.ROI.AutoSize = true;
            this.ROI.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ROI.Location = new System.Drawing.Point(501, 16);
            this.ROI.Name = "ROI";
            this.ROI.Size = new System.Drawing.Size(119, 29);
            this.ROI.TabIndex = 14;
            this.ROI.Text = "ΔROI : ";
            // 
            // deltaROI
            // 
            this.deltaROI.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deltaROI.Location = new System.Drawing.Point(640, 11);
            this.deltaROI.Name = "deltaROI";
            this.deltaROI.Size = new System.Drawing.Size(129, 34);
            this.deltaROI.TabIndex = 15;
            this.deltaROI.Text = "0";
            this.deltaROI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.label2.Location = new System.Drawing.Point(1052, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 27);
            this.label2.TabIndex = 19;
            this.label2.Text = "mm";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(921, 55);
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
            this.label4.Location = new System.Drawing.Point(815, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Step : ";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(796, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(129, 34);
            this.textBox2.TabIndex = 20;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.label7.Location = new System.Drawing.Point(931, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 27);
            this.label7.TabIndex = 23;
            this.label7.Text = ")";
            // 
            // CrosstalkEvaluation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 674);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deltaROI);
            this.Controls.Add(this.ROI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Step);
            this.Controls.Add(this.StepRange);
            this.Controls.Add(this.ROI_end);
            this.Controls.Add(this.ROI_start);
            this.Controls.Add(this.Crosstalk_Save);
            this.Controls.Add(this.Crosstalk_Start);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.Luminance_Save);
            this.Controls.Add(this.Luminance_Start);
            this.Controls.Add(this.chart1);
            this.Name = "CrosstalkEvaluation";
            this.Text = "CrossTalkEvaluatiobn";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Luminance_Start;
        private System.Windows.Forms.Button Luminance_Save;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button Crosstalk_Save;
        private System.Windows.Forms.Button Crosstalk_Start;
        private System.Windows.Forms.Button ROI_start;
        private System.Windows.Forms.Button ROI_end;
        private System.Windows.Forms.Label Step;
        private System.Windows.Forms.ComboBox StepRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ROI;
        private System.Windows.Forms.TextBox deltaROI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}