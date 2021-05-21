using SmartTimetable.Models;
using SmartTimetable.Models.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.Controllers
{
    class Setting
    {
        public static users currentUser { get; set; } = new users();

        public static void SetNewPassword(string password)
        {
            currentUser.password = password;
            DataBase.UpdateDB();
        }
    }
}
