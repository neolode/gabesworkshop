using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace lightAsp.WebServer
{
    internal class Connection
    {
        private bool _disallowRemoteConnections;
        private Host _host;
        private Socket _socket;

        public Connection(Host host, Socket socket, bool disallowRemoteConnections)
        {
            _host = host;
            _socket = socket;
            _disallowRemoteConnections = disallowRemoteConnections;
        }

        public bool Connected
        {
            get { return _socket.Connected; }
        }

        public bool IsLocal
        {
            get { return (LocalIp == RemoteIp); }
        }

        public string LocalIp
        {
            get
            {
                var localEndPoint = (IPEndPoint) _socket.LocalEndPoint;
                if ((localEndPoint != null) && (localEndPoint.Address != null))
                {
                    return localEndPoint.Address.ToString();
                }
                return "127.0.0.1";
            }
        }

        public string RemoteIp
        {
            get
            {
                var remoteEndPoint = (IPEndPoint) _socket.RemoteEndPoint;
                if ((remoteEndPoint != null) && (remoteEndPoint.Address != null))
                {
                    return remoteEndPoint.Address.ToString();
                }
                return "127.0.0.1";
            }
        }

        public void Close()
        {
            try
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
            catch
            {
            }
            finally
            {
                _socket = null;
            }
        }

        private static string MakeContentTypeHeader(string fileName)
        {
            string str = null;
            string str2;
            int startIndex = fileName.LastIndexOf('.');
            if ((startIndex >= 0) && ((str2 = fileName.Substring(startIndex)) != null))
            {
                if (str2 != ".js")
                {
                    if (str2 == ".gif")
                    {
                        str = "image/gif";
                    }
                    else if (str2 == ".jpg")
                    {
                        str = "image/jpeg";
                    }
                }
                else
                {
                    str = "application/x-javascript";
                }
            }
            if (str == null)
            {
                return null;
            }
            return ("Content-Type: " + str + "\r\n");
        }

        private static string MakeResponseHeaders(int statusCode, string moreHeaders, int contentLength, bool keepAlive)
        {
            var builder = new StringBuilder();
            builder.Append(
                string.Concat(new object[]
                                  {
                                      "HTTP/1.1 ", statusCode, " ", HttpWorkerRequest.GetStatusDescription(statusCode),
                                      "\r\n"
                                  }));
            builder.Append("Server: Microsoft-Cassini/" + Messages.VersionString + "\r\n");
            builder.Append("Date: " + DateTime.Now.ToUniversalTime().ToString("R", DateTimeFormatInfo.InvariantInfo) +
                           "\r\n");
            if (contentLength >= 0)
            {
                builder.Append("Content-Length: " + contentLength + "\r\n");
            }
            if (moreHeaders != null)
            {
                builder.Append(moreHeaders);
            }
            if (!keepAlive)
            {
                builder.Append("Connection: Close\r\n");
            }
            builder.Append("\r\n");
            return builder.ToString();
        }

        public void ProcessOneRequest()
        {
            if (WaitForRequestBytes() == 0)
            {
                WriteErrorAndClose(400);
            }
            else
            {
                new Request(_host, this, _disallowRemoteConnections).Process();
            }
        }

        public byte[] ReadRequestBytes(int maxBytes)
        {
            try
            {
                if (WaitForRequestBytes() == 0)
                {
                    return null;
                }
                int available = _socket.Available;
                if (available > maxBytes)
                {
                    available = maxBytes;
                }
                int count = 0;
                var buffer = new byte[available];
                if (available > 0)
                {
                    count = _socket.Receive(buffer, 0, available, SocketFlags.None);
                }
                if (count < available)
                {
                    var dst = new byte[count];
                    if (count > 0)
                    {
                        Buffer.BlockCopy(buffer, 0, dst, 0, count);
                    }
                    buffer = dst;
                }
                return buffer;
            }
            catch
            {
                return null;
            }
        }

        private int WaitForRequestBytes()
        {
            int available = 0;
            try
            {
                if (_socket.Available == 0)
                {
                    _socket.Poll(0x186a0, SelectMode.SelectRead);
                    if ((_socket.Available == 0) && _socket.Connected)
                    {
                        _socket.Poll(0x989680, SelectMode.SelectRead);
                    }
                }
                available = _socket.Available;
            }
            catch
            {
            }
            return available;
        }

        public void Write100Continue()
        {
            WriteEntireResponseFromString(100, null, null, true);
        }

        public void WriteBody(byte[] data, int offset, int length)
        {
            _socket.Send(data, offset, length, SocketFlags.None);
        }

        public void WriteEntireResponseFromFile(string fileName, bool keepAlive)
        {
            if (!File.Exists(fileName))
            {
                WriteErrorAndClose(0x194);
            }
            else
            {
                bool flag = false;
                FileStream stream = null;
                try
                {
                    stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    var length = (int) stream.Length;
                    var buffer = new byte[length];
                    int contentLength = stream.Read(buffer, 0, length);
                    string s = MakeResponseHeaders(200, MakeContentTypeHeader(fileName), contentLength, keepAlive);
                    _socket.Send(Encoding.UTF8.GetBytes(s));
                    _socket.Send(buffer, 0, contentLength, SocketFlags.None);
                    flag = true;
                }
                finally
                {
                    if (!keepAlive || !flag)
                    {
                        Close();
                    }
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }
        }

        public void WriteEntireResponseFromString(int statusCode, string extraHeaders, string body, bool keepAlive)
        {
            try
            {
                int contentLength = (body != null) ? Encoding.UTF8.GetByteCount(body) : 0;
                string str = MakeResponseHeaders(statusCode, extraHeaders, contentLength, keepAlive);
                _socket.Send(Encoding.UTF8.GetBytes(str + body));
            }
            finally
            {
                if (!keepAlive)
                {
                    Close();
                }
            }
        }

        public void WriteErrorAndClose(int statusCode)
        {
            WriteErrorAndClose(statusCode, null);
        }

        public void WriteErrorAndClose(int statusCode, string message)
        {
            string body = Messages.FormatErrorMessageBody(statusCode, _host.VirtualPath);
            if (!string.IsNullOrEmpty(message))
            {
                body = body + "\r\n<!--\r\n" + message + "\r\n-->";
            }
            WriteEntireResponseFromString(statusCode, null, body, false);
        }

        public void WriteHeaders(int statusCode, string extraHeaders)
        {
            string s = MakeResponseHeaders(statusCode, extraHeaders, -1, false);
            _socket.Send(Encoding.UTF8.GetBytes(s));
        }
    }
}