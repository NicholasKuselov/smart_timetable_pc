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
using System.Windows;
using System.Windows.Input;

namespace SmartTimetable.ViewModels
{
    class WeekCreateWindowVM : ViewModelBase
    {
        public DateTime dateFrom { get; set; }

        public BindingList<week> weeks { get; set; }

        public WeekCreateWindowVM()
        {
            dateFrom = DateTime.Now;
            DataBase.timetableDB.week.Load();
            weeks = DataBase.timetableDB.week.Local.ToBindingList();
        }

        public ICommand AddWeek
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (dateFrom != null)
                    {
                        if (dateFrom.DayOfWeek != DayOfWeek.Monday)
                        {
                            MessageBox.Show("Обрана дата не є понеділком!","Помилка",MessageBoxButton.OK,MessageBoxImage.Error);
                            return;
                        }
                        week newWeek = new week();
                        newWeek.dateFrom = dateFrom.ToShortDateString();
                        newWeek.dateTo = dateFrom.AddDays(6).ToShortDateString();
                        if (weeks.Count > 0) newWeek.idweek = weeks[weeks.Count - 1].idweek + 1;
                        else newWeek.idweek = 0;
                        if (CheckWeek(newWeek))
                        {
                            weeks.Add(newWeek);
                            DataBase.UpdateDB();
                        }
                    }
                });
            }
        }

        private bool CheckWeek(week currWeek)
        {
            for (int i = 0; i < weeks.Count; i++)
            {
                if (weeks[i].dateFrom == currWeek.dateFrom && weeks[i].dateTo == currWeek.dateTo) return false;
            }
            return true;
        }
    }
}
