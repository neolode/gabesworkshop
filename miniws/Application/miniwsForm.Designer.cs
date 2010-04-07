namespace miniws
{
    partial class MiniwsForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniwsForm));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.homeButton = new System.Windows.Forms.ToolStripStatusLabel();
            this.backButton = new System.Windows.Forms.ToolStripStatusLabel();
            this.nextButton = new System.Windows.Forms.ToolStripStatusLabel();
            this.logButton = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.AllowWebBrowserDrop = false;
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(792, 551);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.WebBrowserProgressChanged);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebBrowserNavigating);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowserDocumentCompleted);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowserNavigated);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusProgressBar,
            this.homeButton,
            this.backButton,
            this.nextButton,
            this.logButton});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.statusProgressBar.Size = new System.Drawing.Size(200, 16);
            this.statusProgressBar.Step = 1;
            this.statusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.statusProgressBar.Value = 30;
            // 
            // homeButton
            // 
            this.homeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.homeButton.Image = ((System.Drawing.Image)(resources.GetObject("homeButton.Image")));
            this.homeButton.IsLink = true;
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(16, 17);
            this.homeButton.Text = "toolStripStatusLabel1";
            this.homeButton.ToolTipText = "127.0.0.1, sweet 127.0.0.1";
            this.homeButton.Click += new System.EventHandler(this.HomeButtonClick);
            // 
            // backButton
            // 
            this.backButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton.IsLink = true;
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(16, 17);
            this.backButton.Text = "toolStripSplitButton1";
            this.backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // nextButton
            // 
            this.nextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.IsLink = true;
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(16, 17);
            this.nextButton.Text = "toolStripStatusLabel1";
            this.nextButton.Click += new System.EventHandler(this.NextButtonClick);
            // 
            // logButton
            // 
            this.logButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logButton.Image = global::miniws.Properties.Resources.log;
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(16, 17);
            this.logButton.Text = "log";
            this.logButton.Click += new System.EventHandler(this.LogButtonClick);
            // 
            // statusLabel
            // 
            this.statusLabel.Image = global::miniws.Properties.Resources.browse;
            this.statusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel.Margin = new System.Windows.Forms.Padding(10, 3, 10, 2);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(460, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "http://localhost/";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // miniwsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MiniwsForm";
            this.Text = "miniwa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel backButton;
        private System.Windows.Forms.ToolStripStatusLabel nextButton;
        private System.Windows.Forms.ToolStripStatusLabel homeButton;
        private System.Windows.Forms.ToolStripStatusLabel logButton;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

