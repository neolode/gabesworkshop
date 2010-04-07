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
            this.btnTerminate = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNotices = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckShowErrors = new System.Windows.Forms.CheckBox();
            this.cm_log.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cm_log
            // 
            this.cm_log.BackColor = System.Drawing.Color.White;
            this.cm_log.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cm_log.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cm_log_save,
            this.cm_log_clear});
            this.cm_log.Name = "cm_log";
            this.cm_log.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cm_log.ShowImageMargin = false;
            this.cm_log.Size = new System.Drawing.Size(109, 48);
            // 
            // cm_log_save
            // 
            this.cm_log_save.Name = "cm_log_save";
            this.cm_log_save.Size = new System.Drawing.Size(108, 22);
            this.cm_log_save.Text = "Save Log";
            this.cm_log_save.Click += new System.EventHandler(this.CmLogSaveClick);
            // 
            // cm_log_clear
            // 
            this.cm_log_clear.Name = "cm_log_clear";
            this.cm_log_clear.Size = new System.Drawing.Size(108, 22);
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
            this.wb_log.Location = new System.Drawing.Point(-1, 26);
            this.wb_log.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_log.Name = "wb_log";
            this.wb_log.ScriptErrorsSuppressed = true;
            this.wb_log.Size = new System.Drawing.Size(589, 380);
            this.wb_log.TabIndex = 1;
            this.wb_log.TabStop = false;
            this.wb_log.WebBrowserShortcutsEnabled = false;
            this.wb_log.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WbLogNavigating);
            // 
            // btnTerminate
            // 
            this.btnTerminate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTerminate.FlatAppearance.BorderSize = 0;
            this.btnTerminate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnTerminate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnTerminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminate.Location = new System.Drawing.Point(0, 0);
            this.btnTerminate.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(81, 23);
            this.btnTerminate.TabIndex = 0;
            this.btnTerminate.Text = "Terminate";
            this.btnTerminate.UseVisualStyleBackColor = true;
            this.btnTerminate.Click += new System.EventHandler(this.TsBtnTerminateClick);
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Location = new System.Drawing.Point(462, 0);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(62, 23);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.TsBtnAboutClick);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(524, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.TsBtnExitClick);
            // 
            // btnInfo
            // 
            this.btnInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Location = new System.Drawing.Point(400, 0);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(62, 23);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "Mplayer";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.TsBtnInnounpClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNotices);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 14);
            this.panel1.TabIndex = 3;
            // 
            // lblNotices
            // 
            this.lblNotices.AutoSize = true;
            this.lblNotices.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNotices.Location = new System.Drawing.Point(505, 0);
            this.lblNotices.Name = "lblNotices";
            this.lblNotices.Size = new System.Drawing.Size(82, 11);
            this.lblNotices.TabIndex = 2;
            this.lblNotices.Text = "lbl notices";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 11);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "lbl status";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ckShowErrors);
            this.panel2.Controls.Add(this.btnTerminate);
            this.panel2.Controls.Add(this.btnInfo);
            this.panel2.Controls.Add(this.btnAbout);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 25);
            this.panel2.TabIndex = 4;
            // 
            // ckShowErrors
            // 
            this.ckShowErrors.AutoSize = true;
            this.ckShowErrors.Checked = true;
            this.ckShowErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckShowErrors.Location = new System.Drawing.Point(84, 5);
            this.ckShowErrors.Name = "ckShowErrors";
            this.ckShowErrors.Size = new System.Drawing.Size(101, 15);
            this.ckShowErrors.TabIndex = 4;
            this.ckShowErrors.Text = "Show errors";
            this.ckShowErrors.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 11);
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(589, 421);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.wb_log);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private Button btnInfo;
        private Button btnExit;
        private Button btnAbout;
        private Button btnTerminate;
        private Panel panel1;
        private Label lblNotices;
        private Label lblStatus;
        private Panel panel2;
        private CheckBox ckShowErrors;
        // ReSharper restore InconsistentNaming
    }
}