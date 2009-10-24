using System;
using System.Runtime.InteropServices;

namespace miniws
{
    class ZMWSimport
    {
        [DllImport("ZazouMiniWebServer.dll")]
        public static extern int zmws_easy_start();
        [DllImport("ZazouMiniWebServer.dll")]
        public static extern String zmws_get_version();
        [DllImport("ZazouMiniWebServer.dll")]
        public static extern void zmws_browse();
        [DllImport("ZazouMiniWebServer.dll")]
        public static extern bool zmws_configure();
        [DllImport("ZazouMiniWebServer.dll")]
        public static extern int zmws_stop();
        [DllImport("ZazouMiniWebServer.dll")]
        public static extern int zmws_get_port();
    }
}
