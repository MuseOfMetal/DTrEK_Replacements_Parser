using System.Collections.Generic;
using ReplacementsModule.Models;
using ReplacementsModule.Config;
namespace ReplacementsModule.Core
{
    public static class Parser
    {
        public static List<Replacement> GetReplacements(ReplParserCfg Config)
        {
            List<Replacement> replacements = new List<Replacement>();
            string[,] arr = Engine.ReplacementsParserEngine.Parse(Config);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                replacements.Add
                (
                    new Replacement()
                    {
                        Date = arr[i, 0],
                        Para = arr[i, 1],
                        Group = arr[i, 2],
                        Lection = arr[i, 3],
                        Teacher = arr[i, 4],
                        LectureRoom = arr[i, 5]
                    }
                );
            }
            return replacements;
        }
        public static List<Teacher> GetTeacher()
        {
            List<Teacher> teachers = new List<Teacher>();
            string[] arr = Engine.TeacherParserEngine.Parse();
            for (int i = 0; i < arr.Length; i++)
            {
                teachers.Add
                (
                    new Teacher()
                    {
                        FullName = arr[i]
                    }
                );
            }
            return teachers;
        }
        public static List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();
            string[] arr = Engine.GroupParserEngine.Parse();
            for (int i = 0; i < arr.Length; i++)
            {
                groups.Add
                (
                    new Group()
                    {
                        GroupName = arr[i]
                    }
                );
            }
            return groups;
        }
        public static void ReloadModuleConfig()
        {
            ReplacementsModuleConfig.Load();
        }
    }
}
