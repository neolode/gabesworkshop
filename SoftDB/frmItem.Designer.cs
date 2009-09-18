namespace SoftDB
{
    partial class FrmItem
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
            this.picBoxart = new System.Windows.Forms.PictureBox();
            this.cmPic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.browseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.previousMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxart)).BeginInit();
            this.cmPic.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxart
            // 
            this.picBoxart.BackColor = System.Drawing.Color.White;
            this.picBoxart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxart.ContextMenuStrip = this.cmPic;
            this.picBoxart.Location = new System.Drawing.Point(12, 23);
            this.picBoxart.Name = "picBoxart";
            this.picBoxart.Size = new System.Drawing.Size(159, 240);
            this.picBoxart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxart.TabIndex = 0;
            this.picBoxart.TabStop = false;
            this.picBoxart.MouseLeave += new System.EventHandler(this.picBoxart_MouseLeave);
            this.picBoxart.MouseEnter += new System.EventHandler(this.picBoxart_MouseEnter);
            // 
            // cmPic
            // 
            this.cmPic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseMenuItem,
            this.previousMenuItem,
            this.xMenuItem});
            this.cmPic.Name = "cmPic";
            this.cmPic.ShowImageMargin = false;
            this.cmPic.Size = new System.Drawing.Size(128, 92);
            // 
            // browseMenuItem
            // 
            this.browseMenuItem.Name = "browseMenuItem";
            this.browseMenuItem.Size = new System.Drawing.Size(127, 22);
            this.browseMenuItem.Text = "...";
            this.browseMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // xMenuItem
            // 
            this.xMenuItem.Name = "xMenuItem";
            this.xMenuItem.Size = new System.Drawing.Size(127, 22);
            this.xMenuItem.Text = "x";
            this.xMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(177, 39);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(187, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(177, 80);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(187, 20);
            this.txtLoc.TabIndex = 2;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(177, 120);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(187, 120);
            this.txtDesc.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Box-art:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(289, 246);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // previousMenuItem
            // 
            this.previousMenuItem.Name = "previousMenuItem";
            this.previousMenuItem.Size = new System.Drawing.Size(127, 22);
            this.previousMenuItem.Text = ":::";
            this.previousMenuItem.Click += new System.EventHandler(this.previousMenuItem_Click);
            // 
            // FrmItem
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 273);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.picBoxart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmItem";
            this.Load += new System.EventHandler(this.FrmItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxart)).EndInit();
            this.cmPic.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxart;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ContextMenuStrip cmPic;
        private System.Windows.Forms.ToolStripMenuItem browseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMenuItem;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.ToolStripMenuItem previousMenuItem;
    }
}