using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace mpui
{

    public partial class FrmMain : Form
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cm_log = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cm_log_save = new System.Windows.Forms.ToolStripMenuItem();
            this.cm_log_clear = new System.Windows.Forms.ToolStripMenuItem();
            this.of_frm = new System.Windows.Forms.OpenFileDialog();
            this.fb_frm = new System.Windows.Forms.FolderBrowserDialog();
            this.sf_frm = new System.Windows.Forms.SaveFileDialog();
            this.wb_log = new System.Windows.Forms.WebBrowser();
            this.brpStatusBar = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpToolBar = new System.Windows.Forms.GroupBox();
            this.btnTerminate = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.cm_log.SuspendLayout();
            this.brpStatusBar.SuspendLayout();
            this.grpToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cm_log
            // 
            this.cm_log.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cm_log_save,
            this.cm_log_clear});
            this.cm_log.Name = "cm_log";
            this.cm_log.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cm_log.ShowImageMargin = false;
            this.cm_log.Size = new System.Drawing.Size(100, 48);
            // 
            // cm_log_save
            // 
            this.cm_log_save.Name = "cm_log_save";
            this.cm_log_save.Size = new System.Drawing.Size(99, 22);
            this.cm_log_save.Text = "Save Log";
            this.cm_log_save.Click += new System.EventHandler(this.CmLogSaveClick);
            // 
            // cm_log_clear
            // 
            this.cm_log_clear.Name = "cm_log_clear";
            this.cm_log_clear.Size = new System.Drawing.Size(99, 22);
            this.cm_log_clear.Text = "Clear Log";
            this.cm_log_clear.Click += new System.EventHandler(this.CmLogClearClick);
            // 
            // of_frm
            // 
            this.of_frm.Filter = "All files|*.*";
            this.of_frm.Title = "Open Inno Setup/Archive";
            // 
            // fb_frm
            // 
            this.fb_frm.Description = "Select destination folder";
            // 
            // sf_frm
            // 
            this.sf_frm.DefaultExt = "txt";
            this.sf_frm.Filter = "Html|*.htm";
            this.sf_frm.Title = "Save log file";
            // 
            // wb_log
            // 
            this.wb_log.AllowNavigation = false;
            this.wb_log.ContextMenuStrip = this.cm_log;
            this.wb_log.IsWebBrowserContextMenuEnabled = false;
            this.wb_log.Location = new System.Drawing.Point(0, 28);
            this.wb_log.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_log.Name = "wb_log";
            this.wb_log.ScriptErrorsSuppressed = true;
            this.wb_log.Size = new System.Drawing.Size(589, 375);
            this.wb_log.TabIndex = 1;
            this.wb_log.TabStop = false;
            this.wb_log.WebBrowserShortcutsEnabled = false;
            this.wb_log.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_log_Navigating);
            // 
            // brpStatusBar
            // 
            this.brpStatusBar.Controls.Add(this.lblStatus);
            this.brpStatusBar.Location = new System.Drawing.Point(12, 399);
            this.brpStatusBar.Name = "brpStatusBar";
            this.brpStatusBar.Size = new System.Drawing.Size(565, 26);
            this.brpStatusBar.TabIndex = 0;
            this.brpStatusBar.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Location = new System.Drawing.Point(6, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "label1";
            // 
            // grpToolBar
            // 
            this.grpToolBar.Controls.Add(this.btnTerminate);
            this.grpToolBar.Controls.Add(this.btnAbout);
            this.grpToolBar.Controls.Add(this.btnExit);
            this.grpToolBar.Controls.Add(this.btnInfo);
            this.grpToolBar.Location = new System.Drawing.Point(12, -4);
            this.grpToolBar.Name = "grpToolBar";
            this.grpToolBar.Size = new System.Drawing.Size(565, 30);
            this.grpToolBar.TabIndex = 2;
            this.grpToolBar.TabStop = false;
            // 
            // btnTerminate
            // 
            this.btnTerminate.FlatAppearance.BorderSize = 0;
            this.btnTerminate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnTerminate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnTerminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminate.Location = new System.Drawing.Point(2, 8);
            this.btnTerminate.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(62, 20);
            this.btnTerminate.TabIndex = 0;
            this.btnTerminate.Text = "Terminate";
            this.btnTerminate.UseVisualStyleBackColor = true;
            this.btnTerminate.Click += new System.EventHandler(this.TsBtnTerminateClick);
            // 
            // btnAbout
            // 
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Location = new System.Drawing.Point(439, 8);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(62, 20);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.TsBtnAboutClick);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(501, 8);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 20);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.TsBtnExitClick);
            // 
            // btnInfo
            // 
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Location = new System.Drawing.Point(377, 8);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(62, 20);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "Mplayer";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.TsBtnInnounpClick);
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(589, 428);
            this.Controls.Add(this.wb_log);
            this.Controls.Add(this.brpStatusBar);
            this.Controls.Add(this.grpToolBar);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Mplayer UI";
            this.Load += new System.EventHandler(this.FrmMainLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainFormClosing);
            this.cm_log.ResumeLayout(false);
            this.brpStatusBar.ResumeLayout(false);
            this.brpStatusBar.PerformLayout();
            this.grpToolBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        [STAThread]
        private static void Main(string[] args)
        {
            //try
            //{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show(x.Message);

            //}
        }
        // ReSharper disable InconsistentNaming
        private OpenFileDialog of_frm;
        private FolderBrowserDialog fb_frm;
        private ContextMenuStrip cm_log;
        private ToolStripMenuItem cm_log_save;
        private ToolStripMenuItem cm_log_clear;
        private SaveFileDialog sf_frm;
        private WebBrowser wb_log;
        private IContainer components;
        private GroupBox brpStatusBar;
        private Label lblStatus;
        private GroupBox grpToolBar;
        private Button btnInfo;
        private Button btnExit;
        private Button btnAbout;
        private Button btnTerminate;
        // ReSharper restore InconsistentNaming
    }
}