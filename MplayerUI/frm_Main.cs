#region Using

using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Windows.Forms;

#endregion

namespace mpui
{
    /// <summary>
    /// A simple form to launch a process using ProcessCaller
    /// and display all StdOut and StdErr in a RichTextBox.
    /// </summary>
    public partial class FrmMain
    {
        private string Head = "<html><head><style type=\"text/css\">body{"
                                    + "background: #000;"
                                    + "font-family: Helvetica, sans-serif;"
                                    + "font-size: 11px;"
                                    + "line-height: 18px;"
                                    + "color: #aaa;"
                                    + "scrollbar-3dlight-color:c0c0c0;"
                                    + "scrollbar-shadow-color:#aaa;"
                                    + "scrollbar-face-color:ffffff;"
                                    + "scrollbar-darkshadow-color:b0b0b0;"
                                    + "scrollbar-track-color:#000;"
                                    + "scrollbar-arrow-color:#aaa;"
                                    + "scrollbar-highlight-color:#aaa;"
                                    + "background-image:url('" + Application.StartupPath + "\\branding.png');"
                                    + "background-repeat:no-repeat;"
                                    + "background-position:center center;"
                                    + "background-attachment:fixed}</style></head><body>";
        private string saveHead = "<html>\n<head>\n<style type=\"text/css\">\nbody{\n"
                            + "background: #000;\n"
                            + "font-family: Helvetica, sans-serif;\n"
                            + "font-size: 11px;\n"
                            + "line-height: 18px;\n"
                            + "color: #aaa;\n}\n</style>\n</head>\n<body>\n";
        private ProcessCaller _processCaller;
        private bool _ranArgs;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            wb_log.AllowNavigation = true;
            wb_log.Navigate("about:blank");

            wb_log.Document.OpenNew(true);
            wb_log.Document.Write(Head);
            lblStatus.Text = string.Empty;
        }

        /// <summary>
        /// Handles the events of StdErrReceived and StdOutReceived.
        /// </summary>
        /// <remarks>
        /// If stderr were handled in a separate function, it could possibly
        /// be displayed in red in the richText box, but that is beyond 
        /// the scope of this demo.
        /// </remarks>
        private void WriteStreamInfo(object sender, DataReceivedEventArgs e)
        {
            if (e.Text.StartsWith("A:"))
                lblStatus.Text = e.Text;
            else if (e.Text.StartsWith("V:"))
                lblStatus.Text = e.Text;
            else if (e.Text.StartsWith("A:"))
                lblStatus.Text = e.Text;
            else
            {
                WbLogAppendText(e.Text + "\n");
            }
        }

        private void WriteStreamErr(object sender, DataReceivedEventArgs e)
        {
            WbLogAppendError(e.Text + "\n");
        }

        private void WbLogAppendError(string s)
        {
            wb_log.Document.Write("<font color=red>" + (HttpUtility.HtmlEncode(s).Replace("\n", "</br>")) + "</font>\n");
            wb_log.Document.Body.ScrollTop = wb_log.Document.Body.ScrollRectangle.Bottom;
        }

        private void WbLogAppendText(string p)
        {
            wb_log.Document.Write(HttpUtility.HtmlEncode(p).Replace("\n", "</br>\n"));
            wb_log.Document.Body.ScrollTop = wb_log.Document.Body.ScrollRectangle.Bottom;
        }


        /// <summary>
        /// Handles the events of processCompleted and processCanceled
        /// </summary>
        private void ProcessCompletedOrCanceled(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            btnInfo.Enabled = true;
            lblStatus.Tag = string.Empty;
            if (_ranArgs)
            {
                //MessageBox.Show(":)");
                Close();
            }
        }

        /// <summary>
        /// Handles the events of ProcessFailed
        /// </summary>
        private void ProcessFailed(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            btnInfo.Enabled = true;
            MessageBox.Show("Mplayer not present", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TsBtnExitClick(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void TsBtnAboutClick(object sender, EventArgs e)
        {
            MessageBox.Show("Mplayer UI\n(c)Gabriel 'Lode' Rotar 2009");
        }


        private void TsBtnTerminateClick(object sender, EventArgs e)
        {
            if (_processCaller != null)
            {
                _processCaller.Cancel();
            }
        }

        private void TsBtnInnounpClick(object sender, EventArgs e)
        {
            CallConsole(null);
        }

        private void CmLogClearClick(object sender, EventArgs e)
        {
            //wb_log.AllowNavigation = true;
            //wb_log.Navigate("about:blank");
            wb_log.Document.OpenNew(true);
            wb_log.Document.Write(Head);
        }

        private void CmLogSaveClick(object sender, EventArgs e)
        {
            sf_frm.FileName = _processCaller.FileName.Remove(_processCaller.FileName.LastIndexOf("."));
            if (sf_frm.ShowDialog() == DialogResult.Cancel)
                return;
            TextWriter tx = new StreamWriter(sf_frm.FileName);
            tx.Write(saveHead + wb_log.DocumentText.Substring(wb_log.DocumentText.IndexOf("y>") + 2) + "</body>\n</html>\n");
            tx.Flush();
            tx.Close();
            tx.Dispose();
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                string args = null;
                for (int i = 1; i < Environment.GetCommandLineArgs().Length; i++)
                    args = args + " " + Environment.GetCommandLineArgs()[i];
                args = args.Trim();
                //Remove if not debuging
                WbLogAppendText("Opening: \n" + args + "\n\n");

                CallConsole("\"" + args + "\"");
                _ranArgs = false;
            }
        }

        private void FrmMainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (FindAndKillProcess("mplayer"))
            {
                e.Cancel = true;
                //_processCaller.
                //while (_processCaller != null) _processCaller.Cancel();
                //FrmMainFormClosing(sender, e);
                //_processCaller.Cancelled += processCaller_Cancelled;
                //_processCaller.Completed += processCaller_Completed;
                Close();
            }
        }

        public bool FindAndKillProcess(string name)
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes by using the StartsWith Method,
                //this prevents us from incluing the .EXE for the process we're looking for.
                //. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running
                if (clsProcess.ProcessName.Equals(name))
                {
                    //since we found the proccess we now need to use the
                    //Kill Method to kill the process. Remember, if you have
                    //the process running more than once, say IE open 4
                    //times the loop thr way it is now will close all 4,
                    //if you want it to just close the first one it finds
                    //then add a return; after the Kill
                    try
                    {
                        clsProcess.Kill();
                        clsProcess.WaitForExit(10);
                    }
                    catch (Exception)
                    {
                        FindAndKillProcess("mplayer");
                    }
                    //process killed, return true
                    return true;
                }
            }
            //process not found, return false
            return false;
        }

        #region CallConsole

        /// <summary>
        /// Fully transparent parameter transmision to the Inno Unpacker
        /// </summary>
        private void CallConsole(string args)
        {
            Cursor = Cursors.AppStarting;
            btnInfo.Enabled = false;

            _processCaller = new ProcessCaller(this) { FileName = @"mplayer.exe", Arguments = args };
            _processCaller.StdErrReceived += WriteStreamErr;
            _processCaller.StdOutReceived += WriteStreamInfo;
            _processCaller.Completed += ProcessCompletedOrCanceled;
            _processCaller.Cancelled += ProcessCompletedOrCanceled;
            _processCaller.Failed += ProcessFailed;

            // the following function starts a process and returns immediately,
            // thus allowing the form to stay responsive.
            _processCaller.Start();
        }

        #endregion

        private void wb_log_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!e.Url.Host.Equals(string.Empty))
                e.Cancel = true;
            if (!e.Url.IsFile) return;
            e.Cancel = true;
            string p = HttpUtility.UrlDecode(e.Url.AbsolutePath);
            FindAndKillProcess("mplayer");
            WbLogAppendText("Opening: \n" + p + "\n\n");
            CallConsole("\"" + p + "\"");
        }
    }
}