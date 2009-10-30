using System;
using System.Text;
using System.Windows.Forms;

namespace miniws
{
    public partial class LogViewer : Form, ILogListener
    {
        private StringBuilder _logMesage;
        public bool CanClose { get; set; }
        private const string Tfiller = "         ";
        public LogViewer()
        {
            InitializeComponent();
        }

        public void writeChars(char[] buffer, int nr, int read)
        {
            _logMesage = new StringBuilder(read + 1);
            var stamped = false;
            for (var i = 0; i < read; i++)
                _logMesage.Append(buffer[i]);
            var raw = _logMesage.ToString();
            var stamp = raw.Substring(0, 9);
            var message = raw.Substring(9).Split('\n');
            foreach (var s in message)
            {
                if (s == string.Empty) continue;
                Log(stamped ? Tfiller : stamp, s);
                stamped = true;
            }
        }

        delegate void DelegateLog(String timestamp, String mesage);
        private void Log(String timestamp, String mesage)
        {
            try
            {
                if (lstLog.InvokeRequired)
                {
                    DelegateLog d = Log;
                    Invoke(d, new object[] { timestamp, mesage });
                }
                else
                {
                    lstLog.Items.Add(timestamp + mesage);
                }
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch { }
            // ReSharper restore EmptyGeneralCatchClause
        }

        private void LogViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CanClose) return;
            e.Cancel = true;
            Hide();
        }
    }
}