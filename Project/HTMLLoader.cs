using System.Net;
using ReplacementsModule.Config;

namespace ReplacementsModule
{
    internal static class HTMLLoader
    {
        private static string URL = ReplacementsModuleConfig.Get().URL;
        public static string Load(int String)
        {
            return new WebClient().DownloadString(URL).Split('\n')[String];
        }
        public static string Load(string Params, int String)
        {
            return new WebClient().DownloadString(URL + Params).Split('\n')[String];
        }
    }
}
