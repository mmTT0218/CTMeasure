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
using TextBox = System.Windows.Forms.TextBox;

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
        float BarrierPitchVal;
        float dThetaVal; // ★追加: Thetaの初期値用

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
        public string _BarrierPitch_value;

        // TextBoxの値反映フラグ
        private bool _isSyncingUI = false;

        // ---- Barrier Pitch slider scaling (7桁小数 = 0.0000001 mm/step) ----
        const int BP_SCALE = 10000000; // 1 tick = 0.0000001 mm
        const double BP_MIN = 0.2500000;
        const double BP_MAX = 0.2560000;

        // ★追加: Theta slider scaling (0.01度精度)
        const int THETA_SCALE = 100;

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
              string dtheta = "0", string dtheta_int = "0"
            )
        {
            InitializeComponent();

            WireTextBoxToBarConfirmOnly(Lx_Box, Lx_Bar, 10, Lx_Int);
            WireTextBoxToBarConfirmOnly(Ly_Box, Ly_Bar, 10, Ly_Int);
            WireTextBoxToBarConfirmOnly(Lz_Box, Lz_Bar, 10, Lz_Int);

            WireTextBoxToBarConfirmOnly(Rx_Box, Rx_Bar, 10, Rx_Int);
            WireTextBoxToBarConfirmOnly(Ry_Box, Ry_Bar, 10, Ry_Int);
            WireTextBoxToBarConfirmOnly(Rz_Box, Rz_Bar, 10, Rz_Int);

            WireTextBoxToBarConfirmOnly(Picture_Box, Picture_Bar, 1, Picture_Int);
            WireTextBoxToBarConfirmOnly(Material_Box, Material_Bar, 1, Material_Int);
            WireTextBoxToBarConfirmOnly(Origin_Box, Origin_Bar, 1, Origin_Int);
            WireTextBoxToBarConfirmOnly(OnDotNum_Box, OnDotNum_Bar, 1, OnDotNum_Int);

            WireTextBoxToBarConfirmOnly(BarrierPitch_Box, BarrierPitch_Bar, BP_SCALE, null);

            // ★追加: Theta用のTextBox連携 (Scale 100)
            WireTextBoxToBarConfirmOnly(dTheta_Box, dTheta_Bar, THETA_SCALE, dTheta_Int);

            _ClientInfo = clientInfo;

            // Barrier Pitch設定
            BarrierPitch_Bar.Minimum = (int)Math.Round(BP_MIN * BP_SCALE);
            BarrierPitch_Bar.Maximum = (int)Math.Round(BP_MAX * BP_SCALE);
            BarrierPitch_Bar.SmallChange = 1;    // 0.0000001 mm
            BarrierPitch_Bar.LargeChange = 100;  // 0.0000100 mm

            // ★追加: Theta Bar設定 (-2.00度 ～ +2.00度)
            dTheta_Bar.Minimum = -500;
            dTheta_Bar.Maximum = 500;
            dTheta_Bar.SmallChange = 1; // 0.01度
            dTheta_Bar.LargeChange = 10; // 0.1度

            // 実数
            float.TryParse(lx, out lxVal);
            float.TryParse(ly, out lyVal);
            float.TryParse(lz, out lzVal);
            float.TryParse(rx, out rxVal);
            float.TryParse(ry, out ryVal);
            float.TryParse(rz, out rzVal);
            float.TryParse(dtheta, out dThetaVal); // ★追加
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
            bool dtheta_intVal = dtheta_int == "1"; // ★追加

            // ------ UI初期化 ------
            // 左目
            Lx_Bar.Value = (int)Math.Round(lxVal * 10);
            Ly_Bar.Value = (int)Math.Round(lyVal * 10);
            Lz_Bar.Value = (int)Math.Round(lzVal * 10);
            // 右目
            Rx_Bar.Value = (int)Math.Round(rxVal * 10);
            Ry_Bar.Value = (int)Math.Round(ryVal * 10);
            Rz_Bar.Value = (int)Math.Round(rzVal * 10);
            // その他
            Picture_Bar.Value = picVal;
            Material_Bar.Value = matVal;
            Origin_Bar.Value = oriVal;
            OnDotNum_Bar.Value = ondotVal;
            int bpInit = (int)Math.Round(BarrierPitchVal * BP_SCALE);
            bpInit = Math.Max(BarrierPitch_Bar.Minimum, Math.Min(BarrierPitch_Bar.Maximum, bpInit));
            BarrierPitch_Bar.Value = bpInit;
            // ★追加: Theta Bar初期値
            int thetaInit = (int)Math.Round(dThetaVal * THETA_SCALE);
            thetaInit = Math.Max(dTheta_Bar.Minimum, Math.Min(dTheta_Bar.Maximum, thetaInit));
            dTheta_Bar.Value = thetaInit;

            // ------ テキストボックス表示 ------
            // 左目
            Lx_Box.Text = ((double)lxVal).ToString();
            Ly_Box.Text = ((double)lyVal).ToString();
            Lz_Box.Text = ((double)lzVal).ToString();
            // 右目
            Rx_Box.Text = ((double)rxVal).ToString();
            Ry_Box.Text = ((double)ryVal).ToString();
            Rz_Box.Text = ((double)rzVal).ToString();
            // その他
            Picture_Box.Text = picVal.ToString();
            Material_Box.Text = matVal.ToString();
            Origin_Box.Text = oriVal.ToString();
            OnDotNum_Box.Text = ondotVal.ToString();
            BarrierPitch_Box.Text = (BarrierPitch_Bar.Value / (double)BP_SCALE).ToString("F7");
            // ★追加
            dTheta_Box.Text = ((double)dThetaVal).ToString("F2");

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
            dTheta_Int.Checked = dtheta_intVal; // ★追加
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

        // ★追加: Theta Bar スクロールイベント
        private void dTheta_Bar_Scroll(object sender, EventArgs e)
        {
            // 値を更新 (scale 100 なので 0.01単位)
            dTheta_Box.Text = ((double)dTheta_Bar.Value / (double)THETA_SCALE).ToString("F2");
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

        private void BarrierPitch_Bar_Scroll(object sender, EventArgs e)
        {
            BarrierPitch_Box.Text = (BarrierPitch_Bar.Value / (double)BP_SCALE).ToString("F7");
            SendToClient();
        }

        // -------------- トラックバーイベント ------------------

        // -------------- トグルイベント --------------
        // 共通化メソッド
        private void ToggleIntMode(System.Windows.Forms.TrackBar bar, CheckBox checkBox, int scale)
        {
            if (checkBox.Checked)
            {
                bar.SmallChange = scale;
                bar.LargeChange = scale;
                // 端数丸め
                bar.Value = (int)(Math.Round((double)bar.Value / scale) * scale);
            }
            else
            {
                bar.SmallChange = 1;
                bar.LargeChange = 1;
            }
        }

        // UI ON/OFF
        private void UI_toggle_CheckedChanged(object sender, EventArgs e)
        {
            SendToClient();
        }

        // 左目
        private void Lx_Int_CheckedChanged(object sender, EventArgs e)
        {
            ToggleIntMode(Lx_Bar, Lx_Int, 10);
            SendToClient();
        }

        private void Ly_Int_CheckedChanged(object sender, EventArgs e)
        {
            ToggleIntMode(Ly_Bar, Ly_Int, 10);
            SendToClient();
        }

        private void Lz_Int_CheckedChanged(object sender, EventArgs e)
        {
            ToggleIntMode(Lz_Bar, Lz_Int, 10);
            SendToClient();
        }

        // 右目
        private void Rx_Int_CheckedChanged(object sender, EventArgs e)
        {
            ToggleIntMode(Rx_Bar, Rx_Int, 10);
            SendToClient();
        }

        private void Ry_Int_CheckedChanged(object sender, EventArgs e)
        {
            ToggleIntMode(Ry_Bar, Ry_Int, 10);
            SendToClient();
        }

        private void Rz_Int_CheckedChanged(object sender, EventArgs e)
        {
            ToggleIntMode(Rz_Bar, Rz_Int, 10);
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

        // -------------- リセットボタン イベント --------------
        // 左目
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
        // 右目
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

        // その他
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

        private void BarrierPitch_Reset_Click(object sender, EventArgs e)
        {
            int v = (int)Math.Round(BarrierPitchVal * BP_SCALE);
            v = Math.Max(BarrierPitch_Bar.Minimum, Math.Min(BarrierPitch_Bar.Maximum, v));
            BarrierPitch_Bar.Value = v;
            BarrierPitch_Box.Text = (v / (double)BP_SCALE).ToString("F7");
            SendToClient();
        }

        // ★追加: Theta Reset
        private void dTheta_Reset_Click(object sender, EventArgs e)
        {
            int v = (int)Math.Round(dThetaVal * THETA_SCALE);
            v = Math.Max(dTheta_Bar.Minimum, Math.Min(dTheta_Bar.Maximum, v));
            dTheta_Bar.Value = v;
            dTheta_Box.Text = ((double)dThetaVal).ToString("F2");

            SendToClient();
        }

        // テキストボックス イベント
        // 確定時のみ TextBox → TrackBar に反映
        private void WireTextBoxToBarConfirmOnly(TextBox box, System.Windows.Forms.TrackBar bar, double scale, CheckBox intCheck = null)
        {
            void Commit()
            {
                if (_isSyncingUI) return;

                // 空や未完成（"-"など）は無視
                if (!double.TryParse(box.Text, out double v)) return;

                // IntチェックがONなら整数丸め
                if (intCheck != null && intCheck.Checked) v = Math.Round(v);

                // スケール適用（例：10倍、100000倍など）
                int target = (int)Math.Round(v * scale);

                // TrackBar範囲にクリップ
                target = Math.Max(bar.Minimum, Math.Min(bar.Maximum, target));

                _isSyncingUI = true;
                if (bar.Value != target) bar.Value = target;
                _isSyncingUI = false;

                // ProgrammaticなValue変更では Scroll が走らない想定なので送信
                SendToClient();
            }

            // Enterで確定
            box.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // ビープ抑止
                    Commit();
                }
            };

            // フォーカスが外れた時も確定
            box.Leave += (s, e) => Commit();
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
                    + Origin_Box.Text + "/" + (Origin_Int.Checked ? "1" : "0") + "/"
                    + OnDotNum_Box.Text + "/" + (OnDotNum_Int.Checked ? "1" : "0") + "/"
                    + dTheta_Box.Text + "/"
                    + (UI_toggle.Checked ? "1" : "0") + "\n";

                CrossTalkMeasure.lastClient.ReplyLine(message);
            }
        }
    }
}
