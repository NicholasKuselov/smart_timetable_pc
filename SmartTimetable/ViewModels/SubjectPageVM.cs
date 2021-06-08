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
    class SubjectPageVM : ViewModelBase
    {
        public BindingList<subject> subjects { get; set; }

        public subject selectedItem { get; set; }


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
                    CheckListForNull();
                    DataBase.UpdateDB();
                });
            }
        }

        private void CheckListForNull()
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                if (subjects[i] == null || subjects[i].name == "") subjects.RemoveAt(i);
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


        private void DeleteItem()
        {
            if (selectedItem != null)
            {
                subjects.AllowRemove = true;
                subjects.Remove(selectedItem);
            }
        }
    }
}
