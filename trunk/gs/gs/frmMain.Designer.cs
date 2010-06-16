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
            this.wbPlayer = new System.Windows.Forms.WebBrowser();
            this.startBuffer = new System.Windows.Forms.Timer(this.components);
            this.bmpSplash = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bmpSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // wbPlayer
            // 
            this.wbPlayer.AllowWebBrowserDrop = false;
            this.wbPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPlayer.Location = new System.Drawing.Point(0, 0);
            this.wbPlayer.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPlayer.Name = "wbPlayer";
            this.wbPlayer.ScriptErrorsSuppressed = true;
            this.wbPlayer.ScrollBarsEnabled = false;
            this.wbPlayer.Size = new System.Drawing.Size(784, 562);
            this.wbPlayer.TabIndex = 1;
            this.wbPlayer.Url = new System.Uri("http://listen.grooveshark.com/", System.UriKind.Absolute);
            this.wbPlayer.Visible = false;
            this.wbPlayer.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.WebBrowser1ProgressChanged);
            this.wbPlayer.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebBrowser1Navigating);
            this.wbPlayer.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowser1Navigated);
            // 
            // startBuffer
            // 
            this.startBuffer.Interval = 4000;
            this.startBuffer.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // bmpSplash
            // 
            this.bmpSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bmpSplash.Image = global::gs.Properties.Resources.gs;
            this.bmpSplash.Location = new System.Drawing.Point(0, 0);
            this.bmpSplash.Name = "bmpSplash";
            this.bmpSplash.Size = new System.Drawing.Size(784, 562);
            this.bmpSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bmpSplash.TabIndex = 3;
            this.bmpSplash.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Orange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.bmpSplash);
            this.Controls.Add(this.wbPlayer);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "GrooveShark Desktop ~ initializing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bmpSplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbPlayer;
        private System.Windows.Forms.Timer startBuffer;
        private System.Windows.Forms.PictureBox bmpSplash;

    }
}

