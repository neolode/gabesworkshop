namespace PngSplit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ssssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descLn1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.joinMode = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.modWorking = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.wrkTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.modWorking.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ContextMenuStrip = this.contextMenu;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 195);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.PictureBox1Click);
            // 
            // contextMenu
            // 
            this.contextMenu.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenu.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssssToolStripMenuItem,
            this.descLn1,
            this.toolStripSeparator2,
            this.joinMode});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(256, 130);
            // 
            // ssssToolStripMenuItem
            // 
            this.ssssToolStripMenuItem.Enabled = false;
            this.ssssToolStripMenuItem.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ssssToolStripMenuItem.Name = "ssssToolStripMenuItem";
            this.ssssToolStripMenuItem.Size = new System.Drawing.Size(255, 40);
            this.ssssToolStripMenuItem.Text = "    Png  Split";
            // 
            // descLn1
            // 
            this.descLn1.Enabled = false;
            this.descLn1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.descLn1.Name = "descLn1";
            this.descLn1.Size = new System.Drawing.Size(255, 40);
            this.descLn1.Text = "Splits/Joins a transparent PNG\n   Into/From a 24bit bitmap\n        And an AlphaMa" +
                "p";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(252, 6);
            // 
            // joinMode
            // 
            this.joinMode.CheckOnClick = true;
            this.joinMode.Name = "joinMode";
            this.joinMode.Size = new System.Drawing.Size(255, 40);
            this.joinMode.Text = "Join Mode [ ]";
            this.joinMode.CheckedChanged += new System.EventHandler(this.JoinModeCheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenu;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(855, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.ContextMenuStrip = this.contextMenu;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(0, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(857, 195);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.PictureBox2Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.ContextMenuStrip = this.contextMenu;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(855, 193);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.ContextMenuStrip = this.contextMenu;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(0, 400);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(857, 195);
            this.panel3.TabIndex = 2;
            this.panel3.Click += new System.EventHandler(this.PictureBox3Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.ContextMenuStrip = this.contextMenu;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(855, 193);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3Click);
            // 
            // openFile
            // 
            this.openFile.Filter = "Portable Network Graphics|*.png";
            // 
            // saveFile
            // 
            this.saveFile.DefaultExt = "bmp";
            this.saveFile.Filter = "Bitmap|*.bmp";
            // 
            // modWorking
            // 
            this.modWorking.BackColor = System.Drawing.Color.BurlyWood;
            this.modWorking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modWorking.Controls.Add(this.label1);
            this.modWorking.Controls.Add(this.lblProgress);
            this.modWorking.ForeColor = System.Drawing.Color.Brown;
            this.modWorking.Location = new System.Drawing.Point(341, 274);
            this.modWorking.Name = "modWorking";
            this.modWorking.Size = new System.Drawing.Size(175, 47);
            this.modWorking.TabIndex = 5;
            this.modWorking.Visible = false;
            this.modWorking.Click += new System.EventHandler(this.ModWorkingClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Working..";
            this.label1.Click += new System.EventHandler(this.ModWorkingClick);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(3, 30);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(47, 11);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "label1";
            this.lblProgress.Click += new System.EventHandler(this.ModWorkingClick);
            // 
            // wrkTime
            // 
            this.wrkTime.Interval = 500;
            this.wrkTime.Tick += new System.EventHandler(this.WrkTimeTick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 595);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.modWorking);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Png/Split";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.modWorking.ResumeLayout(false);
            this.modWorking.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ssssToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descLn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem joinMode;
        private System.Windows.Forms.Panel modWorking;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Timer wrkTime;
        private System.Windows.Forms.Label label1;
    }
}

