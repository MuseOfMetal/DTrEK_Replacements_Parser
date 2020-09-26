 using System;
namespace ReplacementsModule.Config
{
    public class ReplParserCfg
    {
        private string _dateTimeStart;
        private string _dateTimeEnd;
        private string _para;
        public DateTime DateTimeStart
        {
            get
            {
                return ConvertStringToDateTime(_dateTimeStart);
            }
            set
            {
                _dateTimeStart = ConvertDateTimeToString(value);
            }
        }
        public DateTime DateTimeEnd
        {
            get
            {
                return ConvertStringToDateTime(_dateTimeEnd);
            }
            set
            {
                _dateTimeEnd = ConvertDateTimeToString(value);
            }
        }
        public int Para
        {
            get
            {
                return int.Parse(_para);
            }
            set
            {
                if (value == 0) _para = null; else _para = Convert.ToString(value);
            }
        }
        public string Group;
        public string Teacher;
        private string ConvertDateTimeToString(DateTime dateTime)
        {
            string Converted = $"{dateTime.Year}-";
            if (dateTime.Month < 10) Converted += $"0{dateTime.Month}-"; else Converted += $"{dateTime.Month}-";
            if (dateTime.Day < 10) Converted += $"0{dateTime.Day}"; else Converted += $"{dateTime.Day}";
            return Converted;
        }
        private DateTime ConvertStringToDateTime(string dateTime)
        {
            string[] arr = _dateTimeStart.Split('-');
            return new DateTime(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]));
        }
        public string GetRequest()
        {
            string Request = "index.php?";
            if (_dateTimeEnd == ConvertDateTimeToString(new DateTime()))
                Request += $"date_begin={_dateTimeStart}&date_end={_dateTimeStart}&";
            else
                Request += $"date_begin={_dateTimeStart}&date_end={_dateTimeEnd}&";
            Request += $"group={Group}&teacher={Teacher?.Replace(' ', '+')}&para={_para}";
            return Request;
        }
        public ReplParserCfg(
            DateTime dateTimeStart,
            DateTime dateTimeEnd = new DateTime(),
            string group = null,
            string teacher = null,
            int para = 0)
        {
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
            Group = group;
            Teacher = teacher;
            Para = para;
        }
    }
}
