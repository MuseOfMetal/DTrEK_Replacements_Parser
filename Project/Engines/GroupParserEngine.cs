using ReplacementsModule;
using ReplacementsModule.Config;
using System.Collections.Generic;
namespace Engine
{
    internal class GroupParserEngine
    {
        public static string[] Parse()
        {
            var ModuleCfg = ReplacementsModuleConfig.Get();
            string Response = HTMLLoader.Load(ModuleCfg.GroupString);
            List<string> DataArray = new List<string>();
            while (Response.IndexOf("\">", System.StringComparison.Ordinal) != -1)
            {
                int start = Response.IndexOf("\">", System.StringComparison.Ordinal);
                int finish = Response.IndexOf("</", System.StringComparison.Ordinal);
                DataArray.Add(Response.Substring(start + 2, finish - 2 - start));
                Response = Response.Remove(start, finish + 2 - start);
            }
            DataArray.Remove("Будь-яка");
            return DataArray.ToArray();
        }
    }
}
