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

        public group selectedItem { get; set; }
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
                    CheckListForNull();
                    DataBase.UpdateDB();
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
            for (int i = groups.Count - 1; i >= 0; i--)
            {
                if (groups[i].name == "")
                { groups.RemoveAt(i);}
            }
        }

        private void DeleteItem()
        {
            if (selectedItem != null)
            {
                groups.AllowRemove = true;
                groups.Remove(selectedItem);
            }
        }
    }
}
