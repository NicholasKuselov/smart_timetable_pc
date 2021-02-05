using GalaSoft.MvvmLight;
using SmartTimetable.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.ViewModels
{
    class TimetableWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Week> Weeks { get; set; }

        ObservableCollection<timetable> timetables;
        public BindingList<timetable> ts {get;set;}

        //public EDM_SmartTimetableDB timetableDB { get; set; }

        public TimetableWindowViewModel()
        {
            //timetableDB = new EDM_SmartTimetableDB();

            //ts = timetableDB.timetable.Local.ToBindingList();

            Weeks = new ObservableCollection<Week>(DataBase.GetWeeks());
        }
    }
}
