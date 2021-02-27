using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartTimetable.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartTimetable.ViewModels
{
    class SubjectPageVM : ViewModelBase
    {
        public BindingList<subject> subjects { get; set; }




        public SubjectPageVM()
        {
            DataBase.timetableDB.subject.Load();
            subjects = DataBase.timetableDB.subject.Local.ToBindingList();     
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(() =>
                {
                    DataBase.timetableDB.SaveChanges();
                });
            }
        }
    }
}
