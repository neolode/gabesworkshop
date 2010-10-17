using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using miniws.Properties;

namespace miniws
{
    internal class TrayServer : ApplicationContext
    {
        private ToolStripMenuItem _aboutMenuItem;
        private ToolStripMenuItem _configMenuItem;
        private ToolStripMenuItem _browseMenuItem;
        private ToolStripMenuItem _exitMenuItem;
        private ToolStripMenuItem _gantMenuItem;
        private ToolStripMenuItem _nameMenuItem;
        private ToolStripMenuItem _restartMenuItem;
        private ToolStripMenuItem _logMenuItem;
        private ToolStripSeparator _separator1;
        private ToolStripSeparator _separator2;
        private ToolStripSeparator _separator3;
        private ToolStripSeparator _separator4;
        private ToolStripSeparator _separator5;
        private ToolStripMenuItem _startStopMenuItem;
        private NotifyIcon _trayIcon;
        private ContextMenuStrip _trayMenu;
        private ToolStripMenuItem _versionMenuItem;
        private LogViewer logViewer;
        public TrayServer()
        {
            //ProcessCaller p = new ProcessCaller(this);
            logViewer = new LogViewer();
            ConsoleRedirector.attach(logViewer);
            BuildMenu();        
            
            var zs = ZmwSimport.zmws_get_version();
            _versionMenuItem.Text = "ZazouMiniWebserver\nDll v:" + zs;
            _nameMenuItem.Text = "MiniWS " + Version() + "\nGabriel Rotar\n2008-"+DateTime.Now.Year;
            _gantMenuItem.Text =
                "Graphical resources from G.A.N.T. \r\n(C) Paul Davey \r\nmattahan.deviantart.com";
        }

        private static string Version()
        {
            var version = new Version(Application.ProductVersion);
            return version.Major + "." + version.Minor;
        }

        protected bool Runin { get; set; }

        #region BuildMenu

        private void BuildMenu()
        {
            _trayIcon = new NotifyIcon();
            _trayMenu = new ContextMenuStrip();
            _aboutMenuItem = new ToolStripMenuItem();
            _configMenuItem = new ToolStripMenuItem();
            _nameMenuItem = new ToolStripMenuItem();
            _separator4 = new ToolStripSeparator();
            _versionMenuItem = new ToolStripMenuItem();
            _gantMenuItem = new ToolStripMenuItem();
            _separator3 = new ToolStripSeparator();
            _separator5 = new ToolStripSeparator();
            _separator2 = new ToolStripSeparator();
            _startStopMenuItem = new ToolStripMenuItem();
            _restartMenuItem = new ToolStripMenuItem();
            _browseMenuItem = new ToolStripMenuItem();
            _separator1 = new ToolStripSeparator();
            _exitMenuItem = new ToolStripMenuItem();
            _logMenuItem = new ToolStripMenuItem();
            // 
            // _trayIcon
            // 
            _trayIcon.ContextMenuStrip = _trayMenu;
            _trayIcon.Icon = Resources.webserverIcon;
            _trayIcon.Text = ".net Zazou monitor";
            _trayIcon.Visible = true;
            _trayIcon.MouseClick += TrayIconClick;
            // 
            // _trayMenu
            // 
            _trayMenu.Font = new Font("Verdana", 8.25F, FontStyle.Bold,
                                      GraphicsUnit.Point, 0);
            _trayMenu.ImageScalingSize = new Size(32, 32);
            _trayMenu.Items.AddRange(new ToolStripItem[]
                                         {
                                             _aboutMenuItem,
                                             _configMenuItem,
                                             _separator2,
                                             _startStopMenuItem,
                                             _restartMenuItem,
                                             _browseMenuItem,
                                             _logMenuItem,
                                             _separator1,
                                             _exitMenuItem
                                         });
            _trayMenu.Name = "_trayMenu";
            _trayMenu.Size = new Size(169, 272);
            _trayMenu.Opened += TrayMenuOpened;
            // 
            // aboutToolStripMenuItem
            // 
            _aboutMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                                                      {
                                                          _nameMenuItem,
                                                          _separator3,
                                                          _versionMenuItem,
                                                          _separator4,
                                                          _gantMenuItem
                                                      });
            _aboutMenuItem.Image = Resources.webserver;
            _aboutMenuItem.Name = "aboutToolStripMenuItem";
            _aboutMenuItem.Size = new Size(168, 38);
            _aboutMenuItem.Text = "About";
            // 
            // configMenuItem
            // 
            _configMenuItem.Image = Resources.img2project;
            _configMenuItem.Name = "configToolStripMenuItem";
            _configMenuItem.Size = new Size(168, 38);
            _configMenuItem.Text = "Name";
            _configMenuItem.Click += NameMenuItemClick;
            // 
            // nameToolStripMenuItem
            // 
            _nameMenuItem.Image = Resources.img2project;
            _nameMenuItem.Name = "nameToolStripMenuItem";
            _nameMenuItem.Size = new Size(168, 38);
            _nameMenuItem.Text = "Name";
            _nameMenuItem.Click += NameMenuItemClick;
            // 
            // toolStripSeparator4
            // 
            _separator4.Name = "toolStripSeparator4";
            _separator4.Size = new Size(165, 6);
            // 
            // versionToolStripMenuItem
            // 
            _versionMenuItem.Image = Resources.ZMWS;
            _versionMenuItem.Name = "versionToolStripMenuItem";
            _versionMenuItem.Size = new Size(168, 38);
            _versionMenuItem.Text = "Version";
            _versionMenuItem.Click += VersionMenuItemClick;
            // 
            // gantToolStripMenuItem
            // 
            _gantMenuItem.Image = Resources.GANT3;
            _gantMenuItem.Name = "gantToolStripMenuItem";
            _gantMenuItem.Size = new Size(168, 38);
            _gantMenuItem.Text = "gant";
            _gantMenuItem.Click += GantMenuItemClick;
            // 
            // toolStripSeparator3
            // 
            _separator3.Name = "toolStripSeparator3";
            _separator3.Size = new Size(165, 6);
            // 
            // toolStripSeparator2
            // 
            _separator2.Name = "toolStripSeparator2";
            _separator2.Size = new Size(165, 6);
            // 
            // startStopToolStripMenuItem
            // 
            _startStopMenuItem.Image = Resources.run;
            _startStopMenuItem.Name = "startStopToolStripMenuItem";
            _startStopMenuItem.Size = new Size(168, 38);
            _startStopMenuItem.Text = "Start";
            _startStopMenuItem.Click += StartStopMenuItemClick;
            // 
            // restartToolStripMenuItem
            // 
            _restartMenuItem.Image = Resources.refresh;
            _restartMenuItem.Name = "restartToolStripMenuItem";
            _restartMenuItem.Size = new Size(168, 38);
            _restartMenuItem.Text = "Restart";
            _restartMenuItem.Click += RestartMenuItemClick;
            // 
            // browseToolStripMenuItem
            // 
            _browseMenuItem.Image = Resources.browse;
            _browseMenuItem.Name = "browseToolStripMenuItem";
            _browseMenuItem.Size = new Size(168, 38);
            _browseMenuItem.Text = "Browse";
            _browseMenuItem.Click += BrowseMenuItemClick;
            // 
            // toolStripSeparator1
            // 
            _separator1.Name = "toolStripSeparator1";
            _separator1.Size = new Size(165, 6);
            // 
            // exitToolStripMenuItem
            // 
            _exitMenuItem.Image = Resources.exit;
            _exitMenuItem.Name = "exitToolStripMenuItem";
            _exitMenuItem.Size = new Size(168, 38);
            _exitMenuItem.Text = "Exit";
            _exitMenuItem.Click += ExitMenuItemClick;

            // 
            // logToolStripMenuItem
            // 
            _logMenuItem.Image = Resources.log;
            _logMenuItem.Name = "nameToolStripMenuItem";
            _logMenuItem.Size = new Size(168, 38);
            _logMenuItem.Text = "Log";
            _logMenuItem.Enabled = false;
            _logMenuItem.Click += LogMenuItemClick;
            // 
            // toolStripSeparator4
            // 
            _separator5.Name = "toolStripSeparator5";
            //_separator5.Visible = false;
            _separator5.Size = new Size(165, 6);
            // 
            _trayMenu.DropShadowEnabled = true;

            _trayMenu.MouseLeave += new EventHandler(_trayMenu_MouseLeave);
            _trayMenu.MouseEnter += new EventHandler(_trayMenu_MouseEnter);
            _aboutMenuItem.DropDown.VisibleChanged += new EventHandler(DropDown_VisibleChanged);
        }

        void _trayMenu_MouseEnter(object sender, EventArgs e)
        {
            if (_aboutMenuItem.Selected) return;
            _aboutMenuItem.DropDown.Hide();
        }
        bool about_visible = false;
        void DropDown_VisibleChanged(object sender, EventArgs e)
        {
            about_visible = _aboutMenuItem.DropDown.Visible;
        }
        


        void _trayMenu_MouseLeave(object sender, EventArgs e)
        {
            if (about_visible) return;
            _trayMenu.Close();
        }
        #endregion

        private void LogMenuItemClick(object sender, EventArgs e)
        {
            logViewer.Visible = !logViewer.Visible;
        }

        private static void GantMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("http://mattahan.deviantart.com/");
        }

        private static void NameMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("http://gabesworkshop.wik.is/Mini_Web_Server");
        }

        private static void VersionMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("http://www.zmws.com/");
        }


        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            ZmwSimport.zmws_stop();
            logViewer.CanClose = true;
            ConsoleRedirector.detatch();
            ExitThread();
        }


        private void StartStopMenuItemClick(object sender, EventArgs e)
        {
            if (Runin)
            {
                ZmwSimport.zmws_stop();
                _startStopMenuItem.Text = "Start";
                _startStopMenuItem.Image = Resources.run;
                Runin = false;

            }
            else
            {
                ZmwSimport.zmws_easy_start();
                _startStopMenuItem.Text = "Stop";
                _startStopMenuItem.Image = Resources.stop;
                Runin = true;
                CBaseZMWSConfig bf = new CBaseZMWSConfig();
                ZmwSimport.zmws_get_config(bf);
            }
            _trayIcon.Icon = Runin?global::miniws.Properties.Resources.webserver_on:global::miniws.Properties.Resources.webserverIcon;
            _browseMenuItem.Enabled = Runin;
            _logMenuItem.Enabled = Runin;
            _separator5.Visible = Runin;
        }


        private static void BrowseMenuItemClick(object sender, EventArgs e)
        {
            ZmwSimport.zmws_browse();
        }

        private void TrayMenuOpened(object sender, EventArgs e)
        {
            _browseMenuItem.Enabled = Runin;
            _restartMenuItem.Enabled = Runin;
            _browseMenuItem.Text = "Browse (:" + ZmwSimport.zmws_get_port() + ")";
        }


        private void RestartMenuItemClick(object sender, EventArgs e)
        {
            StartStopMenuItemClick(sender, e);
            Application.DoEvents();
            StartStopMenuItemClick(sender, e);
            Application.DoEvents();
        }

        private void TrayIconClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (!_trayMenu.Visible){
                _trayMenu.Show(Control.MousePosition, ToolStripDropDownDirection.BelowLeft);
                _trayMenu.Focus();
            }
            else
                _trayMenu.Hide();
        }
    }
}