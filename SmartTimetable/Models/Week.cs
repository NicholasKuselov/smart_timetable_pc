using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.Models
{
    class Week : ViewModelBase
    {
        public string To { get; set; }
        public string From { get; set; }

        public string GetWeek {
            get { return From + " - " + To; }
        }

        public override string ToString()
        {
            return From+" "+To;
        }
    }
}
