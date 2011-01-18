namespace gs
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.startBuffer = new System.Windows.Forms.Timer(this.components);
            this.trayIco = new System.Windows.Forms.NotifyIcon(this.components);
            this.appLayout = new System.Windows.Forms.SplitContainer();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.pbMax = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbIco = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bmpSplash = new System.Windows.Forms.PictureBox();
            this.wkPlayer = new WebKit.WebKitBrowser();
            this.appLayout.Panel1.SuspendLayout();
            this.appLayout.Panel2.SuspendLayout();
            this.appLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmpSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // startBuffer
            // 
            this.startBuffer.Interval = 4000;
            this.startBuffer.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // trayIco
            // 
            this.trayIco.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIco.Icon")));
            this.trayIco.Text = "DeskShark";
            this.trayIco.DoubleClick += new System.EventHandler(this.pbMin_Click);
            // 
            // appLayout
            // 
            this.appLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.appLayout.IsSplitterFixed = true;
            this.appLayout.Location = new System.Drawing.Point(0, 0);
            this.appLayout.Margin = new System.Windows.Forms.Padding(0);
            this.appLayout.Name = "appLayout";
            this.appLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // appLayout.Panel1
            // 
            this.appLayout.Panel1.BackgroundImage = global::DeskShark.Properties.Resources.glass;
            this.appLayout.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.appLayout.Panel1.Controls.Add(this.pbMin);
            this.appLayout.Panel1.Controls.Add(this.pbMax);
            this.appLayout.Panel1.Controls.Add(this.pbClose);
            this.appLayout.Panel1.Controls.Add(this.pbIco);
            this.appLayout.Panel1.Controls.Add(this.lblTitle);
            this.appLayout.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.appLayout.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.appLayout_Panel1_MouseDown);
            this.appLayout.Panel1.SizeChanged += new System.EventHandler(this.appLayout_Panel1_SizeChanged);
            this.appLayout.Panel1MinSize = 32;
            // 
            // appLayout.Panel2
            // 
            this.appLayout.Panel2.Controls.Add(this.wkPlayer);
            this.appLayout.Panel2.Controls.Add(this.bmpSplash);
            this.appLayout.Size = new System.Drawing.Size(784, 584);
            this.appLayout.SplitterDistance = 34;
            this.appLayout.SplitterWidth = 1;
            this.appLayout.TabIndex = 4;
            this.appLayout.TabStop = false;
            // 
            // pbMin
            // 
            this.pbMin.BackColor = System.Drawing.Color.Transparent;
            this.pbMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbMin.Image = global::DeskShark.Properties.Resources.btn_min;
            this.pbMin.Location = new System.Drawing.Point(688, 0);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(32, 34);
            this.pbMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMin.TabIndex = 4;
            this.pbMin.TabStop = false;
            this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
            // 
            // pbMax
            // 
            this.pbMax.BackColor = System.Drawing.Color.Transparent;
            this.pbMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbMax.Image = global::DeskShark.Properties.Resources.btn_max;
            this.pbMax.Location = new System.Drawing.Point(720, 0);
            this.pbMax.Name = "pbMax";
            this.pbMax.Size = new System.Drawing.Size(32, 34);
            this.pbMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMax.TabIndex = 3;
            this.pbMax.TabStop = false;
            this.pbMax.Click += new System.EventHandler(this.pbMax_Click);
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbClose.Image = global::DeskShark.Properties.Resources.btn_close;
            this.pbClose.Location = new System.Drawing.Point(752, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(32, 34);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 2;
            this.pbClose.TabStop = false;
            this.pbClose.MouseLeave += new System.EventHandler(this.pbClose_MouseLeave);
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            this.pbClose.MouseEnter += new System.EventHandler(this.pbClose_MouseEnter);
            // 
            // pbIco
            // 
            this.pbIco.BackColor = System.Drawing.Color.Transparent;
            this.pbIco.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbIco.Image = global::DeskShark.Properties.Resources.gs_ico;
            this.pbIco.Location = new System.Drawing.Point(0, 0);
            this.pbIco.Name = "pbIco";
            this.pbIco.Size = new System.Drawing.Size(46, 34);
            this.pbIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIco.TabIndex = 1;
            this.pbIco.TabStop = false;
            this.pbIco.MouseDown += new System.Windows.Forms.MouseEventHandler(this.appLayout_Panel1_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(52, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DeskShark ~ initializing";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.appLayout_Panel1_MouseDown);
            // 
            // bmpSplash
            // 
            this.bmpSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bmpSplash.Image = global::DeskShark.Properties.Resources.gs;
            this.bmpSplash.Location = new System.Drawing.Point(0, 0);
            this.bmpSplash.Name = "bmpSplash";
            this.bmpSplash.Size = new System.Drawing.Size(784, 549);
            this.bmpSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bmpSplash.TabIndex = 4;
            this.bmpSplash.TabStop = false;
            // 
            // wkPlayer
            // 
            this.wkPlayer.BackColor = System.Drawing.Color.White;
            this.wkPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wkPlayer.Location = new System.Drawing.Point(0, 0);
            this.wkPlayer.Name = "wkPlayer";
            this.wkPlayer.Size = new System.Drawing.Size(784, 549);
            this.wkPlayer.TabIndex = 6;
            this.wkPlayer.Url = new System.Uri("http://listen.grooveshark.com/", System.UriKind.Absolute);
            this.wkPlayer.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wkPlayer_DocumentCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Orange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 584);
            this.ControlBox = false;
            this.Controls.Add(this.appLayout);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Opacity = 0.9;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.appLayout.Panel1.ResumeLayout(false);
            this.appLayout.Panel1.PerformLayout();
            this.appLayout.Panel2.ResumeLayout(false);
            this.appLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmpSplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer startBuffer;
        private System.Windows.Forms.NotifyIcon trayIco;
        private System.Windows.Forms.SplitContainer appLayout;
        private System.Windows.Forms.PictureBox bmpSplash;
        private System.Windows.Forms.PictureBox pbIco;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.PictureBox pbMax;
        private System.Windows.Forms.PictureBox pbClose;
        private WebKit.WebKitBrowser wkPlayer;

    }
}

