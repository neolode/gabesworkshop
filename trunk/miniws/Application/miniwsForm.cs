using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace miniws
{
    public partial class miniwsForm : Form
    {
        private Uri ourUri;
        private Process mysqlProcess;
        private Form splash;
        private LogViewer logViewer;
        // Construction de la fenêtre principale
        public miniwsForm()
        {
            logViewer = new LogViewer();
            ConsoleRedirector.attach(logViewer);

            // Si un mysql tourne déjà il n'est pas à nous
            //mysqlProcess = null;

            // Pour l'instant on n'existe pas
            this.Enabled = false;
            
            // Gooo !
            InitializeComponent();
        }

        // Est ce que ce MySQL 4 ou 5 tourne ??
        //private bool isMySQLRunning()
        //{
        //    Process[] p;
        //    p = Process.GetProcessesByName("mysqld");
        //    if (p.Length <= 0)
        //    {
        //        p = Process.GetProcessesByName("mysqld-max");
        //    }
        //    return (p.Length > 0);
        //}

        // Gazzzzz ! Fait péter le browser !
        private void Form1_Load(object sender, EventArgs e)
        {
            String UriStr = @"http://127.0.0.1";//miniws.Properties.Settings.Default.HomeUrl;
            int port;

            // On voit si on a un mysql à démarrer
            //if (!isMySQLRunning() && File.Exists("mysql_start.bat"))
            //{
            //    ProcessStartInfo psi = new ProcessStartInfo("mysql_start.bat");
            //    psi.CreateNoWindow = true;
            //    psi.UseShellExecute = false;
            //    psi.ErrorDialog = false;
            //    mysqlProcess = Process.Start(psi);
            //}

            // Lancement de ZazouMiniWebServer
            if (ZmwSimport.zmws_easy_start()>0)
            {
                // Recherche du port sur lequel il s'est lancé ...
                // Adaptation de l'URI en conséquence
                port = ZmwSimport.zmws_get_port();
                if (port != 80)
                {
                    UriStr += ":" + port + "/";
                }
                ourUri = new Uri(UriStr);

                // Allons donc visiter la page d'accueil
                webBrowser.Url = ourUri;
            }
            else
            {
                // Sinon on se rabat sur une page d'erreur par défaut sur zmws.com
                webBrowser.Url = new Uri("http://www.zmws.com/miniwserror");
            }

            // On s'active
            this.Enabled = true;
            this.Visible = true;

            // Ok, on n'a plus besoin du splash
            //splash.Close();

        }

        // Bon allez, ça suffit
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // On voit si on a un mysql à stopper
            //if (isMySQLRunning() && mysqlProcess != null && File.Exists("mysql_stop.bat")) {
            //    ProcessStartInfo psi = new ProcessStartInfo("mysql_stop.bat");
            //    psi.CreateNoWindow = true;
            //    psi.UseShellExecute = false;
            //    psi.ErrorDialog = false;
            //    Process.Start(psi);
            //}

            //zmws_stop();
            ZmwSimport.zmws_stop();
            logViewer.CanClose = true;
            ConsoleRedirector.detatch();
        }

        // On a avancé un peu dans le chargement
        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            statusProgressBar.Value = (int)(100 * e.CurrentProgress / e.MaximumProgress);
        }

        // Ca charge !
        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            statusLabel.Text = "Zzzzzzzzzzzzzzzzzzzzzzz ...";
            statusProgressBar.Visible = true;
        }

        // On est arrivé
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // On récupère l'url courante
            statusLabel.Text = webBrowser.Url.ToString();

            // On récupère le titre du document
            miniwsForm.ActiveForm.Text = "miniwa - " + webBrowser.DocumentTitle;
        }

        // Le document est totalement chargé
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            statusProgressBar.Value = 0;
            statusProgressBar.Visible = false;
        }

        // Revenir en arrière
        private void backButton_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        // Retour vers le futur
        private void nextButton_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        // localhost, sweet localhost :)
        private void homeButton_Click(object sender, EventArgs e)
        {
            webBrowser.Url = ourUri;
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            logViewer.Visible = !logViewer.Visible;
        }
    }
}
