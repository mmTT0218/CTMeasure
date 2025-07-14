using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTMeasure
{
    public partial class UIctrl : Form
    {
        public string _ClientInfo;

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

        public UIctrl(string clientInfo,
              string lx, string lx_int,
              string ly, string ly_int,
              string lz, string lz_int,
              string rx, string rx_int,
              string ry, string ry_int,
              string rz, string rz_int,
              string pic, string pic_int,
              string mat, string mat_int,
              string ori, string ori_int
            )
        {
            InitializeComponent();

            _ClientInfo = clientInfo;

            // 実数
            float.TryParse(lx, out float lxVal);
            float.TryParse(ly, out float lyVal);
            float.TryParse(lz, out float lzVal);
            float.TryParse(rx, out float rxVal);
            float.TryParse(ry, out float ryVal);
            float.TryParse(rz, out float rzVal);
            // 整数
            int.TryParse(pic, out int picVal);
            int.TryParse(mat, out int matVal);
            int.TryParse(ori, out int oriVal);
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

            // トラックバーに代入(Int)
            Lx_Bar.Value = (int)Math.Round(lxVal * 10);
            Ly_Bar.Value = (int)Math.Round(lyVal * 10);
            Lz_Bar.Value = (int)Math.Round(lzVal * 10);

            Rx_Bar.Value = (int)Math.Round(rxVal * 10);
            Ry_Bar.Value = (int)Math.Round(ryVal * 10);
            Rz_Bar.Value = (int)Math.Round(rzVal * 10);

            Picture_Bar.Value = picVal;
            Material_Bar.Value = matVal;
            Origin_Bar.Value = oriVal;

            // テキストボックス表示
            Lx_Box.Text = ((double)lxVal).ToString();
            Ly_Box.Text = ((double)lyVal).ToString();
            Lz_Box.Text = ((double)lzVal).ToString();

            Rx_Box.Text = ((double)rxVal).ToString();
            Ry_Box.Text = ((double)ryVal).ToString();
            Rz_Box.Text = ((double)rzVal).ToString();

            Picture_Box.Text = picVal.ToString();
            Material_Box.Text = matVal.ToString();
            Origin_Box.Text = oriVal.ToString();

            // チェックボックス代入
            Lx_Int.Checked = lx_intVal;
            Ly_Int.Checked = ly_intVal;
            Lz_Int.Checked = lz_intVal;
            Rx_Int.Checked = rx_intVal;
            Ry_Int.Checked = ry_intVal;
            Rz_Int.Checked = rz_intVal;
            Picture_Int.Checked = pic_intVal;
            Material_Int.Checked = mat_intVal;
            Origin_Int.Checked = ori_intVal;
        }


        public void SetClientInfo()
        {
            ClientInfo.Text = _ClientInfo;
        }

        // -------------- トラックバーイベント ------------------
        private void Lx_Bar_Scroll(object sender, EventArgs e)
        {
            Lx_Box.Text = ((double)Lx_Bar.Value / 10).ToString();
            SendToClient();
        }

        private void Ly_Bar_Scroll(object sender, EventArgs e)
        {
            Ly_Box.Text = ((double)Ly_Bar.Value / 10).ToString();
            SendToClient();
        }

        private void Lz_Bar_Scroll(object sender, EventArgs e)
        {
            Lz_Box.Text = ((double)Lz_Bar.Value / 10).ToString();
            SendToClient();
        }

        private void Rx_Bar_Scroll(object sender, EventArgs e)
        {
            Rx_Box.Text = ((double)Rx_Bar.Value / 10).ToString();
            SendToClient();
        }

        private void Ry_Bar_Scroll(object sender, EventArgs e)
        {
            Ry_Box.Text = ((double)Ry_Bar.Value / 10).ToString();
            SendToClient();
        }

        private void Rz_Bar_Scroll(object sender, EventArgs e)
        {
            Rz_Box.Text = ((double)Rz_Bar.Value / 10).ToString();
            SendToClient();
        }

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

        // パラメータ送信
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
                    + Origin_Box.Text + "/" + (Origin_Int.Checked ? "1" : "0") + "/\n";

                CrossTalkMeasure.lastClient.ReplyLine(message);
            }
        }
    }
}
