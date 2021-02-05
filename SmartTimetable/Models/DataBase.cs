using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.Models
{
    static class DataBase
    {
        public static EDM_SmartTimetableDB timetableDB =new EDM_SmartTimetableDB() ;

        
        public static IEnumerable<Week> GetWeeks()
        {
            return new Week[]
            {
                new Week
                {
                    From = "10.11",
                    To = "17.11"
                },
                new Week
                {
                    From = "22.11",
                    To = "29.11"
                },
                new Week
                {
                    From = "2.12",
                    To = "9.12"
                },
            };
        }
    }
}
