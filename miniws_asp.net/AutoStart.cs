namespace lightAsp
{
    using Microsoft.Win32;
    using System;
    using System.Windows.Forms;

    public class AutoStart
    {
        public static void SetAutostart(bool enable)
        {
            if (!enable)
            {
                Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true).DeleteValue("ScrewTurnWikiDesktop", false);
            }
            else
            {
                string str = "\"" + Application.ExecutablePath + " /start\"";
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "ScrewTurnWikiDesktop", str, RegistryValueKind.String);
            }
        }

        public static bool AutoStartEnabled
        {
            get
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "ScrewTurnWikiDesktop", null) == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}

