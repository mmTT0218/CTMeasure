namespace CTMeasure
{
    partial class AddSeriesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SeriesNameTextBopx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectColorButton = new System.Windows.Forms.Button();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LineStyleComboBox = new System.Windows.Forms.ComboBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Series Name : ";
            // 
            // SeriesNameTextBopx
            // 
            this.SeriesNameTextBopx.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SeriesNameTextBopx.Location = new System.Drawing.Point(282, 33);
            this.SeriesNameTextBopx.Name = "SeriesNameTextBopx";
            this.SeriesNameTextBopx.Size = new System.Drawing.Size(303, 42);
            this.SeriesNameTextBopx.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(146, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectColorButton
            // 
            this.SelectColorButton.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SelectColorButton.Location = new System.Drawing.Point(282, 88);
            this.SelectColorButton.Name = "SelectColorButton";
            this.SelectColorButton.Size = new System.Drawing.Size(303, 53);
            this.SelectColorButton.TabIndex = 3;
            this.SelectColorButton.Text = "Select Color";
            this.SelectColorButton.UseVisualStyleBackColor = true;
            this.SelectColorButton.Click += new System.EventHandler(this.SelectColorButton_Click);
            // 
            // ColorPanel
            // 
            this.ColorPanel.Location = new System.Drawing.Point(623, 88);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(141, 53);
            this.ColorPanel.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(71, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Line Style : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LineStyleComboBox
            // 
            this.LineStyleComboBox.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LineStyleComboBox.FormattingEnabled = true;
            this.LineStyleComboBox.Items.AddRange(new object[] {
            "実線",
            "点線",
            "破線",
            "一点鎖線",
            "二点鎖線"});
            this.LineStyleComboBox.Location = new System.Drawing.Point(282, 159);
            this.LineStyleComboBox.Name = "LineStyleComboBox";
            this.LineStyleComboBox.Size = new System.Drawing.Size(303, 43);
            this.LineStyleComboBox.TabIndex = 6;
            // 
            // OKbutton
            // 
            this.OKbutton.BackColor = System.Drawing.Color.Red;
            this.OKbutton.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OKbutton.ForeColor = System.Drawing.Color.White;
            this.OKbutton.Location = new System.Drawing.Point(461, 273);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(167, 78);
            this.OKbutton.TabIndex = 7;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.BackColor = System.Drawing.Color.Blue;
            this.Cancelbutton.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancelbutton.ForeColor = System.Drawing.Color.White;
            this.Cancelbutton.Location = new System.Drawing.Point(176, 273);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(167, 78);
            this.Cancelbutton.TabIndex = 8;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = false;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // AddSeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(827, 375);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.LineStyleComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.SelectColorButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SeriesNameTextBopx);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "AddSeriesForm";
            this.Text = "AddSeries";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SeriesNameTextBopx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectColorButton;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox LineStyleComboBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button Cancelbutton;
    }
}