using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web;

namespace lightAsp.WebServer
{
    internal class Host : MarshalByRefObject
    {
        private bool _disallowRemoteConnections;
        private string _installPath;
        private string _lowerCasedClientScriptPathWithTrailingSlashV10;
        private string _lowerCasedClientScriptPathWithTrailingSlashV11;
        private string _lowerCasedVirtualPath;
        private string _lowerCasedVirtualPathWithTrailingSlash;
        private EventHandler _onAppDomainUnload;
        private WaitCallback _onSocketAccept;
        private WaitCallback _onStart;
        private string _physicalClientScriptPath;
        private string _physicalPath;
        private int _port;
        private Server _server;
        private Socket _socket;
        private bool _started;
        private bool _stopped;
        private string _virtualPath;

        public string InstallPath
        {
            get { return _installPath; }
        }

        public string NormalizedVirtualPath
        {
            get { return _lowerCasedVirtualPathWithTrailingSlash; }
        }

        public string PhysicalClientScriptPath
        {
            get { return _physicalClientScriptPath; }
        }

        public string PhysicalPath
        {
            get { return _physicalPath; }
        }

        public int Port
        {
            get { return _port; }
        }

        public string VirtualPath
        {
            get { return _virtualPath; }
        }

        public void Configure(Server server, int port, string virtualPath, string physicalPath, string installPath,
                              bool disallowRemoteConnections)
        {
            _server = server;
            _disallowRemoteConnections = disallowRemoteConnections;
            _port = port;
            _virtualPath = virtualPath;
            _lowerCasedVirtualPath = CultureInfo.InvariantCulture.TextInfo.ToLower(_virtualPath);
            _lowerCasedVirtualPathWithTrailingSlash = virtualPath.EndsWith("/") ? virtualPath : (virtualPath + "/");
            _lowerCasedVirtualPathWithTrailingSlash =
                CultureInfo.InvariantCulture.TextInfo.ToLower(_lowerCasedVirtualPathWithTrailingSlash);
            _physicalPath = physicalPath;
            _installPath = installPath;
            _physicalClientScriptPath = installPath + @"\asp.netclientfiles\";
            string fileVersion =
// ReSharper disable AssignNullToNotNullAttribute
                FileVersionInfo.GetVersionInfo(typeof (HttpRuntime).Module.FullyQualifiedName).FileVersion;
// ReSharper restore AssignNullToNotNullAttribute
            string str2 = fileVersion.Substring(0, fileVersion.LastIndexOf('.'));
            _lowerCasedClientScriptPathWithTrailingSlashV10 = "/aspnet_client/system_web/" +
                                                              fileVersion.Replace('.', '_') + "/";
            _lowerCasedClientScriptPathWithTrailingSlashV11 = "/aspnet_client/system_web/" + str2.Replace('.', '_') +
                                                              "/";
            _onSocketAccept = new WaitCallback(OnSocketAccept);
            _onStart = new WaitCallback(OnStart);
            _onAppDomainUnload = new EventHandler(OnAppDomainUnload);
            Thread.GetDomain().DomainUnload += _onAppDomainUnload;
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public bool IsVirtualPathAppPath(string path)
        {
            if (path == null)
            {
                return false;
            }
            path = CultureInfo.InvariantCulture.TextInfo.ToLower(path);
            if (path != _lowerCasedVirtualPath)
            {
                return (path == _lowerCasedVirtualPathWithTrailingSlash);
            }
            return true;
        }

        public bool IsVirtualPathInApp(string path)
        {
            bool flag;
            string str;
            return IsVirtualPathInApp(path, out flag, out str);
        }

        public bool IsVirtualPathInApp(string path, out bool isClientScriptPath, out string clientScript)
        {
            isClientScriptPath = false;
            clientScript = null;
            if (path != null)
            {
                if ((_virtualPath == "/") && path.StartsWith("/"))
                {
                    if (path.StartsWith(_lowerCasedClientScriptPathWithTrailingSlashV10))
                    {
                        isClientScriptPath = true;
                        clientScript = path.Substring(_lowerCasedClientScriptPathWithTrailingSlashV10.Length);
                    }
                    if (path.StartsWith(_lowerCasedClientScriptPathWithTrailingSlashV11))
                    {
                        isClientScriptPath = true;
                        clientScript = path.Substring(_lowerCasedClientScriptPathWithTrailingSlashV11.Length);
                    }
                    return true;
                }
                path = CultureInfo.InvariantCulture.TextInfo.ToLower(path);
                if (path.StartsWith(_lowerCasedVirtualPathWithTrailingSlash))
                {
                    return true;
                }
                if (path == _lowerCasedVirtualPath)
                {
                    return true;
                }
                if (path.StartsWith(_lowerCasedClientScriptPathWithTrailingSlashV10))
                {
                    isClientScriptPath = true;
                    clientScript = path.Substring(_lowerCasedClientScriptPathWithTrailingSlashV10.Length);
                    return true;
                }
                if (path.StartsWith(_lowerCasedClientScriptPathWithTrailingSlashV11))
                {
                    isClientScriptPath = true;
                    clientScript = path.Substring(_lowerCasedClientScriptPathWithTrailingSlashV11.Length);
                    return true;
                }
            }
            return false;
        }

        private void OnAppDomainUnload(object unusedObject, EventArgs unusedEventArgs)
        {
            Thread.GetDomain().DomainUnload -= _onAppDomainUnload;
            if (!_stopped)
            {
                Stop();
                _server.Restart();
                _server = null;
            }
        }

        private void OnSocketAccept(object acceptedSocket)
        {
            new Connection(this, (Socket) acceptedSocket, _disallowRemoteConnections).ProcessOneRequest();
        }

        private void OnStart(object unused)
        {
            while (_started)
            {
                try
                {
                    Socket state = _socket.Accept();
                    ThreadPool.QueueUserWorkItem(_onSocketAccept, state);
                    continue;
                }
                catch
                {
                    Thread.Sleep(100);
                    continue;
                }
            }
            _stopped = true;
        }

        public void Start()
        {
            if (_started)
            {
                throw new InvalidOperationException();
            }
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(IPAddress.Any, _port));
            _socket.Listen(0x7fffffff);
            _started = true;
            ThreadPool.QueueUserWorkItem(_onStart);
        }

        public void Stop()
        {
            if (!_started)
            {
                return;
            }
            _started = false;
            try
            {
                _socket.Close();
                goto Label_0031;
            }
            catch
            {
                goto Label_0031;
            }
            finally
            {
                _socket = null;
            }
            Label_002A:
            Thread.Sleep(100);
            Label_0031:
            if (!_stopped)
            {
                goto Label_002A;
            }
        }
    }
}