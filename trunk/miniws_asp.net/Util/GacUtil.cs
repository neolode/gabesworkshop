namespace lightAspServer
{
    using System;
    using System.EnterpriseServices.Internal;

    public static class GacUtil
    {
        public static void Install(string dll)
        {
            new Publish().GacInstall(dll);
        }

        public static void Uninstall(string dll)
        {
            new Publish().GacRemove(dll);
        }
    }
}

