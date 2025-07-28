using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;

namespace CTMeasure
{
    public partial class AddSeriesForm : Form
    {
        public string SeriesName { get; private set; }
        public Brush SelectedColor { get; private set; } = Brushes.Blue;
        public DashStyle SelectedLineStyle { get; private set; } = DashStyles.Solid;

        public AddSeriesForm()
        {
            InitializeComponent();
        }

        // 色選択ボタン
        private void SelectColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ColorPanel.BackColor = dlg.Color;

                    // System.Drawing.Color → System.Windows.Media.Brush に変換
                    SelectedColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                        dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B));
                }
            }
        }

        // OKボタン
        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SeriesNameTextBopx.Text)) // ← 名前は正確に置き換えて
            {
                MessageBox.Show("凡例名を入力してください。", "エラー");
                return;
            }

            SeriesName = SeriesNameTextBopx.Text.Trim();

            // DashStyle の選択肢に対応
            switch (LineStyleComboBox.SelectedItem.ToString()) // ← comboBoxの名前に合わせて修正
            {
                case "実線":
                    SelectedLineStyle = DashStyles.Solid;
                    break;
                case "点線":
                    SelectedLineStyle = DashStyles.Dot;
                    break;
                case "破線":
                    SelectedLineStyle = DashStyles.Dash;
                    break;
                case "一点鎖線":
                    SelectedLineStyle = DashStyles.DashDot;
                    break;
                case "二点鎖線":
                    SelectedLineStyle = DashStyles.DashDotDot;
                    break;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Cancelボタン
        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
