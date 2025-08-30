using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CTMeasure
{
    public partial class UIctrl : Form
    {
        public string _ClientInfo;

        // Reset の値
        float lxVal;
        float lyVal;
        float lzVal;
        float rxVal;
        float ryVal;
        float rzVal;
        int picVal;
        int matVal;
        int oriVal;
        int ondotVal;
        float MRatioXVal;
        float MRatioYVal;

        // トラックバー値
        public string _Lx_value;
        public string _Ly_value;
        public string _Lz_value;
        public string _Rx_value;
        public string _Ry_value;
        public string _Rz_value;
        public string _Pic_value;
        public string _Mat_value;
        public string _Ori_value;
        public string _OnDotNum_value;
        public string _MRatioX_value;
        public string _MRatioY_value;

        public UIctrl(string clientInfo,
              string lx, string lx_int,
              string ly, string ly_int,
              string lz, string lz_int,
              string rx, string rx_int,
              string ry, string ry_int,
              string rz, string rz_int,
              string pic, string pic_int,
              string mat, string mat_int,
              string ori, string ori_int,
              string ondotNum, string ondotNum_int,
              string mratioX, string mratioX_int,
              string mratioY, string mratioY_int
            )
        {
            InitializeComponent();

            _ClientInfo = clientInfo;

            // 実数
            float.TryParse(lx, out lxVal);
            float.TryParse(ly, out lyVal);
            float.TryParse(lz, out lzVal);
            float.TryParse(rx, out rxVal);
            float.TryParse(ry, out ryVal);
            float.TryParse(rz, out rzVal);
            float.TryParse(mratioX, out MRatioXVal);
            float.TryParse(mratioY, out MRatioYVal);
            // 整数
            int.TryParse(pic, out picVal);
            int.TryParse(mat, out matVal);
            int.TryParse(ori, out oriVal);
            int.TryParse(ondotNum, out ondotVal);
            // 真偽（"1" / "0" → true / false）
            bool lx_intVal = lx_int == "1";
            bool ly_intVal = ly_int == "1";
            bool lz_intVal = lz_int == "1";
            bool rx_intVal = rx_int == "1";
            bool ry_intVal = ry_int == "1";
            bool rz_intVal = rz_int == "1";
            bool pic_intVal = pic_int == "1";
            bool mat_intVal = mat_int == "1";
            bool ori_intVal = ori_int == "1";
            bool ondotNum_intVal = ondotNum_int == "1";
            bool mratioX_intVal = mratioX_int == "1";
            bool mratioY_intVal = mratioY_int == "1";

            // ------ トラックバーに代入(Int) ------
            // 左目
            Lx_Bar.Value = (int)Math.Round(lxVal * 10);
            Ly_Bar.Value = (int)Math.Round(lyVal * 10);
            Lz_Bar.Value = (int)Math.Round(lzVal * 10);
            // 右目
            Rx_Bar.Value = (int)Math.Round(rxVal * 10);
            Ry_Bar.Value = (int)Math.Round(ryVal * 10);
            Rz_Bar.Value = (int)Math.Round(rzVal * 10);
            // 傾き
            MRatioX_Bar.Value = (int)Math.Round(MRatioXVal * 10);
            MRatioY_Bar.Value = (int)Math.Round(MRatioYVal * 10);
            // その他
            Picture_Bar.Value = picVal;
            Material_Bar.Value = matVal;
            Origin_Bar.Value = oriVal;
            OnDotNum_Bar.Value = ondotVal;

            // ------ テキストボックス表示 ------
            // 左目
            Lx_Box.Text = ((double)lxVal).ToString();
            Ly_Box.Text = ((double)lyVal).ToString();
            Lz_Box.Text = ((double)lzVal).ToString();
            // 右目
            Rx_Box.Text = ((double)rxVal).ToString();
            Ry_Box.Text = ((double)ryVal).ToString();
            Rz_Box.Text = ((double)rzVal).ToString();
            // 傾き
            MRatioX_Box.Text = ((double)MRatioXVal).ToString();
            MRatioY_Box.Text = ((double)MRatioYVal).ToString();
            // その他
            Picture_Box.Text = picVal.ToString();
            Material_Box.Text = matVal.ToString();
            Origin_Box.Text = oriVal.ToString();
            OnDotNum_Box.Text = ondotVal.ToString();

            // ------ チェックボックス代入 ------
            Lx_Int.Checked = lx_intVal;
            Ly_Int.Checked = ly_intVal;
            Lz_Int.Checked = lz_intVal;
            Rx_Int.Checked = rx_intVal;
            Ry_Int.Checked = ry_intVal;
            Rz_Int.Checked = rz_intVal;
            Picture_Int.Checked = pic_intVal;
            Material_Int.Checked = mat_intVal;
            Origin_Int.Checked = ori_intVal;
            OnDotNum_Int.Checked = ondotNum_intVal;
            MRatioX_Int.Checked = mratioX_intVal;
            MRatioY_Int.Checked = mratioY_intVal;
        }


        public void SetClientInfo()
        {
            ClientInfo.Text = _ClientInfo;
        }

        // -------------- トラックバーイベント ------------------
        // 左目
        private void Lx_Bar_Scroll(object sender, EventArgs e)
        {
            if (Lx_Int.Checked)
            {
                Lx_Box.Text = ((int)Lx_Bar.Value / 10).ToString();

            }
            else
            {
                Lx_Box.Text = ((double)Lx_Bar.Value / 10).ToString();
            }   
            SendToClient();
        }

        private void Ly_Bar_Scroll(object sender, EventArgs e)
        {
            if (Ly_Int.Checked)
            {
                Ly_Box.Text = ((int)Ly_Bar.Value / 10).ToString();

            }
            else
            {
                Ly_Box.Text = ((double)Ly_Bar.Value / 10).ToString();
            }
            SendToClient();
        }

        private void Lz_Bar_Scroll(object sender, EventArgs e)
        {
            if (Lz_Int.Checked)
            {
                Lz_Box.Text = ((int)Lz_Bar.Value / 10).ToString();

            }
            else
            {
                Lz_Box.Text = ((double)Lz_Bar.Value / 10).ToString();
            }
            SendToClient();
        }

        // 右目
        private void Rx_Bar_Scroll(object sender, EventArgs e)
        {
            if (Rx_Int.Checked)
            {
                Rx_Box.Text = ((int)Rx_Bar.Value / 10).ToString();

            }
            else
            {
                Rx_Box.Text = ((double)Rx_Bar.Value / 10).ToString();
            }
            SendToClient();
        }

        private void Ry_Bar_Scroll(object sender, EventArgs e)
        {
            if (Ry_Int.Checked)
            {
                Ry_Box.Text = ((int)Ry_Bar.Value / 10).ToString();

            }
            else
            {
                Ry_Box.Text = ((double)Ry_Bar.Value / 10).ToString();
            }
            SendToClient();
        }

        private void Rz_Bar_Scroll(object sender, EventArgs e)
        {
            if (Rz_Int.Checked)
            {
                Rz_Box.Text = ((int)Rz_Bar.Value / 10).ToString();

            }
            else
            {
                Rz_Box.Text = ((double)Rz_Bar.Value / 10).ToString();
            }
            SendToClient();
        }

        // 傾き
        private void MRatioX_Bar_Scroll(object sender, EventArgs e)
        {
            if (MRatioX_Int.Checked)
            {
                MRatioX_Box.Text = ((int)MRatioX_Bar.Value / 10).ToString();

            }
            else
            {
                MRatioX_Box.Text = ((double)MRatioX_Bar.Value / 10).ToString();
            }
            SendToClient();
        }

        private void MRatioY_Bar_Scroll(object sender, EventArgs e)
        {
            if (MRatioY_Int.Checked)
            {
                MRatioY_Box.Text = ((int)MRatioY_Bar.Value / 10).ToString();

            }
            else
            {
                MRatioY_Box.Text = ((double)MRatioY_Bar.Value / 10).ToString();
            }
            SendToClient();
        }

        // その他
        private void Picture_Bar_Scroll(object sender, EventArgs e)
        {
            Picture_Box.Text = Picture_Bar.Value.ToString();
            SendToClient();
        }

        private void Material_Bar_Scroll(object sender, EventArgs e)
        {
            Material_Box.Text = Material_Bar.Value.ToString();
            SendToClient();
        }

        private void Origin_Bar_Scroll(object sender, EventArgs e)
        {
            Origin_Box.Text = Origin_Bar.Value.ToString();
            SendToClient();
        }

        private void OnDotNum_Bar_Scroll(object sender, EventArgs e)
        {
            OnDotNum_Box.Text = OnDotNum_Bar.Value.ToString();
            SendToClient();
        }

        // -------------- トグルイベント --------------
        // UI ON/OFF
        private void UI_toggle_CheckedChanged(object sender, EventArgs e)
        {
            SendToClient();
        }

        // 左目
        private void Lx_Int_CheckedChanged(object sender, EventArgs e)
        {
            if (Lx_Int.Checked)
            {
                // 1刻み = 10単位で動かす（10 = 1.0）
                Lx_Bar.SmallChange = 10;
                Lx_Bar.LargeChange = 10;

                // 端数がある場合は丸める
                Lx_Bar.Value = (int)(Math.Round(Lx_Bar.Value / 10.0) * 10);
            }
            else
            {
                // 0.1刻み = 1単位で動かす（1 = 0.1）
                Lx_Bar.SmallChange = 1;
                Lx_Bar.LargeChange = 1;
            }
            SendToClient();
        }

        private void Ly_Int_CheckedChanged(object sender, EventArgs e)
        {
            if (Ly_Int.Checked)
            {
                // 1刻み = 10単位で動かす（10 = 1.0）
                Ly_Bar.SmallChange = 10;
                Ly_Bar.LargeChange = 10;

                // 端数がある場合は丸める
                Ly_Bar.Value = (int)(Math.Round(Ly_Bar.Value / 10.0) * 10);
            }
            else
            {
                // 0.1刻み = 1単位で動かす（1 = 0.1）
                Ly_Bar.SmallChange = 1;
                Ly_Bar.LargeChange = 1;
            }
            SendToClient();
        }

        private void Lz_Int_CheckedChanged(object sender, EventArgs e)
        {
            if (Lz_Int.Checked)
            {
                // 1刻み = 10単位で動かす（10 = 1.0）
                Lz_Bar.SmallChange = 10;
                Lz_Bar.LargeChange = 10;

                // 端数がある場合は丸める
                Lz_Bar.Value = (int)(Math.Round(Lz_Bar.Value / 10.0) * 10);
            }
            else
            {
                // 0.1刻み = 1単位で動かす（1 = 0.1）
                Lz_Bar.SmallChange = 1;
                Lz_Bar.LargeChange = 1;
            }
            SendToClient();
        }

        // 右目
        private void Rx_Int_CheckedChanged(object sender, EventArgs e)
        {
            if (Rx_Int.Checked)
            {
                // 1刻み = 10単位で動かす（10 = 1.0）
                Rx_Bar.SmallChange = 10;
                Rx_Bar.LargeChange = 10;

                // 端数がある場合は丸める
                Rx_Bar.Value = (int)(Math.Round(Rx_Bar.Value / 10.0) * 10);
            }
            else
            {
                // 0.1刻み = 1単位で動かす（1 = 0.1）
                Rx_Bar.SmallChange = 1;
                Rx_Bar.LargeChange = 1;
            }
            SendToClient();
        }

        private void Ry_Int_CheckedChanged(object sender, EventArgs e)
        {
            if (Ry_Int.Checked)
            {
                // 1刻み = 10単位で動かす（10 = 1.0）
                Ry_Bar.SmallChange = 10;
                Ry_Bar.LargeChange = 10;

                // 端数がある場合は丸める
                Ry_Bar.Value = (int)(Math.Round(Ry_Bar.Value / 10.0) * 10);
            }
            else
            {
                // 0.1刻み = 1単位で動かす（1 = 0.1）
                Ry_Bar.SmallChange = 1;
                Ry_Bar.LargeChange = 1;
            }
            SendToClient();
        }

        private void Rz_Int_CheckedChanged(object sender, EventArgs e)
        {
            if (Rz_Int.Checked)
            {
                // 1刻み = 10単位で動かす（10 = 1.0）
                Rz_Bar.SmallChange = 10;
                Rz_Bar.LargeChange = 10;

                // 端数がある場合は丸める
                Rz_Bar.Value = (int)(Math.Round(Rz_Bar.Value / 10.0) * 10);
            }
            else
            {
                // 0.1刻み = 1単位で動かす（1 = 0.1）
                Rz_Bar.SmallChange = 1;
                Rz_Bar.LargeChange = 1;
            }
            SendToClient();
        }

        // 傾き
        private void MRatioX_Int_CheckedChanged(object sender, EventArgs e)
        {
            if (MRatioX_Int.Checked)
            {
                // 1刻み = 10単位で動かす（10 = 1.0）
                MRatioX_Bar.SmallChange = 10;
                MRatioX_Bar.LargeChange = 10;

                // 端数がある場合は丸める
                MRatioX_Bar.Value = (int)(Math.Round(MRatioX_Bar.Value / 10.0) * 10);
            }
            else
            {
                // 0.1刻み = 1単位で動かす（1 = 0.1）
                MRatioX_Bar.SmallChange = 1;
                MRatioX_Bar.LargeChange = 1;
            }
            SendToClient();
        }

        private void MRatioY_Int_CheckedChanged(object sender, EventArgs e)
        {
            if (MRatioY_Int.Checked)
            {
                // 1刻み = 10単位で動かす（10 = 1.0）
                MRatioY_Bar.SmallChange = 10;
                MRatioY_Bar.LargeChange = 10;

                // 端数がある場合は丸める
                MRatioY_Bar.Value = (int)(Math.Round(MRatioY_Bar.Value / 10.0) * 10);
            }
            else
            {
                // 0.1刻み = 1単位で動かす（1 = 0.1）
                MRatioY_Bar.SmallChange = 1;
                MRatioY_Bar.LargeChange = 1;
            }
            SendToClient();
        }

        // その他
        private void Picture_Int_CheckedChanged(object sender, EventArgs e)
        {
            SendToClient();
        }

        private void Material_Int_CheckedChanged(object sender, EventArgs e)
        {
            SendToClient();
        }

        private void Origin_Int_CheckedChanged(object sender, EventArgs e)
        {
            SendToClient();
        }

        private void OnDotNum_Int_CheckedChanged(object sender, EventArgs e)
        {
            SendToClient();
        }

        // リセットボタン イベント
        private void Lx_Reset_Click(object sender, EventArgs e)
        {
            Lx_Bar.Value = (int)Math.Round(lxVal * 10);
            Lx_Box.Text = ((double)lxVal).ToString();

            SendToClient();
        }

        private void Ly_Reset_Click(object sender, EventArgs e)
        {
            Ly_Bar.Value = (int)Math.Round(lyVal * 10);
            Ly_Box.Text = ((double)lyVal).ToString();

            SendToClient();
        }

        private void Lz_Reset_Click(object sender, EventArgs e)
        {
            Lz_Bar.Value = (int)Math.Round(lzVal * 10);
            Lz_Box.Text = ((double)lzVal).ToString();

            SendToClient();
        }

        private void Rx_Reset_Click(object sender, EventArgs e)
        {
            Rx_Bar.Value = (int)Math.Round(rxVal * 10);
            Rx_Box.Text = ((double)rxVal).ToString();

            SendToClient();
        }

        private void Ry_Reset_Click(object sender, EventArgs e)
        {
            Ry_Bar.Value = (int)Math.Round(ryVal * 10);
            Ry_Box.Text = ((double)ryVal).ToString();

            SendToClient();
        }

        private void Rz_Reset_Click(object sender, EventArgs e)
        {
            Rz_Bar.Value = (int)Math.Round(rzVal * 10);
            Rz_Box.Text = ((double)rzVal).ToString();

            SendToClient();
        }

        private void MRatioX_Reset_Click(object sender, EventArgs e)
        {
            MRatioX_Bar.Value = (int)Math.Round(MRatioXVal * 10);
            MRatioX_Box.Text = ((double)MRatioXVal).ToString();

            SendToClient();
        }

        private void MRatioY_Reset_Click(object sender, EventArgs e)
        {
            MRatioY_Bar.Value = (int)Math.Round(MRatioYVal * 10);
            MRatioY_Box.Text = ((double)MRatioYVal).ToString();

            SendToClient();
        }

        private void Picture_Reset_Click(object sender, EventArgs e)
        {
            Picture_Bar.Value = picVal;
            Picture_Box.Text = picVal.ToString();

            SendToClient();
        }

        private void Material_Reset_Click(object sender, EventArgs e)
        {
            Material_Bar.Value = matVal;
            Material_Box.Text = matVal.ToString();

            SendToClient();
        }

        private void Origin_Reset_Click(object sender, EventArgs e)
        {
            Origin_Bar.Value = oriVal;
            Origin_Box.Text = oriVal.ToString();

            SendToClient();
        }

        private void OnDotNum_Reset_Click(object sender, EventArgs e)
        {
            OnDotNum_Bar.Value = ondotVal;
            OnDotNum_Box.Text = ondotVal.ToString();

            SendToClient();
        }

        // テキストボックス イベント
        private void Lx_Box_TextChanged(object sender, EventArgs e)
        {

        }

        // パラメータ送信
        // ここから↓
        private void SendToClient()
        {
            if (CrossTalkMeasure.lastClient != null)
            {
                string message = "current/"
                    + Lx_Box.Text + "/" + (Lx_Int.Checked ? "1" : "0") + "/"
                    + Ly_Box.Text + "/" + (Ly_Int.Checked ? "1" : "0") + "/"
                    + Lz_Box.Text + "/" + (Lz_Int.Checked ? "1" : "0") + "/"
                    + Rx_Box.Text + "/" + (Rx_Int.Checked ? "1" : "0") + "/"
                    + Ry_Box.Text + "/" + (Ry_Int.Checked ? "1" : "0") + "/"
                    + Rz_Box.Text + "/" + (Rz_Int.Checked ? "1" : "0") + "/"
                    + Picture_Box.Text + "/" + (Picture_Int.Checked ? "1" : "0") + "/"
                    + Material_Box.Text + "/" + (Material_Int.Checked ? "1" : "0") + "/"
                    + Origin_Box.Text + "/" + (Origin_Int.Checked ? "1" : "0") + "/"
                    + OnDotNum_Box.Text + "/" + (OnDotNum_Int.Checked ? "1" : "0") + "/"
                    + MRatioX_Box.Text + "/" + (MRatioX_Int.Checked ? "1" : "0") + "/"
                    + MRatioY_Box.Text + "/" + (MRatioY_Int.Checked ? "1" : "0") + "/"
                    + (UI_toggle.Checked ? "1" : "0") + "\n";

                CrossTalkMeasure.lastClient.ReplyLine(message);
            }
        }
    }
}
