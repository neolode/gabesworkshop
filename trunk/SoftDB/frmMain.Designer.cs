namespace SoftDB
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
            this.tsSideBar = new System.Windows.Forms.ToolStrip();
            this.btnBarSearch = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectVaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.lstSoftware = new System.Windows.Forms.ListView();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colLocation = new System.Windows.Forms.ColumnHeader();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.htmlDetails = new System.Windows.Forms.HtmlPanel();
            this.tsSideBar.SuspendLayout();
            this.menuSearch.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpList.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsSideBar
            // 
            this.tsSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsSideBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSideBar.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.tsSideBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBarSearch,
            this.btnExit,
            this.btnAbout,
            this.toolStripDropDownButton1});
            this.tsSideBar.Location = new System.Drawing.Point(0, 0);
            this.tsSideBar.Name = "tsSideBar";
            this.tsSideBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsSideBar.Size = new System.Drawing.Size(51, 564);
            this.tsSideBar.TabIndex = 0;
            this.tsSideBar.Text = "tsSideBar";
            // 
            // btnBarSearch
            // 
            this.btnBarSearch.AutoSize = false;
            this.btnBarSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBarSearch.Image = global::SoftDB.Properties.Resources.search;
            this.btnBarSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBarSearch.Name = "btnBarSearch";
            this.btnBarSearch.Size = new System.Drawing.Size(50, 50);
            this.btnBarSearch.Text = "Search...";
            this.btnBarSearch.Visible = false;
            this.btnBarSearch.Click += new System.EventHandler(this.btnBarSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.AutoSize = false;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = global::SoftDB.Properties.Resources.exit;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 50);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAbout.AutoSize = false;
            this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbout.Image = global::SoftDB.Properties.Resources.info;
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(50, 50);
            this.btnAbout.Text = "About...";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.yToolStripMenuItem,
            this.zToolStripMenuItem,
            this.zzToolStripMenuItem,
            this.selectVaultToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(61, 54);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Visible = false;
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.xToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.xToolStripMenuItem.Text = "Search";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.yToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.yToolStripMenuItem.Text = "Add";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // zToolStripMenuItem
            // 
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.zToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.zToolStripMenuItem.Text = "Edit";
            this.zToolStripMenuItem.Click += new System.EventHandler(this.zToolStripMenuItem_Click);
            // 
            // zzToolStripMenuItem
            // 
            this.zzToolStripMenuItem.Name = "zzToolStripMenuItem";
            this.zzToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.zzToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.zzToolStripMenuItem.Text = "Delete";
            this.zzToolStripMenuItem.Click += new System.EventHandler(this.zzToolStripMenuItem_Click);
            // 
            // selectVaultToolStripMenuItem
            // 
            this.selectVaultToolStripMenuItem.Name = "selectVaultToolStripMenuItem";
            this.selectVaultToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.selectVaultToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.selectVaultToolStripMenuItem.Text = "SelectVault";
            this.selectVaultToolStripMenuItem.Click += new System.EventHandler(this.selectVaultToolStripMenuItem_Click);
            // 
            // menuSearch
            // 
            this.menuSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.clearToolStripMenuItem});
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuSearch.ShowImageMargin = false;
            this.menuSearch.Size = new System.Drawing.Size(236, 52);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Margin = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.AutoSize = false;
            this.clearToolStripMenuItem.Margin = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(200, 23);
            this.clearToolStripMenuItem.Text = "clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(51, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpDetails);
            this.splitContainer1.Size = new System.Drawing.Size(760, 564);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 5;
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.lstSoftware);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 0);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(365, 564);
            this.grpList.TabIndex = 4;
            this.grpList.TabStop = false;
            this.grpList.Text = "Soft list";
            // 
            // lstSoftware
            // 
            this.lstSoftware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSoftware.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colLocation});
            this.lstSoftware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSoftware.FullRowSelect = true;
            this.lstSoftware.GridLines = true;
            this.lstSoftware.Location = new System.Drawing.Point(3, 16);
            this.lstSoftware.Name = "lstSoftware";
            this.lstSoftware.Size = new System.Drawing.Size(359, 545);
            this.lstSoftware.TabIndex = 4;
            this.lstSoftware.UseCompatibleStateImageBehavior = false;
            this.lstSoftware.View = System.Windows.Forms.View.Details;
            this.lstSoftware.SelectedIndexChanged += new System.EventHandler(this.lstSoftware_SelectedIndexChanged);
            this.lstSoftware.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstSoftware_ColumnClick);
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 247;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 90;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.htmlDetails);
            this.grpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetails.Location = new System.Drawing.Point(0, 0);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(391, 564);
            this.grpDetails.TabIndex = 3;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Details";
            // 
            // htmlDetails
            // 
            this.htmlDetails.AutoScroll = true;
            this.htmlDetails.AutoScrollMinSize = new System.Drawing.Size(385, 0);
            this.htmlDetails.BackColor = System.Drawing.Color.Black;
            this.htmlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlDetails.Location = new System.Drawing.Point(3, 16);
            this.htmlDetails.Name = "htmlDetails";
            this.htmlDetails.Size = new System.Drawing.Size(385, 545);
            this.htmlDetails.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 564);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsSideBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Soft DB";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tsSideBar.ResumeLayout(false);
            this.tsSideBar.PerformLayout();
            this.menuSearch.ResumeLayout(false);
            this.menuSearch.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSideBar;
        private System.Windows.Forms.ToolStripButton btnBarSearch;
        private System.Windows.Forms.ContextMenuStrip menuSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectVaultToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.ListView lstSoftware;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.HtmlPanel htmlDetails;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}

