using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace gs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(currentDomain_AssemblyResolve);
            Application.Run(new FrmMain());
        }

        static System.Reflection.Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //Load the assembly from the specified path. 					
            Assembly MyAssembly = Assembly.LoadFrom(Application.StartupPath + @"\webkit\WebKitBrowser.dll");

            //Return the loaded assembly.
            return MyAssembly;
        }
    }
}
