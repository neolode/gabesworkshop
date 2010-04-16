using System.EnterpriseServices.Internal;

namespace lightAsp.Util
{
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

