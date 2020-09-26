using System.IO;
using Newtonsoft.Json;
namespace ReplacementsModule.Config
{
    internal class ReplacementsModuleConfig
    {
        private static ReplacementsModuleConfig replacementsModuleConfig;
        public static void Load()
        {
            using (StreamReader r = new StreamReader("ReplacementsModuleConfig.json"))
                replacementsModuleConfig = JsonConvert.DeserializeObject<ReplacementsModuleConfig>(r.ReadToEnd());
        }
        public static ReplacementsModuleConfig Get()
        {
            if (replacementsModuleConfig != null)
                return replacementsModuleConfig;
            Load();
            return replacementsModuleConfig;
        }
        private ReplacementsModuleConfig() { }

        public int GroupString          { get; set; }
        public int ReplacementsString   { get; set; }
        public int TeacherString        { get; set; }
        public string URL               { get; set; }
    }
}
