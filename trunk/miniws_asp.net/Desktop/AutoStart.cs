using System.Windows.Forms;
using Microsoft.Win32;

namespace lightAsp.Desktop
{
    public class AutoStart
    {
        public static bool AutoStartEnabled
        {
            get
            {
                return Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                                         "ScrewTurnWikiDesktop", null) != null;
            }
        }

        public static void SetAutostart(bool enable)
        {
            if (!enable)
            {
                // ReSharper disable PossibleNullReferenceException
                Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true).DeleteValue(
                    "ScrewTurnWikiDesktop", false);
                // ReSharper restore PossibleNullReferenceException
            }
            else
            {
                string str = "\"" + Application.ExecutablePath + " /start\"";
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                                  "ScrewTurnWikiDesktop", str, RegistryValueKind.String);
            }
        }
    }
}