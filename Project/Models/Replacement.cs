namespace ReplacementsModule.Models
{
    public class Replacement
    {
        public string Date          { get; set; }
        public string Para          { get; set; }
        public string Group         { get; set; }
        public string Lection       { get; set; }
        public string Teacher       { get; set; }
        public string LectureRoom   { get; set; }

        public new string GetHashCode()
        {
            return $"{Date}{Para}{Group}{Lection}{Teacher}{LectureRoom}";
        }
    }
}
