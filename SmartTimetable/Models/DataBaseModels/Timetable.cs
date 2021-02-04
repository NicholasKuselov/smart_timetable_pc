using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.Models.DataBaseModels
{
    class Timetable
    {
        public int idtimetable { get; set; }
        public int Subject { get; set; }
        public string Date { get; set; }
        public int Day { get; set; }
        public int Week { get; set; }
        public int Teacher { get; set; }
        public int Group { get; set; }
        public int Course { get; set; }
    }
}
