using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace miniws
{
    static class Program
    {

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            IntPtr hWnd = FindWindow(null, Console.Title);
            //Hide the window                   
            ShowWindow(hWnd, 0);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MiniwsForm());
        }
    }
}
