using System;
using System.Collections.Generic;
using ReplacementsModule;
using ReplacementsModule.Config;
namespace Engine
{
    internal static class ReplacementsParserEngine
    {
        public static string[,] Parse(ReplParserCfg cfg)
        {
            var ModuleCfg = ReplacementsModuleConfig.Get();
            string html = HTMLLoader.Load(cfg.GetRequest(), ModuleCfg.ReplacementsString);
            List<string> trArray = new List<string>();
            while (html.IndexOf("<tr>", StringComparison.Ordinal) != -1)
            {
                int start = html.IndexOf("<tr>", StringComparison.Ordinal);
                int finish = html.IndexOf("</tr>", StringComparison.Ordinal);
                trArray.Add(html.Substring(start + 4, finish - 4));
                html = html.Remove(start, finish + 5);
            }
            string[,] DataArray = new string[trArray.Count, 6];
            for (int i = 0; i < trArray.Count; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int start = trArray[i].IndexOf("<td>", StringComparison.Ordinal);
                    int finish = trArray[i].IndexOf("</td>", StringComparison.Ordinal);
                    DataArray[i, j] = trArray[i].Substring(start + 4, finish - 4);
                    trArray[i] = trArray[i].Remove(start, finish + 5); 
                }
            }
            return DataArray;
        }
    }
}
