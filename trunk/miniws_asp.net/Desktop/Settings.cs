using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace lightAsp.Desktop
{
    public static class Settings
    {
        private static Dictionary<string, string> _settings = new Dictionary<string, string>();

        private static readonly string SettingsFile = Application.StartupPath + @"\Settings.xml";
                              //(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\ScrewTurn Software\ASP.net Light Server\Settings.txt");

        public static string GetSetting(string name)
        {
            string str;
            if (_settings.TryGetValue(name, out str))
            {
                return str;
            }
            return null;
        }

        public static void Load()
        {
            FileStream stream = null;
            _settings = new Dictionary<string, string>();
            try
            {
                stream = new FileStream(SettingsFile, FileMode.Open, FileAccess.Read, FileShare.None);
                var reader = new StreamReader(stream, Encoding.UTF8);
                string str = reader.ReadToEnd();
                reader.Close();
                string[] strArray = str.Split(new[] {'\n'});
                foreach (var t in strArray)
                {
                    var strArray2 = t.Split(new[] {'='});
                    _settings.Add(strArray2[0].Trim(), strArray2[1].Trim());
                }
            }
            catch
            {
                throw new Exception("Unable to load Settings.");
            }
            finally
            {
                try
                {
                    stream.Close();
                }
                catch
                {
                }
            }
        }

        public static void Save()
        {
            if (!Directory.Exists(Path.GetDirectoryName(SettingsFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(SettingsFile));
            }
            FileStream stream = null;
            try
            {
                stream = new FileStream(SettingsFile, FileMode.Create, FileAccess.Write, FileShare.None);
                var array = new string[_settings.Keys.Count];
                _settings.Keys.CopyTo(array, 0);
                string s = "";
                for (int i = 0; i < array.Length; i++)
                {
                    s = s + array[i] + "=" + _settings[array[i]];
                    if (i != (array.Length - 1))
                    {
                        s = s + "\n";
                    }
                }
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch
            {
                throw new Exception("Unable to save Settings.");
            }
            finally
            {
                try
                {
                    stream.Close();
                }
                catch
                {
                }
            }
        }

        public static void SetSetting(string name, string value)
        {
            _settings[name] = value;
        }
    }
}