using GalaSoft.MvvmLight;
using SmartTimetable.Models.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.Models
{
    static class DataBase
    {
        public static SmartTimetableDBContext timetableDB = new SmartTimetableDBContext() ;

        public static void UpdateDB() //try catch
        {
            timetableDB.SaveChanges();
        }
        
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
