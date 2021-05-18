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

        public teacher selectedItem { get; set; }

   

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
                    CheckListForNull();
                    DataBase.timetableDB.SaveChanges();
                });
            }
        }

        public ICommand Delete
        {
            get
            {
                return new RelayCommand(() =>
                {
                    DeleteItem();
                });
            }
        }

        private void CheckListForNull()
        {
            for (int i = ts.Count-1; i >= 0; i--)
            {
                if (ts[i].name == "" || ts[i].mail == "" || ts[i].name == null || ts[i].mail == null)
                { ts.RemoveAt(i); MessageBox.Show("asas"); }
            }
        }

        private void DeleteItem()
        {
            if (selectedItem!=null)
            {
                ts.AllowRemove = true;
                ts.Remove(selectedItem);
            }           
        }
    }
}
