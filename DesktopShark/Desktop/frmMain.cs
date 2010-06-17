using System;
using System.Windows.Forms;
using mshtml;

namespace gs
{
    public partial class FrmMain : Form
    {
        int nav = 0;
        long progress;
        public FrmMain()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            element.text = global::gs.Properties.Resources.scriptJs;//"$(document).ready(function (){alert('jQ');});";//Application.StartupPath + @"\script.js";
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
            Text = @"GrooveShark Desktop";
            startBuffer.Stop();
        }

        private void WebBrowser1ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progress = e.CurrentProgress;
        }

    }
}
