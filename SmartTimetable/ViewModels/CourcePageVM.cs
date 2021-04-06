using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartTimetable.Models;
using SmartTimetable.Models.DataBaseModels;
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
    class CoursePageVM : ViewModelBase
    {
        public BindingList<course> courses { get; set; }


        public CoursePageVM()
        {
            DataBase.timetableDB.course.Load();
            courses = DataBase.timetableDB.course.Local.ToBindingList();    
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(() =>
                {
                    DataBase.UpdateDB();
                });
            }
        }
    }
}
