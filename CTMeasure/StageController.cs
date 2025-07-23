using System;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using TimersTimer = System.Timers.Timer;

namespace CTMeasure
{
    public class StageController : IDisposable
    {
        private SerialPort stagePort;
        private const string PortName = "COM2";
        private const int BaudRate = 9600;
        private const string Delimiter = "\r\n";
        private const float MoveResolution = 0.004f;
        private string currentCommand = "";
        private TimersTimer moveTimer;

        public bool IsConnected => stagePort != null && stagePort.IsOpen;
        public event Action<string> OnStatusChanged;

        public StageController()
        {
            moveTimer = new TimersTimer(100); // 100ms
            moveTimer.Elapsed += new ElapsedEventHandler(MoveTimer_Elapsed);
        }

        public void Connect()
        {
            if (IsConnected) return;

            stagePort = new SerialPort(PortName, BaudRate, Parity.None, 8, StopBits.One)
            {
                NewLine = Delimiter,
                ReadTimeout = 1000,
                WriteTimeout = 1000
            };

            stagePort.Open();
            OnStatusChanged?.Invoke("connected");
        }

        public void Disconnect()
        {
            if (stagePort != null)
            {
                if (stagePort.IsOpen)
                {
                    stagePort.Close();
                }
                stagePort.Dispose();
                stagePort = null;
                OnStatusChanged?.Invoke("disconnected");
            }
        }

        public void SendCommand(string command)
        {
            if (!IsConnected) return;
            try
            {
                stagePort.WriteLine(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ステージ送信エラー: " + ex.Message);
            }
        }

        private void MoveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentCommand))
                SendCommand(currentCommand);
        }

        public void StartMove(string axis, float value, bool negative)
        {
            int steps = (int)(value / MoveResolution);
            string sign = negative ? "-" : "+";
            currentCommand = $"MGO:{axis}{sign}{steps}";
            moveTimer.Start();
        }

        public void StopMove()
        {
            moveTimer.Stop();
            currentCommand = "";
        }

        public void Dispose()
        {
            moveTimer?.Stop();
            moveTimer?.Dispose();
            Disconnect();
        }
    }
}
