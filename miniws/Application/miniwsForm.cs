using System;
using System.Windows.Forms;

namespace miniws
{
    public partial class MiniwsForm : Form
    {
        private Uri _ourUri;

        private LogViewer logViewer;
        // Construction de la fen�tre principale
        public MiniwsForm()
        {
            logViewer = new LogViewer();
            ConsoleRedirector.attach(logViewer);

            // Si un mysql tourne d�j� il n'est pas � nous
            //mysqlProcess = null;

            // Pour l'instant on n'existe pas
            Enabled = false;
            
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

        // Gazzzzz ! Fait p�ter le browser !
        private void Form1_Load(object sender, EventArgs e)
        {
            var uriStr = @"http://127.0.0.1";//miniws.Properties.Settings.Default.HomeUrl;
            int port;

            // On voit si on a un mysql � d�marrer
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
                // Recherche du port sur lequel il s'est lanc� ...
                // Adaptation de l'URI en cons�quence
                port = ZmwSimport.zmws_get_port();
                if (port != 80)
                {
                    uriStr += ":" + port + "/";
                }
                _ourUri = new Uri(uriStr);

                // Allons donc visiter la page d'accueil
                webBrowser.Url = _ourUri;
            }
            else
            {
                // Sinon on se rabat sur une page d'erreur par d�faut sur zmws.com
                webBrowser.Url = new Uri("http://www.zmws.com/miniwserror");
            }

            // On s'active
            Enabled = true;
            Visible = true;

            // Ok, on n'a plus besoin du splash
            //splash.Close();

        }

        // Bon allez, �a suffit
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // On voit si on a un mysql � stopper
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

        // On a avanc� un peu dans le chargement
        private void WebBrowserProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            statusProgressBar.Value = (int)(100 * e.CurrentProgress / e.MaximumProgress);
        }

        // Ca charge !
        private void WebBrowserNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            statusLabel.Text = "Zzzzzzzzzzzzzzzzzzzzzzz ...";
            statusProgressBar.Visible = true;
        }

        // On est arriv�
        private void WebBrowserNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // On r�cup�re l'url courante
            statusLabel.Text = webBrowser.Url.ToString();

            // On r�cup�re le titre du document
            Text = "miniwa - " + webBrowser.DocumentTitle;
        }

        // Le document est totalement charg�
        private void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            statusProgressBar.Value = 0;
            statusProgressBar.Visible = false;
        }

        // Revenir en arri�re
        private void BackButtonClick(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        // Retour vers le futur
        private void NextButtonClick(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        // localhost, sweet localhost :)
        private void HomeButtonClick(object sender, EventArgs e)
        {
            webBrowser.Url = _ourUri;
        }

        private void LogButtonClick(object sender, EventArgs e)
        {
            logViewer.Visible = !logViewer.Visible;
        }
    }
}
