namespace vremea2
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.bgGetImage = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.inWork = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btbGet = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.modAbout = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Label();
            this.getTimer = new System.Windows.Forms.Timer(this.components);
            this.bgUpdate = new System.ComponentModel.BackgroundWorker();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.inWork.SuspendLayout();
            this.panel1.SuspendLayout();
            this.modAbout.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgGetImage
            // 
            this.bgGetImage.WorkerReportsProgress = true;
            this.bgGetImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgGetImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGetImage_RunWorkerCompleted);
            this.bgGetImage.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgGetImage_ProgressChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(198, 31);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // inWork
            // 
            this.inWork.BackColor = System.Drawing.Color.Transparent;
            this.inWork.Controls.Add(this.progressBar1);
            this.inWork.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inWork.Location = new System.Drawing.Point(98, 187);
            this.inWork.Name = "inWork";
            this.inWork.Size = new System.Drawing.Size(204, 70);
            this.inWork.TabIndex = 2;
            this.inWork.TabStop = false;
            this.inWork.Text = "Working";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btbGet);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnAbout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 100);
            this.panel1.TabIndex = 3;
            this.toolTips.SetToolTip(this.panel1, "Click and drag to move.");
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btbGet
            // 
            this.btbGet.FlatAppearance.BorderSize = 0;
            this.btbGet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btbGet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.btbGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btbGet.ForeColor = System.Drawing.Color.Black;
            this.btbGet.Location = new System.Drawing.Point(251, 75);
            this.btbGet.Name = "btbGet";
            this.btbGet.Size = new System.Drawing.Size(75, 23);
            this.btbGet.TabIndex = 2;
            this.btbGet.TabStop = false;
            this.btbGet.Text = "Refresh";
            this.toolTips.SetToolTip(this.btbGet, "Get the weather");
            this.btbGet.UseVisualStyleBackColor = true;
            this.btbGet.Visible = false;
            this.btbGet.Click += new System.EventHandler(this.btbGet_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(325, 75);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.toolTips.SetToolTip(this.btnExit, "Close the application");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.ForeColor = System.Drawing.Color.Black;
            this.btnAbout.Location = new System.Drawing.Point(325, 53);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 0;
            this.btnAbout.TabStop = false;
            this.btnAbout.Text = "About";
            this.toolTips.SetToolTip(this.btnAbout, "Abut..");
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // modAbout
            // 
            this.modAbout.BackColor = System.Drawing.Color.Transparent;
            this.modAbout.Controls.Add(this.panel2);
            this.modAbout.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modAbout.Location = new System.Drawing.Point(70, 120);
            this.modAbout.Name = "modAbout";
            this.modAbout.Size = new System.Drawing.Size(260, 172);
            this.modAbout.TabIndex = 4;
            this.modAbout.TabStop = false;
            this.modAbout.Text = "About";
            this.modAbout.Visible = false;
            this.modAbout.VisibleChanged += new System.EventHandler(this.modAbout_VisibleChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 143);
            this.panel2.TabIndex = 0;
            this.panel2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 115);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student\'s Weather 2.0\r\nGabriel Rotar\r\n\r\nWhat\'s new:\r\n*harmed code";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // update
            // 
            this.update.AutoSize = true;
            this.update.BackColor = System.Drawing.Color.Transparent;
            this.update.Location = new System.Drawing.Point(-3, 387);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(56, 13);
            this.update.TabIndex = 5;
            this.update.Text = "Update in:";
            this.toolTips.SetToolTip(this.update, "Time untill next autoupdate");
            this.update.Visible = false;
            // 
            // getTimer
            // 
            this.getTimer.Interval = 600000;
            this.getTimer.Tick += new System.EventHandler(this.getTimer_Tick);
            // 
            // bgUpdate
            // 
            this.bgUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgUpdate_DoWork);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // toolTips
            // 
            this.toolTips.AutoPopDelay = 5000;
            this.toolTips.InitialDelay = 100;
            this.toolTips.ReshowDelay = 100;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Student\'s Weather 2.0\r\nAutoupdate in:";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::vremea2.Properties.Resources.ex1_png;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.update);
            this.Controls.Add(this.modAbout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.inWork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.Text = "Student\'s Weather 2.0";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.inWork.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.modAbout.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgGetImage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox inWork;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btbGet;
        private System.Windows.Forms.GroupBox modAbout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label update;
        private System.Windows.Forms.Timer getTimer;
        private System.ComponentModel.BackgroundWorker bgUpdate;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.NotifyIcon notifyIcon;

    }
}

