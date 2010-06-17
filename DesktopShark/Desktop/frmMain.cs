using System;
using System.Windows.Forms;
using mshtml;
using System.Runtime.InteropServices;

namespace gs
{
    public partial class FrmMain : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        
        int nav = 0;
        long progress;

        public string Text 
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value;}
        }

        public FrmMain()
        {
            InitializeComponent();
            
        }

        private void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
            nav--;
            if (nav != 0) return;
            var head = wbPlayer.Document.GetElementsByTagName("head")[0];
            var scriptEl = wbPlayer.Document.CreateElement("script");
            var element = (IHTMLScriptElement)scriptEl.DomElement;
            element.src = "http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js";
            head.AppendChild(scriptEl);

            scriptEl = wbPlayer.Document.CreateElement("script");
            element = (IHTMLScriptElement)scriptEl.DomElement;
            element.text = global::DeskShark.Properties.Resources.scriptJs;//"$(document).ready(function (){alert('jQ');});";//Application.StartupPath + @"\script.js";
            head.AppendChild(scriptEl);

            startBuffer.Start();
        }

        private void WebBrowser1Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            nav++;
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            if (progress != 0) return;
            wbPlayer.Show();
            bmpSplash.Hide();
            Text = @"DeskShark";
            startBuffer.Stop();
        }

        private void WebBrowser1ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progress = e.CurrentProgress;
        }

        private void FrmMain_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void wbPlayer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void appLayout_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbMax_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
            pbMax.Image = WindowState == FormWindowState.Normal ? global::DeskShark.Properties.Resources.btn_max : global::DeskShark.Properties.Resources.btn_rest;
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
            trayIco.Visible = !Visible;
        }

        private void appLayout_Panel1_SizeChanged(object sender, EventArgs e)
        {
            pbMax.Image = WindowState == FormWindowState.Normal ? global::DeskShark.Properties.Resources.btn_max : global::DeskShark.Properties.Resources.btn_rest;
        }

    }
}
