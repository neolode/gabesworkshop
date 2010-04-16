using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using Microsoft.Win32.SafeHandles;

namespace lightAsp.WebServer
{
    internal class Request : SimpleWorkerRequest
    {
        private const int MaxHeaderBytes = 0x8000;
        private static readonly char[] SBadPathChars = new[] {'%', '>', '<', '$', ':'};
        private static readonly string[] SDefaultFilenames = new[] {"default.aspx", "default.htm", "default.html"};
        private string _allRawHeaders;
        private Connection _conn;
        private int _contentLength;
        private bool _disallowRemoteConnections;
        private int _endHeadersOffset;
        private string _filePath;
        private ArrayList _headerByteStrings;
        private byte[] _headerBytes;
        private bool _headersSent;
        private Host _host;
        private string[] _knownRequestHeaders;
        private string _path;
        private string _pathInfo;
        private string _pathTranslated;
        private byte[] _preloadedContent;
        private int _preloadedContentLength;
        private string _prot;
        private string _queryString;
        private byte[] _queryStringBytes;
        private ArrayList _responseBodyBytes;
        private StringBuilder _responseHeadersBuilder;
        private int _responseStatus;
        private bool _specialCaseStaticFileHeaders;
        private int _startHeadersOffset;
        private string[][] _unknownRequestHeaders;
        private string _url;
        private string _verb;

        public Request(Host host, Connection conn, bool disallowRemoteConnections)
            : base(string.Empty, string.Empty, null)
        {
            _host = host;
            _conn = conn;
            _disallowRemoteConnections = disallowRemoteConnections;
        }

        public override void CloseConnection()
        {
            _conn.Close();
        }

        public override void EndOfRequest()
        {
        }

        public override void FlushResponse(bool finalFlush)
        {
            if (!_headersSent)
            {
                _conn.WriteHeaders(_responseStatus, _responseHeadersBuilder.ToString());
                _headersSent = true;
            }
            foreach (byte[] data in _responseBodyBytes.Cast<byte[]>())
            {
                _conn.WriteBody(data, 0, data.Length);
            }
            _responseBodyBytes = new ArrayList();
            if (finalFlush)
            {
                _conn.Close();
            }
        }

        public override string GetAppPath()
        {
            return _host.VirtualPath;
        }

        public override string GetAppPathTranslated()
        {
            return _host.PhysicalPath;
        }

        public override string GetFilePath()
        {
            return _filePath;
        }

        public override string GetFilePathTranslated()
        {
            return _pathTranslated;
        }

        public override string GetHttpVerbName()
        {
            return _verb;
        }

        public override string GetHttpVersion()
        {
            return _prot;
        }

        public override string GetKnownRequestHeader(int index)
        {
            return _knownRequestHeaders[index];
        }

        public override string GetLocalAddress()
        {
            return _conn.LocalIp;
        }

        public override int GetLocalPort()
        {
            return _host.Port;
        }

        public override string GetPathInfo()
        {
            return _pathInfo;
        }

        public override byte[] GetPreloadedEntityBody()
        {
            return _preloadedContent;
        }

        public override string GetQueryString()
        {
            return _queryString;
        }

        public override byte[] GetQueryStringRawBytes()
        {
            return _queryStringBytes;
        }

        public override string GetRawUrl()
        {
            return _url;
        }

        public override string GetRemoteAddress()
        {
            return _conn.RemoteIp;
        }

        public override int GetRemotePort()
        {
            return 0;
        }

        public override string GetServerVariable(string name)
        {
            string str = string.Empty;
            string str2 = name;
            if (str2 == null)
            {
                return str;
            }
            if (str2 != "ALL_RAW")
            {
                if (str2 != "SERVER_PROTOCOL")
                {
                    if (str2 != "SERVER_SOFTWARE")
                    {
                        return str;
                    }
                    return ("ASP.net Light Server/" + Messages.VersionString);
                }
            }
            else
            {
                return _allRawHeaders;
            }
            return _prot;
        }

        public override string GetUnknownRequestHeader(string name)
        {
            int length = _unknownRequestHeaders.Length;
            for (int i = 0; i < length; i++)
            {
                if (string.Compare(name, _unknownRequestHeaders[i][0], true, CultureInfo.InvariantCulture) == 0)
                {
                    return _unknownRequestHeaders[i][1];
                }
            }
            return null;
        }

        public override string[][] GetUnknownRequestHeaders()
        {
            return _unknownRequestHeaders;
        }

        public override string GetUriPath()
        {
            return _path;
        }

        public override bool HeadersSent()
        {
            return _headersSent;
        }

        private bool IsBadPath()
        {
            return ((_path == null) || ((_path.IndexOfAny(SBadPathChars) >= 0) || (_path.IndexOf("..") >= 0)));
        }

        public override bool IsClientConnected()
        {
            return _conn.Connected;
        }

        public override bool IsEntireEntityBodyIsPreloaded()
        {
            return (_contentLength == _preloadedContentLength);
        }

        public override string MapPath(string path)
        {
            //map to phisical
            string physicalPath;
            if (string.IsNullOrEmpty(path) || path.Equals("/"))
            {
                physicalPath = _host.VirtualPath == "/" ? _host.PhysicalPath : Environment.SystemDirectory;
            }
            else if (_host.IsVirtualPathAppPath(path))
            {
                physicalPath = _host.PhysicalPath;
            }
            else if (_host.IsVirtualPathInApp(path))
            {
                physicalPath = _host.PhysicalPath + path.Substring(_host.NormalizedVirtualPath.Length);
            }
            else if (path.StartsWith("/"))
            {
                physicalPath = _host.PhysicalPath + path.Substring(1);
            }
            else
            {
                physicalPath = _host.PhysicalPath + path;
            }
            physicalPath = physicalPath.Replace('/', '\\');
            if (physicalPath.EndsWith(@"\") && !physicalPath.EndsWith(@":\"))
            {
                physicalPath = physicalPath.Substring(0, physicalPath.Length - 1);
            }
            return physicalPath;
        }

        private void ParseHeaders()
        {
            _knownRequestHeaders = new string[40];
            var list = new ArrayList();
            for (int i = 1; i < _headerByteStrings.Count; i++)
            {
                string str = ((ByteString) _headerByteStrings[i]).GetString();
                int index = str.IndexOf(':');
                if (index >= 0)
                {
                    string header = str.Substring(0, index).Trim();
                    string str3 = str.Substring(index + 1).Trim();
                    int knownRequestHeaderIndex = GetKnownRequestHeaderIndex(header);
                    if (knownRequestHeaderIndex >= 0)
                    {
                        _knownRequestHeaders[knownRequestHeaderIndex] = str3;
                    }
                    else
                    {
                        list.Add(header);
                        list.Add(str3);
                    }
                }
            }
            int num4 = list.Count/2;
            _unknownRequestHeaders = new string[num4][];
            int num5 = 0;
            for (int j = 0; j < num4; j++)
            {
                _unknownRequestHeaders[j] = new[] {(string) list[num5++], (string) list[num5++]};
            }
            if (_headerByteStrings.Count > 1)
            {
                _allRawHeaders = Encoding.UTF8.GetString(_headerBytes, _startHeadersOffset,
                                                         _endHeadersOffset - _startHeadersOffset);
            }
            else
            {
                _allRawHeaders = string.Empty;
            }
        }

        private void ParsePostedContent()
        {
            _contentLength = 0;
            _preloadedContentLength = 0;
            string s = _knownRequestHeaders[11];
            if (s != null)
            {
                try
                {
                    _contentLength = int.Parse(s);
                }
                catch
                {
                }
            }
            if (_headerBytes.Length > _endHeadersOffset)
            {
                _preloadedContentLength = _headerBytes.Length - _endHeadersOffset;
                if ((_preloadedContentLength > _contentLength) && (_contentLength > 0))
                {
                    _preloadedContentLength = _contentLength;
                }
                _preloadedContent = new byte[_preloadedContentLength];
                Buffer.BlockCopy(_headerBytes, _endHeadersOffset, _preloadedContent, 0, _preloadedContentLength);
            }
        }

        private void ParseRequestLine()
        {
            ByteString[] strArray = ((ByteString) _headerByteStrings[0]).Split(' ');
            if (((strArray != null) && (strArray.Length >= 2)) && (strArray.Length <= 3))
            {
                _verb = strArray[0].GetString();
                ByteString str2 = strArray[1];
                //virtual path here
                _url = str2.GetString();
                _prot = strArray.Length == 3 ? strArray[2].GetString() : "HTTP/1.0";
                int index = str2.IndexOf('?');
                _queryStringBytes = index > 0 ? str2.Substring(index + 1).GetBytes() : new byte[0];
                index = _url.IndexOf('?');
                if (index > 0)
                {
                    _path = _url.Substring(0, index);
                    _queryString = _url.Substring(index + 1);
                }
                else
                {
                    _path = _url;
                    _queryStringBytes = new byte[0];
                }
                if (_path.IndexOf('%') >= 0)
                {
                    _path = HttpUtility.UrlDecode(_path);
                }
                int startIndex = _path.LastIndexOf('.');
                int num3 = _path.LastIndexOf('/');
                if (((startIndex >= 0) && (num3 >= 0)) && (startIndex < num3))
                {
                    int length = _path.IndexOf('/', startIndex);
                    _filePath = _path.Substring(0, length);
                    _pathInfo = _path.Substring(length);
                }
                else
                {
                    _filePath = _path;
                    _pathInfo = string.Empty;
                }
                _pathTranslated = MapPath(_filePath);
            }
        }

        private void PrepareResponse()
        {
            _headersSent = false;
            _responseStatus = 200;
            _responseHeadersBuilder = new StringBuilder();
            _responseBodyBytes = new ArrayList();
        }

        public void Process()
        {
            ReadAllHeaders();
            if (((_headerBytes == null) || (_endHeadersOffset < 0)) ||
                ((_headerByteStrings == null) || (_headerByteStrings.Count == 0)))
            {
                _conn.WriteErrorAndClose(400);
            }
            else
            {
                ParseRequestLine();
                if (IsBadPath())
                {
                    _conn.WriteErrorAndClose(400);
                }
                else if (!_conn.IsLocal && _disallowRemoteConnections)
                {
                    _conn.WriteErrorAndClose(0x193);
                }
                else
                {
                    bool isClientScriptPath;
                    string clientScript;
                    if (!_host.IsVirtualPathInApp(_path, out isClientScriptPath, out clientScript))
                    {
                        _conn.WriteErrorAndClose(0x194);
                    }
                    else
                    {
                        ParseHeaders();
                        ParsePostedContent();
                        if (((_verb == "POST") && (_contentLength > 0)) && (_preloadedContentLength < _contentLength))
                        {
                            _conn.Write100Continue();
                        }
                        if (isClientScriptPath)
                        {
                            _conn.WriteEntireResponseFromFile(_host.PhysicalClientScriptPath + clientScript, false);
                        }
                        else if (!ProcessDirectoryListingRequest())
                        {
                            PrepareResponse();
                            HttpRuntime.ProcessRequest(this);
                        }
                    }
                }
            }
        }

        private bool ProcessDirectoryListingRequest()
        {
            if (_verb != "GET")
            {
                return false;
            }
            int startIndex = _pathTranslated.LastIndexOf('\\');
            if (_pathTranslated.IndexOf('.', startIndex) >= startIndex)
            {
                return false;
            }
            if (!Directory.Exists(_pathTranslated))
            {
                return false;
            }
            if (!_path.EndsWith("/"))
            {
                string str = _path + "/";
                string extraHeaders = "Location: " + str + "\r\n";
                string body = "<html><head><title>Object moved</title></head><body>\r\n<h2>Object moved to <a href='" +
                              str + "'>here</a>.</h2>\r\n</body></html>\r\n";
                _conn.WriteEntireResponseFromString(0x12e, extraHeaders, body, false);
                return true;
            }
            foreach (string str4 in SDefaultFilenames)
            {
                string str5 = _pathTranslated + @"\" + str4;
                if (File.Exists(str5))
                {
                    _path = _path + str4;
                    _filePath = _path;
                    _url = (_queryString != null) ? (_path + "?" + _queryString) : _path;
                    _pathTranslated = str5;
                    return false;
                }
            }
            FileSystemInfo[] elements = null;
            try
            {
                elements = new DirectoryInfo(_pathTranslated).GetFileSystemInfos();
            }
            catch
            {
            }
            string path = null;
            if (_path.Length > 1)
            {
                int length = _path.LastIndexOf('/', _path.Length - 2);
                path = (length > 0) ? _path.Substring(0, length) : "/";
                if (!_host.IsVirtualPathInApp(path))
                {
                    path = null;
                }
            }
            _conn.WriteEntireResponseFromString(200, "Content-type: text/html; charset=utf-8\r\n",
                                                Messages.FormatDirectoryListing(_path, path, elements), false);
            return true;
        }

        private void ReadAllHeaders()
        {
            _headerBytes = null;
            do
            {
                if (!TryReadAllHeaders())
                {
                    return;
                }
            } while (_endHeadersOffset < 0);
        }

        public override int ReadEntityBody(byte[] buffer, int size)
        {
            int count = 0;
            byte[] src = _conn.ReadRequestBytes(size);
            if ((src != null) && (src.Length > 0))
            {
                count = src.Length;
                Buffer.BlockCopy(src, 0, buffer, 0, count);
            }
            return count;
        }

        public override void SendCalculatedContentLength(int contentLength)
        {
            if (!_headersSent)
            {
                _responseHeadersBuilder.Append("Content-Length: ");
                _responseHeadersBuilder.Append(contentLength.ToString());
                _responseHeadersBuilder.Append("\r\n");
            }
        }

        public override void SendKnownResponseHeader(int index, string value)
        {
            if (!_headersSent)
            {
                switch (index)
                {
                    case 1:
                    case 2:
                    case 0x1a:
                        return;

                    case 0x12:
                    case 0x13:
                        if (!_specialCaseStaticFileHeaders)
                        {
                            break;
                        }
                        return;

                    case 20:
                        if (value != "bytes")
                        {
                            break;
                        }
                        _specialCaseStaticFileHeaders = true;
                        return;
                }
                _responseHeadersBuilder.Append(GetKnownResponseHeaderName(index));
                _responseHeadersBuilder.Append(": ");
                _responseHeadersBuilder.Append(value);
                _responseHeadersBuilder.Append("\r\n");
            }
        }

        public override void SendResponseFromFile(IntPtr handle, long offset, long length)
        {
            if (length != 0L)
            {
                FileStream f = null;
                try
                {
                    f = new FileStream(new SafeFileHandle(handle, false), FileAccess.Read);
                    SendResponseFromFileStream(f, offset, length);
                }
                finally
                {
                    if (f != null)
                    {
                        f.Close();
                    }
                }
            }
        }

        public override void SendResponseFromFile(string filename, long offset, long length)
        {
            if (length != 0L)
            {
                FileStream f = null;
                try
                {
                    f = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                    SendResponseFromFileStream(f, offset, length);
                }
                finally
                {
                    if (f != null)
                    {
                        f.Close();
                    }
                }
            }
        }

        private void SendResponseFromFileStream(FileStream f, long offset, long length)
        {
            long num = f.Length;
            if (length == -1L)
            {
                length = num - offset;
            }
            if (((length != 0L) && (offset >= 0L)) && (length <= (num - offset)))
            {
                if (offset > 0L)
                {
                    f.Seek(offset, SeekOrigin.Begin);
                }
                if (length <= 0x10000L)
                {
                    var buffer = new byte[(int) length];
                    int num2 = f.Read(buffer, 0, (int) length);
                    SendResponseFromMemory(buffer, num2);
                }
                else
                {
                    var buffer2 = new byte[0x10000];
                    var num3 = (int) length;
                    while (num3 > 0)
                    {
                        int count = (num3 < 0x10000) ? num3 : 0x10000;
                        int num5 = f.Read(buffer2, 0, count);
                        SendResponseFromMemory(buffer2, num5);
                        num3 -= num5;
                        if ((num3 > 0) && (num5 > 0))
                        {
                            FlushResponse(false);
                        }
                    }
                }
            }
        }

        public override void SendResponseFromMemory(byte[] data, int length)
        {
            if (length > 0)
            {
                var dst = new byte[length];
                Buffer.BlockCopy(data, 0, dst, 0, length);
                _responseBodyBytes.Add(dst);
            }
        }

        public override void SendStatus(int statusCode, string statusDescription)
        {
            _responseStatus = statusCode;
        }

        public override void SendUnknownResponseHeader(string name, string value)
        {
            if (!_headersSent)
            {
                _responseHeadersBuilder.Append(name);
                _responseHeadersBuilder.Append(": ");
                _responseHeadersBuilder.Append(value);
                _responseHeadersBuilder.Append("\r\n");
            }
        }

        private bool TryReadAllHeaders()
        {
            byte[] src = _conn.ReadRequestBytes(0x8000);
            if ((src == null) || (src.Length == 0))
            {
                return false;
            }
            if (_headerBytes != null)
            {
                int num = src.Length + _headerBytes.Length;
                if (num > 0x8000)
                {
                    return false;
                }
                var dst = new byte[num];
                Buffer.BlockCopy(_headerBytes, 0, dst, 0, _headerBytes.Length);
                Buffer.BlockCopy(src, 0, dst, _headerBytes.Length, src.Length);
                _headerBytes = dst;
            }
            else
            {
                _headerBytes = src;
            }
            _startHeadersOffset = -1;
            _endHeadersOffset = -1;
            _headerByteStrings = new ArrayList();
            var parser = new ByteParser(_headerBytes);
            while (true)
            {
                ByteString str = parser.ReadLine();
                if (str == null)
                {
                    break;
                }
                if (_startHeadersOffset < 0)
                {
                    _startHeadersOffset = parser.CurrentOffset;
                }
                if (str.IsEmpty)
                {
                    _endHeadersOffset = parser.CurrentOffset;
                    break;
                }
                _headerByteStrings.Add(str);
            }
            return true;
        }
    }
}