using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace lightAsp.Desktop
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process[] processes = Process.GetProcesses();
            int num = processes.Count(t => t.ProcessName.ToLower().Equals("wikidesktop"));
            if (num <= 1)
            {
                try
                {
                    Settings.Load();
                }
                catch
                {
                }
                bool autostart = false;
                bool open = false;
                if ((Settings.GetSetting("AutoStart") != null) && bool.Parse(Settings.GetSetting("AutoStart")))
                {
                    autostart = true;
                }
                if ((args.Length > 0) && args[0].ToLower().Equals("/open"))
                {
                    autostart = true;
                    open = true;
                }
                if ((args.Length == 3) || (args.Length == 4))
                {
                    Settings.SetSetting("PhysicalDirectory", args[0]);
                    Settings.SetSetting("VirtualDirectory", args[1]);
                    Settings.SetSetting("Port", args[2]);
                    if ((args.Length == 4) && args[3].ToLower().Equals("/open"))
                    {
                        autostart = true;
                        open = true;
                    }
                }
                Application.Run(new FrmMain(autostart, open));
            }
        }

        static System.Reflection.Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return null;
        }
    }
}

