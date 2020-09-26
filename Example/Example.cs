using ReplacementsModule.Config;
using ReplacementsModule.Core;
using System;

namespace ConsoleApplication
{
    class Example
    {
        static void Main(string[] args)
        {
            ReplParserCfg cfg = new ReplParserCfg(
                dateTimeStart: new DateTime(2020, 09, 10),
                dateTimeEnd: new DateTime(2020, 09, 20),
                group: "075-18-1");

            var replacements = Parser.GetReplacements(cfg);

            foreach (var item in replacements)
            {
                Console.WriteLine($"Date: {item.Date}");
                Console.WriteLine($"Group: {item.Group}");
                Console.WriteLine($"Lection: {item.Lection}");
                Console.WriteLine($"Lecture Room: {item.LectureRoom}");
                Console.WriteLine($"Para: {item.Para}");
                Console.WriteLine($"Teacher: {item.Teacher}");
                Console.WriteLine();
            }
        }
    }
}
