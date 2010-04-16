namespace lightAsp.App
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using lightAsp.WebServer;
    using lightAspServer;

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
            this.InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select the Directory to serve";
            if (Directory.Exists(this.txtPhisicalDirectory.Text))
            {
                dialog.SelectedPath = this.txtPhisicalDirectory.Text;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPhisicalDirectory.Text = dialog.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            this.Stop();
            this.closing = true;
            base.Close();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            this.SwitchStatus();
        }

        private void chkStartServerAtLogin_CheckedChanged(object sender, EventArgs e)
        {
            AutoStart.SetAutostart(this.chkStartServerAtLogin.Checked);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EditWebConfig()
        {
            if (File.Exists(this.txtPhisicalDirectory.Text + @"\Web.config"))
            {
                Process.Start("notepad.exe", "\"" + this.txtPhisicalDirectory.Text + "\\Web.config\"");
            }
            else
            {
                MessageBox.Show("The file Web.config was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void FrmMain_Closing(object sender, CancelEventArgs e)
        {
            if (!this.closing)
            {
                e.Cancel = true;
                this.HideWindow();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            base.Closing += new CancelEventHandler(this.FrmMain_Closing);
            //this.notifyIcon.Icon = Resources.WikiSmallGray;
            this.LoadSettings();
            if (this.autostart)
            {
                this.HideWindow();
                this.Start();
                this.HideWindow();
                if (this.open)
                {
                    this.lnkWiki_LinkClicked(this, null);
                }
            }
        }

        private void HideWindow()
        {
            Point location = base.Location;
            base.Location = new Point(-1000, -1000);
            base.ShowInTaskbar = false;
            base.Hide();
            base.Location = location;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmSep00 = new System.Windows.Forms.ToolStripSeparator();
            this.itmSep01 = new System.Windows.Forms.ToolStripSeparator();
            this.itmShutdown = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPhisicalDirectory = new System.Windows.Forms.Label();
            this.txtPhisicalDirectory = new System.Windows.Forms.TextBox();
            this.chkDisallowRemoteConnections = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblVirtualDirectory = new System.Windows.Forms.Label();
            this.txtVirtualDirectory = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.lblSeparatorH = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.Label();
            this.lnkWiki = new System.Windows.Forms.LinkLabel();
            this.chkStartServerAtLogin = new System.Windows.Forms.CheckBox();
            this.lnkEditWebConfig = new System.Windows.Forms.LinkLabel();
            this.itmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itmEditWebConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.itmStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ASP.net Light Server";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmOpen,
            this.itmSep00,
            this.itmEditWebConfig,
            this.itmSettings,
            this.itmAbout,
            this.itmSep01,
            this.itmStartStop,
            this.itmShutdown});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(182, 266);
            // 
            // itmSep00
            // 
            this.itmSep00.Name = "itmSep00";
            this.itmSep00.Size = new System.Drawing.Size(178, 6);
            // 
            // itmSep01
            // 
            this.itmSep01.Name = "itmSep01";
            this.itmSep01.Size = new System.Drawing.Size(178, 6);
            // 
            // itmShutdown
            // 
            this.itmShutdown.Image = global::lightAsp.Properties.Resources.exit;
            this.itmShutdown.Name = "itmShutdown";
            this.itmShutdown.Size = new System.Drawing.Size(181, 38);
            this.itmShutdown.Text = "Shutdown Server";
            this.itmShutdown.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // lblPhisicalDirectory
            // 
            this.lblPhisicalDirectory.AutoSize = true;
            this.lblPhisicalDirectory.Location = new System.Drawing.Point(12, 9);
            this.lblPhisicalDirectory.Name = "lblPhisicalDirectory";
            this.lblPhisicalDirectory.Size = new System.Drawing.Size(91, 13);
            this.lblPhisicalDirectory.TabIndex = 1;
            this.lblPhisicalDirectory.Text = "Physical Directory";
            // 
            // txtPhisicalDirectory
            // 
            this.txtPhisicalDirectory.Location = new System.Drawing.Point(12, 25);
            this.txtPhisicalDirectory.Name = "txtPhisicalDirectory";
            this.txtPhisicalDirectory.Size = new System.Drawing.Size(250, 20);
            this.txtPhisicalDirectory.TabIndex = 0;
            // 
            // chkDisallowRemoteConnections
            // 
            this.chkDisallowRemoteConnections.AutoSize = true;
            this.chkDisallowRemoteConnections.Location = new System.Drawing.Point(12, 108);
            this.chkDisallowRemoteConnections.Name = "chkDisallowRemoteConnections";
            this.chkDisallowRemoteConnections.Size = new System.Drawing.Size(167, 17);
            this.chkDisallowRemoteConnections.TabIndex = 4;
            this.chkDisallowRemoteConnections.Text = "Disallow Remote Connections";
            this.chkDisallowRemoteConnections.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(268, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(60, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblVirtualDirectory
            // 
            this.lblVirtualDirectory.AutoSize = true;
            this.lblVirtualDirectory.Location = new System.Drawing.Point(12, 57);
            this.lblVirtualDirectory.Name = "lblVirtualDirectory";
            this.lblVirtualDirectory.Size = new System.Drawing.Size(81, 13);
            this.lblVirtualDirectory.TabIndex = 5;
            this.lblVirtualDirectory.Text = "Virtual Directory";
            // 
            // txtVirtualDirectory
            // 
            this.txtVirtualDirectory.Location = new System.Drawing.Point(12, 73);
            this.txtVirtualDirectory.Name = "txtVirtualDirectory";
            this.txtVirtualDirectory.Size = new System.Drawing.Size(250, 20);
            this.txtVirtualDirectory.TabIndex = 2;
            this.txtVirtualDirectory.Text = "/";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(268, 57);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(268, 73);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(60, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8080";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 202);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 5;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(253, 202);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.Location = new System.Drawing.Point(93, 202);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(75, 23);
            this.btnShutdown.TabIndex = 6;
            this.btnShutdown.Text = "Shutdown";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // lblSeparatorH
            // 
            this.lblSeparatorH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparatorH.Location = new System.Drawing.Point(0, 162);
            this.lblSeparatorH.Name = "lblSeparatorH";
            this.lblSeparatorH.Size = new System.Drawing.Size(342, 2);
            this.lblSeparatorH.TabIndex = 12;
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(12, 138);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(30, 13);
            this.lblLink.TabIndex = 13;
            this.lblLink.Text = "Link:";
            // 
            // lnkWiki
            // 
            this.lnkWiki.AutoSize = true;
            this.lnkWiki.Enabled = false;
            this.lnkWiki.Location = new System.Drawing.Point(45, 138);
            this.lnkWiki.Name = "lnkWiki";
            this.lnkWiki.Size = new System.Drawing.Size(33, 13);
            this.lnkWiki.TabIndex = 14;
            this.lnkWiki.TabStop = true;
            this.lnkWiki.Text = "None";
            this.lnkWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWiki_LinkClicked);
            // 
            // chkStartServerAtLogin
            // 
            this.chkStartServerAtLogin.AutoSize = true;
            this.chkStartServerAtLogin.Location = new System.Drawing.Point(12, 176);
            this.chkStartServerAtLogin.Name = "chkStartServerAtLogin";
            this.chkStartServerAtLogin.Size = new System.Drawing.Size(123, 17);
            this.chkStartServerAtLogin.TabIndex = 15;
            this.chkStartServerAtLogin.Text = "Start Server at Login";
            this.chkStartServerAtLogin.UseVisualStyleBackColor = true;
            this.chkStartServerAtLogin.CheckedChanged += new System.EventHandler(this.chkStartServerAtLogin_CheckedChanged);
            // 
            // lnkEditWebConfig
            // 
            this.lnkEditWebConfig.AutoSize = true;
            this.lnkEditWebConfig.Location = new System.Drawing.Point(245, 109);
            this.lnkEditWebConfig.Name = "lnkEditWebConfig";
            this.lnkEditWebConfig.Size = new System.Drawing.Size(83, 13);
            this.lnkEditWebConfig.TabIndex = 16;
            this.lnkEditWebConfig.TabStop = true;
            this.lnkEditWebConfig.Text = "Edit Web.config";
            this.lnkEditWebConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditWebConfig_LinkClicked);
            // 
            // itmOpen
            // 
            this.itmOpen.Enabled = false;
            this.itmOpen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itmOpen.Image = global::lightAsp.Properties.Resources.browse;
            this.itmOpen.Name = "itmOpen";
            this.itmOpen.Size = new System.Drawing.Size(181, 38);
            this.itmOpen.Text = "Open main page";
            this.itmOpen.Click += new System.EventHandler(this.itmOpen_Click);
            // 
            // itmEditWebConfig
            // 
            this.itmEditWebConfig.Image = global::lightAsp.Properties.Resources.log;
            this.itmEditWebConfig.Name = "itmEditWebConfig";
            this.itmEditWebConfig.Size = new System.Drawing.Size(181, 38);
            this.itmEditWebConfig.Text = "Edit Web.config";
            this.itmEditWebConfig.Click += new System.EventHandler(this.itmEditWebConfig_Click);
            // 
            // itmSettings
            // 
            this.itmSettings.Image = ((System.Drawing.Image)(resources.GetObject("itmSettings.Image")));
            this.itmSettings.Name = "itmSettings";
            this.itmSettings.Size = new System.Drawing.Size(181, 38);
            this.itmSettings.Text = "Configuration";
            this.itmSettings.Click += new System.EventHandler(this.itmSettings_Click);
            // 
            // itmAbout
            // 
            this.itmAbout.Image = global::lightAsp.Properties.Resources.webserver;
            this.itmAbout.Name = "itmAbout";
            this.itmAbout.Size = new System.Drawing.Size(181, 38);
            this.itmAbout.Text = "About";
            this.itmAbout.Click += new System.EventHandler(this.itmAbout_Click);
            // 
            // itmStartStop
            // 
            this.itmStartStop.Image = global::lightAsp.Properties.Resources.run;
            this.itmStartStop.Name = "itmStartStop";
            this.itmStartStop.Size = new System.Drawing.Size(181, 38);
            this.itmStartStop.Text = "Start Server";
            this.itmStartStop.Click += new System.EventHandler(this.itmStartStop_Click);
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(341, 236);
            this.Controls.Add(this.chkStartServerAtLogin);
            this.Controls.Add(this.lblPhisicalDirectory);
            this.Controls.Add(this.lnkEditWebConfig);
            this.Controls.Add(this.lnkWiki);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblSeparatorH);
            this.Controls.Add(this.txtVirtualDirectory);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblVirtualDirectory);
            this.Controls.Add(this.txtPhisicalDirectory);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.chkDisallowRemoteConnections);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnStartStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASP.net Light Server";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void itmAbout_Click(object sender, EventArgs e)
        {
            
            string text = "Client-side ASP.NET runtime based on Microsoft Cassini ASP.NET Server.\nTeam Spitfire\n02 March 2008";
            MessageBox.Show(text, "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void itmEditWebConfig_Click(object sender, EventArgs e)
        {
            this.EditWebConfig();
        }

        private void itmExit_Click(object sender, EventArgs e)
        {
            this.Stop();
            this.closing = true;
            base.Close();
        }

        private void itmOpen_Click(object sender, EventArgs e)
        {
            if (this.lnkWiki.Enabled)
            {
                Process.Start(this.lnkWiki.Text);
            }
        }

        private void itmSettings_Click(object sender, EventArgs e)
        {
            this.ShowWindow();
        }

        private void itmStartStop_Click(object sender, EventArgs e)
        {
            this.SwitchStatus();
        }

        private void lnkEditWebConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.EditWebConfig();
        }

        private void lnkWiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.lnkWiki.Enabled)
            {
                Process.Start(this.lnkWiki.Text);
            }
        }

        private void LoadSettings()
        {
            if (lightAsp.App.Settings.GetSetting("PhysicalDirectory") != null)
            {
                this.txtPhisicalDirectory.Text = lightAsp.App.Settings.GetSetting("PhysicalDirectory");
            }
            if (lightAsp.App.Settings.GetSetting("VirtualDirectory") != null)
            {
                this.txtVirtualDirectory.Text = lightAsp.App.Settings.GetSetting("VirtualDirectory");
            }
            if (lightAsp.App.Settings.GetSetting("Port") != null)
            {
                this.txtPort.Text = lightAsp.App.Settings.GetSetting("Port");
            }
            if (lightAsp.App.Settings.GetSetting("DisallowRemoteConnections") != null)
            {
                this.chkDisallowRemoteConnections.Checked = bool.Parse(lightAsp.App.Settings.GetSetting("DisallowRemoteConnections"));
            }
            this.chkStartServerAtLogin.Checked = AutoStart.AutoStartEnabled;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.lnkWiki.Enabled)
            {
                Process.Start(this.lnkWiki.Text);
            }
            else
            {
                this.ShowWindow();
            }
        }

        private void ShowWindow()
        {
            base.ShowInTaskbar = true;
            base.Show();
        }

        private void Start()
        {
            string text = this.txtPhisicalDirectory.Text;
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
                MessageBox.Show("Physical Directory does not exist.\r\n" + text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                int num = int.Parse(this.txtPort.Text);
                if ((num <= 0) || (num > 0xffff))
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Invalid Port number (it must be greater than zero and smaller than 65535).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if ((this.txtVirtualDirectory.Text.Length != 0) && this.txtVirtualDirectory.Text.StartsWith("/"))
            {
                if (this.server != null)
                {
                    this.server.Stop();
                }
                try
                {
                    this.server = new Server(int.Parse(this.txtPort.Text), this.txtVirtualDirectory.Text, text, this.chkDisallowRemoteConnections.Checked);
                    this.server.Start();
                }
                catch (Exception exception)
                {
                    if (!this.publishingTried)
                    {
                        GacUtil.Install(Application.StartupPath + @"\lightAspServer.dll");
                        this.publishingTried = true;
                        try
                        {
                            this.server = new Server(int.Parse(this.txtPort.Text), this.txtVirtualDirectory.Text, text, this.chkDisallowRemoteConnections.Checked);
                            this.server.Start();
                            goto Label_022F;
                        }
                        catch
                        {
                            MessageBox.Show("Unable to start the Server.\r\n\r\n" + exception.Message + "\r\n\r\n" + exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                    MessageBox.Show("Unable to start the Server.\r\n\r\n" + exception.Message + "\r\n\r\n" + exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid Virtual Directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        Label_022F:
            //this.notifyIcon.Icon = Resources.WikiSmall;
            this.txtPhisicalDirectory.Enabled = false;
            this.btnBrowse.Enabled = false;
            this.txtPort.Enabled = false;
            this.txtVirtualDirectory.Enabled = false;
            this.chkDisallowRemoteConnections.Enabled = false;
            this.lnkWiki.Enabled = true;
            this.lnkWiki.Text = this.server.RootUrl;//+ "Default.aspx";
            this.btnStartStop.Text = "Stop";
            this.itmStartStop.Text = "Stop";
            this.itmStartStop.Image = lightAsp.Properties.Resources.stop;
            this.itmOpen.Enabled = true;
            lightAsp.App.Settings.SetSetting("PhysicalDirectory", text);
            lightAsp.App.Settings.SetSetting("VirtualDirectory", this.txtVirtualDirectory.Text);
            lightAsp.App.Settings.SetSetting("Port", this.txtPort.Text);
            lightAsp.App.Settings.SetSetting("DisallowRemoteConnections", this.chkDisallowRemoteConnections.Checked.ToString());
            lightAsp.App.Settings.Save();
        }

        private void Stop()
        {
            if (this.server != null)
            {
                this.server.Stop();
                this.server = null;
                this.txtPhisicalDirectory.Enabled = true;
                this.btnBrowse.Enabled = true;
                this.txtPort.Enabled = true;
                this.txtVirtualDirectory.Enabled = true;
                this.chkDisallowRemoteConnections.Enabled = true;
                this.lnkWiki.Enabled = false;
                this.lnkWiki.Text = "None";
                this.btnStartStop.Text = "Start";
                this.itmStartStop.Text = "Start";
                this.itmStartStop.Image = lightAsp.Properties.Resources.run;
                this.itmOpen.Enabled = false;
                //this.notifyIcon.Icon = Resources.WikiSmallGray;
            }
        }

        private void SwitchStatus()
        {
            if (this.server != null)
            {
                if (this.server.Running)
                {
                    this.Stop();
                }
                else
                {
                    this.Start();
                }
            }
            else
            {
                this.Start();
            }
        }
    }
}

