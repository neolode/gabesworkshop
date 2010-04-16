using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using lightAsp.Properties;
using lightAsp.Util;
using lightAsp.WebServer;

namespace lightAsp.Desktop
{
    public class FrmMain : Form
    {
        private bool autostart;
        private Button btnBrowse;
        private Button btnOK;
        private Button btnShutdown;
        private Button btnStartStop;
        private CheckBox chkDisallowRemoteConnections;
        private CheckBox chkStartServerAtLogin;
        private bool closing;
        private IContainer components;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem itmAbout;
        private ToolStripMenuItem itmEditWebConfig;
        private ToolStripMenuItem itmOpen;
        private ToolStripSeparator itmSep00;
        private ToolStripSeparator itmSep01;
        private ToolStripMenuItem itmSettings;
        private ToolStripMenuItem itmShutdown;
        private ToolStripMenuItem itmStartStop;
        private Label lblLink;
        private Label lblPhisicalDirectory;
        private Label lblPort;
        private Label lblSeparatorH;
        private Label lblVirtualDirectory;
        private LinkLabel lnkEditWebConfig;
        private LinkLabel lnkWiki;
        private NotifyIcon notifyIcon;
        private bool open;
        private bool publishingTried;
        private Server server;
        private TextBox txtPhisicalDirectory;
        private TextBox txtPort;
        private TextBox txtVirtualDirectory;

        public FrmMain(bool autostart, bool open)
        {
            this.autostart = autostart;
            this.open = open;
            InitializeComponent();
        }

        private void BtnBrowseClick(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = @"Select the Directory to serve";
            if (Directory.Exists(txtPhisicalDirectory.Text))
            {
                dialog.SelectedPath = txtPhisicalDirectory.Text;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPhisicalDirectory.Text = dialog.SelectedPath;
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            base.Close();
        }

        private void BtnShutdownClick(object sender, EventArgs e)
        {
            Stop();
            closing = true;
            base.Close();
        }

        private void BtnStartStopClick(object sender, EventArgs e)
        {
            SwitchStatus();
        }

        private void ChkStartServerAtLoginCheckedChanged(object sender, EventArgs e)
        {
            AutoStart.SetAutostart(chkStartServerAtLogin.Checked);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EditWebConfig()
        {
            if (File.Exists(txtPhisicalDirectory.Text + @"\Web.config"))
            {
                Process.Start("notepad.exe", "\"" + txtPhisicalDirectory.Text + "\\Web.config\"");
            }
            else
            {
                MessageBox.Show(@"The file Web.config was not found.", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Hand);
            }
        }

        private void FrmMain_Closing(object sender, CancelEventArgs e)
        {
            if (!closing)
            {
                e.Cancel = true;
                HideWindow();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Closing += FrmMain_Closing;
            //this.notifyIcon.Icon = Resources.WikiSmallGray;
            LoadSettings();
            if (autostart)
            {
                HideWindow();
                Start();
                HideWindow();
                if (open)
                {
                    LnkWikiLinkClicked(this, null);
                }
            }
        }

        private void HideWindow()
        {
            Point location = Location;
            Location = new Point(-1000, -1000);
            ShowInTaskbar = false;
            Hide();
            Location = location;
        }

        private void InitializeComponent()
        {
            components = new Container();
            var resources = new ComponentResourceManager(typeof (FrmMain));
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            itmSep00 = new ToolStripSeparator();
            itmSep01 = new ToolStripSeparator();
            itmShutdown = new ToolStripMenuItem();
            lblPhisicalDirectory = new Label();
            txtPhisicalDirectory = new TextBox();
            chkDisallowRemoteConnections = new CheckBox();
            btnBrowse = new Button();
            lblVirtualDirectory = new Label();
            txtVirtualDirectory = new TextBox();
            lblPort = new Label();
            txtPort = new TextBox();
            btnStartStop = new Button();
            btnOK = new Button();
            btnShutdown = new Button();
            lblSeparatorH = new Label();
            lblLink = new Label();
            lnkWiki = new LinkLabel();
            chkStartServerAtLogin = new CheckBox();
            lnkEditWebConfig = new LinkLabel();
            itmOpen = new ToolStripMenuItem();
            itmEditWebConfig = new ToolStripMenuItem();
            itmSettings = new ToolStripMenuItem();
            itmAbout = new ToolStripMenuItem();
            itmStartStop = new ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = ((Icon) (resources.GetObject("notifyIcon.Icon")));
            notifyIcon.Text = "ASP.net Light Server";
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += NotifyIconDoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(32, 32);
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    itmOpen,
                                                    itmSep00,
                                                    itmEditWebConfig,
                                                    itmSettings,
                                                    itmAbout,
                                                    itmSep01,
                                                    itmStartStop,
                                                    itmShutdown
                                                });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(182, 266);
            // 
            // itmSep00
            // 
            itmSep00.Name = "itmSep00";
            itmSep00.Size = new Size(178, 6);
            // 
            // itmSep01
            // 
            itmSep01.Name = "itmSep01";
            itmSep01.Size = new Size(178, 6);
            // 
            // itmShutdown
            // 
            itmShutdown.Image = Resources.exit;
            itmShutdown.Name = "itmShutdown";
            itmShutdown.Size = new Size(181, 38);
            itmShutdown.Text = "Shutdown Server";
            itmShutdown.Click += ItmExitClick;
            // 
            // lblPhisicalDirectory
            // 
            lblPhisicalDirectory.AutoSize = true;
            lblPhisicalDirectory.Location = new Point(12, 9);
            lblPhisicalDirectory.Name = "lblPhisicalDirectory";
            lblPhisicalDirectory.Size = new Size(91, 13);
            lblPhisicalDirectory.TabIndex = 1;
            lblPhisicalDirectory.Text = "Physical Directory";
            // 
            // txtPhisicalDirectory
            // 
            txtPhisicalDirectory.Location = new Point(12, 25);
            txtPhisicalDirectory.Name = "txtPhisicalDirectory";
            txtPhisicalDirectory.Size = new Size(250, 20);
            txtPhisicalDirectory.TabIndex = 0;
            // 
            // chkDisallowRemoteConnections
            // 
            chkDisallowRemoteConnections.AutoSize = true;
            chkDisallowRemoteConnections.Location = new Point(12, 108);
            chkDisallowRemoteConnections.Name = "chkDisallowRemoteConnections";
            chkDisallowRemoteConnections.Size = new Size(167, 17);
            chkDisallowRemoteConnections.TabIndex = 4;
            chkDisallowRemoteConnections.Text = "Disallow Remote Connections";
            chkDisallowRemoteConnections.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(268, 23);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(60, 23);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += BtnBrowseClick;
            // 
            // lblVirtualDirectory
            // 
            lblVirtualDirectory.AutoSize = true;
            lblVirtualDirectory.Location = new Point(12, 57);
            lblVirtualDirectory.Name = "lblVirtualDirectory";
            lblVirtualDirectory.Size = new Size(81, 13);
            lblVirtualDirectory.TabIndex = 5;
            lblVirtualDirectory.Text = "Virtual Directory";
            // 
            // txtVirtualDirectory
            // 
            txtVirtualDirectory.Location = new Point(12, 73);
            txtVirtualDirectory.Name = "txtVirtualDirectory";
            txtVirtualDirectory.Size = new Size(250, 20);
            txtVirtualDirectory.TabIndex = 2;
            txtVirtualDirectory.Text = "/";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(268, 57);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(26, 13);
            lblPort.TabIndex = 7;
            lblPort.Text = "Port";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(268, 73);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(60, 20);
            txtPort.TabIndex = 3;
            txtPort.Text = "8080";
            // 
            // btnStartStop
            // 
            btnStartStop.Location = new Point(12, 202);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(75, 23);
            btnStartStop.TabIndex = 5;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += BtnStartStopClick;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(253, 202);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 7;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOkClick;
            // 
            // btnShutdown
            // 
            btnShutdown.Location = new Point(93, 202);
            btnShutdown.Name = "btnShutdown";
            btnShutdown.Size = new Size(75, 23);
            btnShutdown.TabIndex = 6;
            btnShutdown.Text = "Shutdown";
            btnShutdown.UseVisualStyleBackColor = true;
            btnShutdown.Click += BtnShutdownClick;
            // 
            // lblSeparatorH
            // 
            lblSeparatorH.BorderStyle = BorderStyle.Fixed3D;
            lblSeparatorH.Location = new Point(0, 162);
            lblSeparatorH.Name = "lblSeparatorH";
            lblSeparatorH.Size = new Size(342, 2);
            lblSeparatorH.TabIndex = 12;
            // 
            // lblLink
            // 
            lblLink.AutoSize = true;
            lblLink.Location = new Point(12, 138);
            lblLink.Name = "lblLink";
            lblLink.Size = new Size(30, 13);
            lblLink.TabIndex = 13;
            lblLink.Text = "Link:";
            // 
            // lnkWiki
            // 
            lnkWiki.AutoSize = true;
            lnkWiki.Enabled = false;
            lnkWiki.Location = new Point(45, 138);
            lnkWiki.Name = "lnkWiki";
            lnkWiki.Size = new Size(33, 13);
            lnkWiki.TabIndex = 14;
            lnkWiki.TabStop = true;
            lnkWiki.Text = "None";
            lnkWiki.LinkClicked += LnkWikiLinkClicked;
            // 
            // chkStartServerAtLogin
            // 
            chkStartServerAtLogin.AutoSize = true;
            chkStartServerAtLogin.Location = new Point(12, 176);
            chkStartServerAtLogin.Name = "chkStartServerAtLogin";
            chkStartServerAtLogin.Size = new Size(123, 17);
            chkStartServerAtLogin.TabIndex = 15;
            chkStartServerAtLogin.Text = "Start Server at Login";
            chkStartServerAtLogin.UseVisualStyleBackColor = true;
            chkStartServerAtLogin.CheckedChanged += ChkStartServerAtLoginCheckedChanged;
            // 
            // lnkEditWebConfig
            // 
            lnkEditWebConfig.AutoSize = true;
            lnkEditWebConfig.Location = new Point(245, 109);
            lnkEditWebConfig.Name = "lnkEditWebConfig";
            lnkEditWebConfig.Size = new Size(83, 13);
            lnkEditWebConfig.TabIndex = 16;
            lnkEditWebConfig.TabStop = true;
            lnkEditWebConfig.Text = "Edit Web.config";
            lnkEditWebConfig.LinkClicked += LnkEditWebConfigLinkClicked;
            // 
            // itmOpen
            // 
            itmOpen.Enabled = false;
            itmOpen.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            itmOpen.Image = Resources.browse;
            itmOpen.Name = "itmOpen";
            itmOpen.Size = new Size(181, 38);
            itmOpen.Text = "Open main page";
            itmOpen.Click += ItmOpenClick;
            // 
            // itmEditWebConfig
            // 
            itmEditWebConfig.Image = Resources.log;
            itmEditWebConfig.Name = "itmEditWebConfig";
            itmEditWebConfig.Size = new Size(181, 38);
            itmEditWebConfig.Text = "Edit Web.config";
            itmEditWebConfig.Click += ItmEditWebConfigClick;
            // 
            // itmSettings
            // 
            itmSettings.Image = ((Image) (resources.GetObject("itmSettings.Image")));
            itmSettings.Name = "itmSettings";
            itmSettings.Size = new Size(181, 38);
            itmSettings.Text = "Configuration";
            itmSettings.Click += ItmSettingsClick;
            // 
            // itmAbout
            // 
            itmAbout.Image = Resources.webserver;
            itmAbout.Name = "itmAbout";
            itmAbout.Size = new Size(181, 38);
            itmAbout.Text = "About";
            itmAbout.Click += ItmAboutClick;
            // 
            // itmStartStop
            // 
            itmStartStop.Image = Resources.run;
            itmStartStop.Name = "itmStartStop";
            itmStartStop.Size = new Size(181, 38);
            itmStartStop.Text = "Start Server";
            itmStartStop.Click += ItmStartStopClick;
            // 
            // FrmMain
            // 
            ClientSize = new Size(341, 236);
            Controls.Add(chkStartServerAtLogin);
            Controls.Add(lblPhisicalDirectory);
            Controls.Add(lnkEditWebConfig);
            Controls.Add(lnkWiki);
            Controls.Add(lblLink);
            Controls.Add(txtPort);
            Controls.Add(lblSeparatorH);
            Controls.Add(txtVirtualDirectory);
            Controls.Add(lblPort);
            Controls.Add(lblVirtualDirectory);
            Controls.Add(txtPhisicalDirectory);
            Controls.Add(btnOK);
            Controls.Add(btnShutdown);
            Controls.Add(chkDisallowRemoteConnections);
            Controls.Add(btnBrowse);
            Controls.Add(btnStartStop);
            Icon = ((Icon) (resources.GetObject("$this.Icon")));
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ASP.net Light Server";
            Load += FrmMain_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private static void ItmAboutClick(object sender, EventArgs e)
        {
            const string text =
                "Client-side ASP.NET runtime based on Microsoft Cassini ASP.NET Server.\nTeam Spitfire\n02 March 2008";
            MessageBox.Show(text, "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void ItmEditWebConfigClick(object sender, EventArgs e)
        {
            EditWebConfig();
        }

        private void ItmExitClick(object sender, EventArgs e)
        {
            Stop();
            closing = true;
            Close();
        }

        private void ItmOpenClick(object sender, EventArgs e)
        {
            if (lnkWiki.Enabled)
            {
                Process.Start(lnkWiki.Text);
            }
        }

        private void ItmSettingsClick(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void ItmStartStopClick(object sender, EventArgs e)
        {
            SwitchStatus();
        }

        private void LnkEditWebConfigLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditWebConfig();
        }

        private void LnkWikiLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnkWiki.Enabled)
            {
                Process.Start(lnkWiki.Text);
            }
        }

        private void LoadSettings()
        {
            if (Settings.GetSetting("PhysicalDirectory") != null)
            {
                txtPhisicalDirectory.Text = Settings.GetSetting("PhysicalDirectory");
            }
            if (Settings.GetSetting("VirtualDirectory") != null)
            {
                txtVirtualDirectory.Text = Settings.GetSetting("VirtualDirectory");
            }
            if (Settings.GetSetting("Port") != null)
            {
                txtPort.Text = Settings.GetSetting("Port");
            }
            if (Settings.GetSetting("DisallowRemoteConnections") != null)
            {
                chkDisallowRemoteConnections.Checked = bool.Parse(Settings.GetSetting("DisallowRemoteConnections"));
            }
            chkStartServerAtLogin.Checked = AutoStart.AutoStartEnabled;
        }

        private void NotifyIconDoubleClick(object sender, EventArgs e)
        {
            if (lnkWiki.Enabled)
            {
                Process.Start(lnkWiki.Text);
            }
            else
            {
                ShowWindow();
            }
        }

        private void ShowWindow()
        {
            ShowInTaskbar = true;
            Show();
        }

        private void Start()
        {
            string text = txtPhisicalDirectory.Text;
            if (text.StartsWith(@".\") || text.StartsWith(@"\"))
            {
                string currentDirectory = Environment.CurrentDirectory;
                if (currentDirectory.EndsWith(@"\"))
                {
                    currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 2);
                }
                while (text.StartsWith(@".\"))
                {
                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf(@"\"));
                    text = text.Substring(2);
                }
                text = currentDirectory + text;
            }
            if (!Directory.Exists(text))
            {
                MessageBox.Show("Physical Directory does not exist.\r\n" + text, "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Hand);
                return;
            }
            try
            {
                int num = int.Parse(txtPort.Text);
                if ((num <= 0) || (num > 0xffff))
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show(@"Invalid Port number (it must be greater than zero and smaller than 65535).", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if ((txtVirtualDirectory.Text.Length != 0) && txtVirtualDirectory.Text.StartsWith("/"))
            {
                if (server != null)
                {
                    server.Stop();
                }
                try
                {
                    server = new Server(int.Parse(txtPort.Text), txtVirtualDirectory.Text, text,
                                        chkDisallowRemoteConnections.Checked);
                    server.Start();
                }
                catch (Exception exception)
                {
                    if (!publishingTried)
                    {
                        GacUtil.Install(Application.StartupPath + @"\lightAspServer.dll");
                        publishingTried = true;
                        try
                        {
                            server = new Server(int.Parse(txtPort.Text), txtVirtualDirectory.Text, text,
                                                chkDisallowRemoteConnections.Checked);
                            server.Start();
                            UpdateUi();
                            SaveSetings(text, txtVirtualDirectory.Text, txtPort.Text,
                                        chkDisallowRemoteConnections.Checked.ToString());
                        }
                        catch
                        {
                            MessageBox.Show(
                                "Unable to start the Server.\r\n\r\n" + exception.Message + "\r\n\r\n" +
                                exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                    MessageBox.Show(
                        "Unable to start the Server.\r\n\r\n" + exception.Message + "\r\n\r\n" + exception.StackTrace,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            else
            {
                MessageBox.Show(@"Invalid Virtual Directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            UpdateUi();
            SaveSetings(text, txtVirtualDirectory.Text, txtPort.Text, chkDisallowRemoteConnections.Checked.ToString());
        }

        private void UpdateUi()
        {
            //this.notifyIcon.Icon = Resources.WikiSmall;
            txtPhisicalDirectory.Enabled = false;
            btnBrowse.Enabled = false;
            txtPort.Enabled = false;
            txtVirtualDirectory.Enabled = false;
            chkDisallowRemoteConnections.Enabled = false;
            lnkWiki.Enabled = true;
            lnkWiki.Text = server.RootUrl; //+ "Default.aspx";
            btnStartStop.Text = "Stop";
            itmStartStop.Text = "Stop";
            itmStartStop.Image = Resources.stop;
            itmOpen.Enabled = true;
        }

        private static void SaveSetings(string diskPath, string webPath, string port, string remoteConnection)
        {
            Settings.SetSetting("PhysicalDirectory", diskPath);
            Settings.SetSetting("VirtualDirectory", webPath);
            Settings.SetSetting("Port", port);
            Settings.SetSetting("DisallowRemoteConnections", remoteConnection);
            Settings.Save();
        }

        private void Stop()
        {
            if (server == null) return;
            server.Stop();
            server = null;
            txtPhisicalDirectory.Enabled = true;
            btnBrowse.Enabled = true;
            txtPort.Enabled = true;
            txtVirtualDirectory.Enabled = true;
            chkDisallowRemoteConnections.Enabled = true;
            lnkWiki.Enabled = false;
            lnkWiki.Text = "None";
            btnStartStop.Text = "Start";
            itmStartStop.Text = "Start";
            itmStartStop.Image = Resources.run;
            itmOpen.Enabled = false;
            //this.notifyIcon.Icon = Resources.WikiSmallGray;
        }

        private void SwitchStatus()
        {
            if (server != null)
            {
                if (server.Running)
                {
                    Stop();
                }
                else
                {
                    Start();
                }
            }
            else
            {
                Start();
            }
        }
    }
}