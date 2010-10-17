using System;
using System.Runtime.InteropServices;

namespace miniws
{
    class ZmwSimport
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

        [DllImport("ZazouMiniWebServer.dll")]
        public static extern void zmws_get_config(CBaseZMWSConfig cf);
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CBaseZMWSConfig
    {
        int port;
        int sport;
        String bindAddr;
        String documentRoot;
        String serverRoot;
        String logsDir;
        String pathToConfigFile;
        String pathToPHP;
        String defCharSet;
        String startPages;
        String allowFrom;
        String browserCmd;
        String denyFrom;

        Int32 maxClients;
        Int32 hideConsole;
        Int32 try808xPorts;
        Int32 canIndex;
        Int32 beQuiet;
        Int32 canStop;
        Int32 closeBrowser;
        Int32 reverseDNS;
        Int32 writeLogs;
        Int32 browseNow;
        Int32 dropClients;

        // 1.1
        Byte pbtoken;
    }

}
