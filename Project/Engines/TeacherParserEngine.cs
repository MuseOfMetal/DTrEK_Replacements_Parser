using System.Collections.Generic;
using ReplacementsModule;
using ReplacementsModule.Config;

namespace Engine
{
    internal static class TeacherParserEngine
    {
        public static string[] Parse()
        {
            var ModuleCfg = ReplacementsModuleConfig.Get();
            string Response = HTMLLoader.Load(ModuleCfg.TeacherString);
            List<string> DataArray = new List<string>();
            while (Response.IndexOf("\">", System.StringComparison.Ordinal) != -1)
            {
                int start = Response.IndexOf("\">", System.StringComparison.Ordinal);
                int finish = Response.IndexOf("</", System.StringComparison.Ordinal);
                DataArray.Add(Response.Substring(start + 2, finish - 2 - start));
                Response = Response.Remove(start, finish + 2 - start);
            }
            DataArray.Remove("Будь-який");
            DataArray.Remove("-");
            return DataArray.ToArray();
        }
    }
}