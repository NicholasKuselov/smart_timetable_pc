using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartTimetable.Models;
using SmartTimetable.Models.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SmartTimetable.ViewModels
{
    class StuffPageVM : ViewModelBase
    {
        public BindingList<teacher> ts { get; set; }

        public ObservableCollection<teacher> Weeks { get; set; }

   

        public StuffPageVM()
        {
            DataBase.timetableDB.teacher.Load();
            ts = DataBase.timetableDB.teacher.Local.ToBindingList();
                //MessageBox.Show(timetableDB.teacher.);      
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
