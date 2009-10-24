﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using miniws.Properties;

namespace miniws
{
    internal class TrayServer : ApplicationContext
    {
        private ToolStripMenuItem _aboutMenuItem;
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

        public TrayServer()
        {
            //ProcessCaller p = new ProcessCaller(this);

            BuildMenu();

            var zs = ZMWSimport.zmws_get_version();
            _versionMenuItem.Text = "ZazouMiniWebserver\nDll v:" + zs;
            _nameMenuItem.Text = "MiniWS " + Version() + "\nGabriel Rotar\n2008";
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
                                             _separator2,
                                             _logMenuItem,
                                             _separator5,
                                             _startStopMenuItem,
                                             _restartMenuItem,
                                             _browseMenuItem,
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
            _logMenuItem.Visible = false;
            _logMenuItem.Click += LogMenuItemClick;
            // 
            // toolStripSeparator4
            // 
            _separator5.Name = "toolStripSeparator5";
            _separator5.Visible = false;
            _separator5.Size = new Size(165, 6);
            // 
        }

        private void LogMenuItemClick(object sender, EventArgs e)
        {

        }

        #endregion

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
            ZMWSimport.zmws_stop();
            ExitThread();
        }


        private void StartStopMenuItemClick(object sender, EventArgs e)
        {
            if (Runin)
            {
                ZMWSimport.zmws_stop();
                _startStopMenuItem.Text = "Start";
                _startStopMenuItem.Image = Resources.run;
                Runin = false;

            }
            else
            {
                ZMWSimport.zmws_easy_start();
                _startStopMenuItem.Text = "Stop";
                _startStopMenuItem.Image = Resources.stop;
                Runin = true;
            }
            _browseMenuItem.Enabled = Runin;
            //_logMenuItem.Visible = Runin;
            //_separator5.Visible = Runin;
        }


        private static void BrowseMenuItemClick(object sender, EventArgs e)
        {
            ZMWSimport.zmws_browse();
        }

        private void TrayMenuOpened(object sender, EventArgs e)
        {
            _browseMenuItem.Enabled = Runin;
            _restartMenuItem.Enabled = Runin;
            _browseMenuItem.Text = "Browse (:" + ZMWSimport.zmws_get_port() + ")";
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
            if (!_trayMenu.Visible)
                _trayMenu.Show(Control.MousePosition.X, Control.MousePosition.Y);
            else
                _trayMenu.Hide();
        }
    }
}