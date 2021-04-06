using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.Models
{
    class WeekDate
    {
        public string FirstDay { get; set; }
        public string SecondDay { get; set; }
        public string ThirdDay { get; set; }
        public string FourthDay { get; set; }
        public string FifthDay { get; set; }
        public string SixthDay { get; set; }

        public WeekDate(DateTime date)
        {
            FirstDay = date.ToShortDateString();
            SecondDay = date.AddDays(1).ToShortDateString();
            ThirdDay = date.AddDays(2).ToShortDateString();
            FourthDay = date.AddDays(3).ToShortDateString();
            FifthDay = date.AddDays(4).ToShortDateString();
            SixthDay = date.AddDays(5).ToShortDateString();
        }

        public void CreateDate(DateTime date)
        {
            FirstDay = date.ToShortDateString();
            SecondDay = date.AddDays(1).ToShortDateString();
            ThirdDay = date.AddDays(2).ToShortDateString();
            FourthDay = date.AddDays(3).ToShortDateString();
            FifthDay = date.AddDays(4).ToShortDateString();
            SixthDay = date.AddDays(5).ToShortDateString();
        }
    }
}
