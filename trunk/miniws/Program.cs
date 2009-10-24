using System;
using System.Windows.Forms;

namespace miniws
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //MessageBox.Show(args.Length.ToString());

            //if (args.Length <= 0)
            //{
            //    Random rx = new Random(DateTime.Now.Second);
            //    string arg = rx.Next(10000, 99999).ToString();

            //    File.Create(Environment.GetFolderPath
            //        (Environment.SpecialFolder.ApplicationData) +"\\"+ arg + ".lock").Close();

            //    MessageBox.Show(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + arg + ".lock").ToString());

            //}
            //else
            //{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MessageBox.Show(Process.GetCurrentProcess().MainWindowTitle);
            Application.Run(new TrayServer());
            //}
        }
    }
}
