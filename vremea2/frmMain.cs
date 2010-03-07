using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace vremea2
{
    public partial class FrmMain : Form
    {
        readonly PictureBox _vr = new PictureBox();
        static int _elapse;
        static bool _doUpdate;

        private const int WmNclbuttondown = 161;
        private const int Htcaption = 2;

        [DllImport("user32.dll")]
        public static extern int SendMessageW(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public FrmMain()
        {
            InitializeComponent();
            Width = BackgroundImage.Width;
            Height = BackgroundImage.Height;
            bgUpdate.RunWorkerAsync();
            updateTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bgGetImage.RunWorkerAsync();
            var wa = Screen.PrimaryScreen.WorkingArea;
            SetBounds(wa.Width - (Width+10), wa.Height - (Height+10), Width, Height);
        }

        private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            _doUpdate = false;
            InWorkShow();
            _vr.Load("http://zeus.eed.usv.ro/~weather/ex1.png");
        }

        private void BgGetImageRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var buff = new Bitmap(_vr.Image);
            var bg = buff.GetPixel(1, 1);
            for (var i = 0; i < buff.Size.Width; i++)
            {
                for (var j = 0; j < buff.Size.Height; j++)
                {
                    var inthebutter = false;
                    if ((j > 380 && i < 100) ||
                        (i > 170 && j > 120 && i < 350 && j < 150) ||
                        (i > 48 && j > 200 && i < 200 && j < 225))
                        inthebutter = true;
                    //else
                    //    inthebutter = false;
                    if (inthebutter)
                        buff.SetPixel(i, j, bg);
                }
            }
            BackgroundImage = buff;
            InWorkHide();
            btbGet.Show();
            _elapse = 600000;
            getTimer.Start();
            _doUpdate = true;
            update.Show();
        }
        #region WorkingDialog
        delegate void WorkingDialogDelagate();
        private void InWorkShow()
        {
            if (inWork.InvokeRequired)
                inWork.Invoke(new WorkingDialogDelagate(InWorkShow));
            else
                inWork.Show();
        }

        private void InWorkHide()
        {
            if (inWork.InvokeRequired)
                inWork.Invoke(new WorkingDialogDelagate(InWorkHide));
            else
                inWork.Hide();
        }
        #endregion
        private void BgGetImageProgressChanged(object sender, ProgressChangedEventArgs e)
        { }

        private void BtnExitClick(object sender, EventArgs e)
        { Close(); }

        private void BtbGetClick(object sender, EventArgs e)
        {
            bgGetImage.RunWorkerAsync();
            btbGet.Hide();
            getTimer.Stop();
            update.Hide();
        }

        private void Label1Click(object sender, EventArgs e)
        {
            modAbout.Hide();
            btnExit.Show();
            btnAbout.Show();
            btbGet.Show();
        }

        private void BtnAboutClick(object sender, EventArgs e)
        {
            modAbout.Show();
            btnAbout.Hide();
            btbGet.Hide();
            btnExit.Hide();
        }

        private void ModAboutVisibleChanged(object sender, EventArgs e)
        { }

        private void GetTimerTick(object sender, EventArgs e)
        {
            bgGetImage.RunWorkerAsync();
            btbGet.Hide();
        }

        private void BgUpdateDoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!_doUpdate) continue;
                System.Threading.Thread.Sleep(1);
                _elapse--;
                //Elapse();
                Application.DoEvents();
            }
        }

        private void UpdateTimerTick(object sender, EventArgs e)
        {
            update.Text = "Update in: " + (int)(_elapse / 1000) / 60 + ":" + (int)(_elapse / 1000) % 60 +" min";
            if(Visible)
                notifyIcon.Text = "Student\'s Weather 2.0\r\nClick to hide"+
                    ( _doUpdate ? "\r\nAutoupdate in: " + (int)(_elapse / 1000) / 60 + ":" + (int)(_elapse / 1000) % 60 + " min" : " ");
            else
                notifyIcon.Text = "Student\'s Weather 2.0\r\nClick to show"+
                    (_doUpdate ? "\r\nAutoupdate in: " + (int)(_elapse / 1000) / 60 + ":" + (int)(_elapse / 1000) % 60 + " min" : " ");
            Application.DoEvents();
        }

        private void Panel1MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessageW(Handle, WmNclbuttondown, Htcaption, 0);
        }

        private void NotifyIconClick(object sender, EventArgs e)
        {
            Visible = !Visible;
        }
    }
}
