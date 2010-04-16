namespace lightAsp.App
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(currentDomain_AssemblyResolve);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process[] processes = Process.GetProcesses();
            int num = 0;
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName.ToLower().Equals("wikidesktop"))
                {
                    num++;
                }
            }
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

        static System.Reflection.Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return null;
        }
    }
}

