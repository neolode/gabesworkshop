#region Using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
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
        // ReSharper disable FieldCanBeMadeReadOnly.Local
        // ReSharper disable ConvertToConstant.Local
        // ReSharper disable InconsistentNaming
        private string Head = "<html><head><style type=\"text/css\">body{"
                                    + "background: #000;"
                                    + "font-family: Lucida Console, sans-serif;"
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
                            + "font-family: Lucida Console, sans-serif;\n"
                            + "font-size: 11px;\n"
                            + "line-height: 18px;\n"
                            + "color: #aaa;\n}\n</style>\n</head>\n<body>\n";
        // ReSharper restore InconsistentNaming
        // ReSharper restore ConvertToConstant.Local
        // ReSharper restore FieldCanBeMadeReadOnly.Local
        private ProcessCaller _processCaller;
        private bool _ranArgs;

        private StringBuilder _strbuff;
        /// <summary>
        /// Default constructor
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            wb_log.AllowNavigation = true;
            wb_log.Navigate("about:blank");

            if (wb_log.Document != null)
            {
                wb_log.Document.OpenNew(true);
                wb_log.Document.Write(Head);
            }
            lblStatus.Text = string.Empty;
            lblNotices.Text = string.Empty;
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
            string message = e.Text.Replace('\r', ' ');
            if (e.Text.StartsWith("A:"))
            {
                lblStatus.Text = e.Text;
                return;
            }
            if (e.Text.StartsWith("V:"))
            {
                lblStatus.Text = e.Text;
                return;
            }
            if (e.Text.StartsWith("Exiting"))
            {
                lblNotices.Text = e.Text;
                return;
            }
            if (e.Text.StartsWith("Movie-Aspect"))
            {
                lblNotices.Text = e.Text;
                return;
            }
            if (e.Text.StartsWith("VO:"))
            {
                lblNotices.Text = e.Text;
                return;
            }
            if (e.Text.StartsWith("Decreasing video pts:"))
            {
                lblNotices.Text = e.Text;
                return;
            }
            if (e.Text.ToLower().Contains("font"))
            {
                lblStatus.Text = e.Text;
                return;
            }

            foreach (var s in message.Split('\n'))
            {
                if (s.Trim() == string.Empty) continue;
                WbLogAppendText(s.Trim());
            }
        }

        // ReSharper disable FieldCanBeMadeReadOnly.Local
        List<string> _repperr = new List<string>();
        // ReSharper restore FieldCanBeMadeReadOnly.Local
        private string _lasterr = string.Empty;
        private int _errcount;
        private void WriteStreamErr(object sender, DataReceivedEventArgs e)
        {
            string error = e.Text.Trim(new[] { ' ', '\n', '\r' });
            if (error == string.Empty) return;
            if (_lasterr == error) _errcount++;
            else
                if (_errcount != 0)
                {
                    WbLogAppendError("x" + _errcount + 1 + "\n" + error + "\n");
                    _repperr.Add(_lasterr + " ->->-> " + _errcount + 1 + "times");
                    _errcount = 0;
                }
                else
                {
                    WbLogAppendError(error + "\n");
                    _repperr.Add(error);
                }
            _lasterr = error;
        }

        private void WbLogAppendError(string s)
        {
            if (!ckShowErrors.Checked) return;
            _strbuff = new StringBuilder();
            _strbuff.Append("<font color=red>");
            _strbuff.Append(HttpUtility.HtmlEncode(s));
            _strbuff.Append("</font></br>\n");

            if (wb_log.Document == null) return;
            if (wb_log.Document.Body == null) return;

            WbLogAppendHtml(_strbuff.ToString());

            wb_log.Document.Body.ScrollTop = wb_log.Document.Body.ScrollRectangle.Bottom;
        }

        private void WbLogAppendText(string p)
        {
            if (wb_log.Document == null) return;
            if (wb_log.Document.Body == null) return;

            WbLogAppendHtml(HttpUtility.HtmlEncode(p));
            WbLogAppendHtml("</br>");
            wb_log.Document.Body.ScrollTop = wb_log.Document.Body.ScrollRectangle.Bottom;
        }

        private void WbLogAppendHtml(string h)
        {
            // ReSharper disable PossibleNullReferenceException
            wb_log.Document.Write(h);
            wb_log.Document.Body.ScrollTop = wb_log.Document.Body.ScrollRectangle.Bottom;
            // ReSharper restore PossibleNullReferenceException
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
            WbLogAppendError("Critical error!! : Mplayer not present");
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
            WbLogAppendHtml("<pre>");
            WbLogAppendHtml("+---------------------------+\n");
            WbLogAppendHtml("|         Mplayer UI        |\n");
            WbLogAppendHtml("| Gabriel 'Lode' Rotar 2009 |\n");
            WbLogAppendHtml("+---------------------------+\n");
            WbLogAppendHtml("</pre>");
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
            RunCliApp(null);
        }

        private void CmLogClearClick(object sender, EventArgs e)
        {
            if (wb_log.Document == null) return;
            if (wb_log.Document.Body == null) return;

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
                if (args != null) args = args.Trim();
                //Remove if not debuging
                WbLogAppendText("Opening: \n" + args + "\n\n");

                RunCliApp("\"" + args + "\"");
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
        private void RunCliApp(string args)
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

        private void WbLogNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!e.Url.Host.Equals(string.Empty))
                e.Cancel = true;
            if (!e.Url.IsFile) return;
            e.Cancel = true;
            string p = HttpUtility.UrlDecode(e.Url.AbsolutePath);
            FindAndKillProcess("mplayer");
            WbLogAppendText("Opening: \n" + p + "\n\n");
            RunCliApp("\"" + p + "\"");
        }
    }
}