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
    class GroupPageVM : ViewModelBase
    {
        public BindingList<group> groups { get; set; }


        public GroupPageVM()
        {
            DataBase.timetableDB.group.Load();
            groups = DataBase.timetableDB.group.Local.ToBindingList();
    
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
