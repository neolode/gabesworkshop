using System;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using Microsoft.Win32;

namespace lightAsp.WebServer
{
    public class Server : MarshalByRefObject
    {
        private bool _disallowRemoteConnections;
        private Host _host;
        private string _installPath;
        private string _physicalPath;
        private int _port;
        private WaitCallback _restartCallback;
        private bool _running;
        private string _virtualPath;

        public Server(int port, string virtualPath, string physicalPath, bool disallowRemoteConnections)
        {
            _port = port;
            _virtualPath = virtualPath;
            _physicalPath = physicalPath.EndsWith(@"\") ? physicalPath : (physicalPath + @"\");
            _disallowRemoteConnections = disallowRemoteConnections;
            _restartCallback = new WaitCallback(RestartCallback);
            _installPath = GetInstallPathAndConfigureAspNetIfNeeded();
            CreateHost();
        }

        public string InstallPath
        {
            get { return _installPath; }
        }

        public string PhysicalPath
        {
            get { return _physicalPath; }
        }

        public int Port
        {
            get { return _port; }
        }

        public string RootUrl
        {
            get { return ("http://localhost" + ((_port != 80) ? (":" + _port) : "") + _virtualPath); }
        }

        public bool Running
        {
            get { return _running; }
        }

        public string VirtualPath
        {
            get { return _virtualPath; }
        }

        private void CreateHost()
        {
            _host = (Host) ApplicationHost.CreateApplicationHost(typeof (Host), _virtualPath, _physicalPath);
            _host.Configure(this, _port, _virtualPath, _physicalPath, _installPath, _disallowRemoteConnections);
        }

        private string GetInstallPathAndConfigureAspNetIfNeeded()
        {
            RegistryKey key = null;
            RegistryKey key2 = null;
            RegistryKey key3 = null;
            string str = null;
            try
            {
                FileVersionInfo versionInfo =
                    FileVersionInfo.GetVersionInfo(typeof (HttpRuntime).Module.FullyQualifiedName);
                string str2 = string.Format("{0}.{1}.{2}.{3}",
                                            new object[]
                                                {
                                                    versionInfo.FileMajorPart, versionInfo.FileMinorPart,
                                                    versionInfo.FileBuildPart, versionInfo.FilePrivatePart
                                                });
                string name = @"Software\Microsoft\ASP.NET\" + str2;
                if (!str2.StartsWith("1.0."))
                {
                    name = name.Substring(0, name.LastIndexOf('.') + 1) + "0";
                }
                key2 = Registry.LocalMachine.OpenSubKey(name);
                if (key2 != null)
                {
                    return (string) key2.GetValue("Path");
                }
                key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\ASP.NET");
                if (key == null)
                {
                    Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\ASP.NET").SetValue("RootVer", str2);
                }
                string str4 = "v" + str2.Substring(0, str2.LastIndexOf('.'));
                key3 = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\.NETFramework");
                var str5 = (string) key3.GetValue("InstallRoot");
                if (str5.EndsWith(@"\"))
                {
                    str5 = str5.Substring(0, str5.Length - 1);
                }
                key2 = Registry.LocalMachine.CreateSubKey(name);
                str = str5 + @"\" + str4;
                key2.SetValue("Path", str);
                key2.SetValue("DllFullPath", str + @"\aspnet_isapi.dll");
            }
            catch
            {
            }
            finally
            {
                if (key2 != null)
                {
                    key2.Close();
                }
                if (key != null)
                {
                    key.Close();
                }
                if (key3 != null)
                {
                    key3.Close();
                }
            }
            return str;
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void Restart()
        {
            ThreadPool.QueueUserWorkItem(_restartCallback);
        }

        private void RestartCallback(object unused)
        {
            CreateHost();
            Start();
        }

        public void Start()
        {
            if (_host != null)
            {
                _host.Start();
                _running = true;
            }
        }

        public void Stop()
        {
            if (_host != null)
            {
                try
                {
                    _host.Stop();
                    _running = false;
                }
                catch
                {
                }
            }
        }
    }
}