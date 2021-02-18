using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.Models
{
    public class LessonTimeModel
    {
        public LessonTimeModel(string from, string to)
        {
            From = from;
            To = to;
        }

        public string From { get; set; }
        public string To { get; set; }

        public string GetTime()
        {
            return From + " - " + To;
        }
    }
}
