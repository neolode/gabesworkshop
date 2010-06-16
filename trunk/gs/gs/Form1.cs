using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using mshtml;

namespace gs
{
    public partial class Form1 : Form
    {
        int nav = 0;
        int navs = 0;
        long progress;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void gweb_Navigated(object sender, Skybound.Gecko.GeckoNavigatedEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
            nav--;
            if (nav != 0) return;
            HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            element.src = "http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js";
            head.AppendChild(scriptEl);

            scriptEl = webBrowser1.Document.CreateElement("script");
            element = (IHTMLScriptElement)scriptEl.DomElement;
            element.text = global::gs.Properties.Resources.scriptJs;//"$(document).ready(function (){alert('jQ');});";//Application.StartupPath + @"\script.js";
            head.AppendChild(scriptEl);
            timer1.Start();

                

        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            nav++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progress != 0) return;
            webBrowser1.Show();
            pictureBox1.Hide();
            Text = "GrooveShark Desktop";
            timer1.Stop();
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progress = e.CurrentProgress;
        }

    }
}
