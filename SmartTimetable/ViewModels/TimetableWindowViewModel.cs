using GalaSoft.MvvmLight;
using SmartTimetable.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.ViewModels
{
    class TimetableWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Week> Weeks { get; set; }

        public TimetableWindowViewModel()
        {
            Weeks = new ObservableCollection<Week>(DataBase.GetWeeks());
        }
    }
}
