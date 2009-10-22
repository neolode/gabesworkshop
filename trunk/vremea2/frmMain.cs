using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace vremea2
{
    public partial class frmMain : Form
    {
        PictureBox vr = new PictureBox();
        static int elapse = 0;
        static bool doUpdate = false;

        private const int WM_NCLBUTTONDOWN = 161;
        private const int HTCAPTION = 2;

        [DllImport("user32.dll")]
        public static extern int SendMessageW(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmMain()
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            doUpdate = false;
            InWorkShow();
            vr.Load("http://zeus.eed.usv.ro/~weather/ex1.png");
        }

        private void bgGetImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var buff = new Bitmap(vr.Image);
            var bg = buff.GetPixel(1, 1);
            var inthebutter = false;
            for (var i = 0; i < buff.Size.Width; i++)
            {
                for (var j = 0; j < buff.Size.Height; j++)
                {

                    if ((j > 380 && i < 100) ||
                        (i > 170 && j > 120 && i < 350 && j < 150) ||
                        (i > 48 && j > 200 && i < 200 && j < 225))
                        inthebutter = true;
                    else
                        inthebutter = false;
                    if (inthebutter)
                        buff.SetPixel(i, j, bg);
                }
            }
            BackgroundImage = buff;
            InWorkHide();
            btbGet.Show();
            elapse = 600000;
            getTimer.Start();
            doUpdate = true;
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
        private void bgGetImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { }

        private void btnExit_Click(object sender, EventArgs e)
        { Close(); }

        private void btbGet_Click(object sender, EventArgs e)
        {
            bgGetImage.RunWorkerAsync();
            btbGet.Hide();
            getTimer.Stop();
            update.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            modAbout.Hide();
            btnExit.Show();
            btnAbout.Show();
            btbGet.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            modAbout.Show();
            btnAbout.Hide();
            btbGet.Hide();
            btnExit.Hide();
        }

        private void modAbout_VisibleChanged(object sender, EventArgs e)
        { }

        private void getTimer_Tick(object sender, EventArgs e)
        {
            bgGetImage.RunWorkerAsync();
            btbGet.Hide();
        }

        private void bgUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!doUpdate) continue;
                System.Threading.Thread.Sleep(1);
                elapse--;
                //Elapse();
                Application.DoEvents();
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            update.Text = "Update in: " + (int)(elapse / 1000) / 60 + ":" + (int)(elapse / 1000) % 60 +" min";
            if(Visible)
                notifyIcon.Text = "Student\'s Weather 2.0\r\nClick to hide"+
                    ( doUpdate ? "\r\nAutoupdate in: " + (int)(elapse / 1000) / 60 + ":" + (int)(elapse / 1000) % 60 + " min" : " ");
            else
                notifyIcon.Text = "Student\'s Weather 2.0\r\nClick to show"+
                    (doUpdate ? "\r\nAutoupdate in: " + (int)(elapse / 1000) / 60 + ":" + (int)(elapse / 1000) % 60 + " min" : " ");
            Application.DoEvents();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessageW(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }
    }
}
