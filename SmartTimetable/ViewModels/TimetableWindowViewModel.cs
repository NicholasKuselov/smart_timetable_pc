using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartTimetable.Models;
using SmartTimetable.Models.DataBaseModels;
using SmartTimetable.Pages;
using SmartTimetable.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartTimetable.ViewModels
{
    class TimetableWindowViewModel : ViewModelBase
    {
        //Propertys
        private Window weekCreateWindow;

        public Visibility WeekListVisability { get; set; } = Visibility.Visible;

        private week _CurrentWeek;
        public week CurrentWeek
        {
            get
            {
                return _CurrentWeek;
            }
            set
            {
                _CurrentWeek = value;
                OnListBoxSelectItemChange(value);
            }
        }
        public int WeekListWidth { get; set; } = (int)WeekListWidthState.Open;
        public Page page { get; set; }
        public BindingList<group> groups { get; set; }
        public BindingList<day> dbDays { get; set; }
        public BindingList<course> courses { get; set; }
        public BindingList<timetable> timetables { get; set; }
        public BindingList<teacher> teachers { get; set; }
        public BindingList<week> weeks { get; set; }

        public BindingList<dates> dates { get; set; }

        public BindingList<times> times { get; set; }

        public BindingList<subject> subjects { get; set; }
        public BindingList<timetable> currentWeekTimetable { get; set; }
        public int currentWeekId { get; set; }
        public BindingList<timetable> FirstDay { get; set; }
        public BindingList<timetable> SecondDay { get; set; }
        public BindingList<timetable> ThirdDay { get; set; }
        public BindingList<timetable> FourthDay { get; set; }
        public BindingList<timetable> FifthDay { get; set; }
        public BindingList<timetable> SixthDay { get; set; }

        BindingList<BindingList<timetable>> Days = new BindingList<BindingList<timetable>>();
        public BindingList<string> groupsForTable { get; set; }
        public WeekDate weekDate { get; set; } //Содержит в себе все даты недели, с пнд по сбт.
        public timetable selectedItem { get; set; }


        public TimetableWindowViewModel()
        { 
            //weekDate = new WeekDate();
            // InitTable();
            LoadComponents();
        }

        //Commands

        public ICommand testClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    DataBase.timetableDB.SaveChanges();
                });
            }
        }
        public ICommand ChangeWeekListWidth
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if(WeekListWidth == (int)WeekListWidthState.Open)
                    {
                        WeekListWidth = (int)WeekListWidthState.Close;
                        WeekListVisability = Visibility.Hidden;
                    }
                    else
                    {
                        WeekListWidth = (int)WeekListWidthState.Open;
                        WeekListVisability = Visibility.Visible;
                    }
                });
            }
        }
        public ICommand Save
        {
            get
            {
                return new RelayCommand(() =>
                {
                    UpdateTable();
                });
            }
        }
        public ICommand OpenWeekCreateWindow
        {
            get
            {
                return new RelayCommand(() =>
                {
                    weekCreateWindow = new WeekCreateWindow();
                    weekCreateWindow.Show();
                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(() =>
                {
                    DeleteLesson();
                });
            }
        }




        private void LoadComponents()
        {
            DataBase.timetableDB.week.Load();
            DataBase.timetableDB.teacher.Load();
            DataBase.timetableDB.timetable.Load();
            DataBase.timetableDB.group.Load();
            DataBase.timetableDB.course.Load();
            DataBase.timetableDB.subject.Load();
            DataBase.timetableDB.day.Load();
            DataBase.timetableDB.dates.Load();
            DataBase.timetableDB.times.Load();


            dbDays = DataBase.timetableDB.day.Local.ToBindingList();
            groups = DataBase.timetableDB.group.Local.ToBindingList();
            weeks = DataBase.timetableDB.week.Local.ToBindingList();
            teachers = DataBase.timetableDB.teacher.Local.ToBindingList();
            timetables = DataBase.timetableDB.timetable.Local.ToBindingList();
            courses = DataBase.timetableDB.course.Local.ToBindingList();
            subjects = DataBase.timetableDB.subject.Local.ToBindingList();
            times = DataBase.timetableDB.times.Local.ToBindingList();
            dates = DataBase.timetableDB.dates.Local.ToBindingList();
        }
        //Methods
        private void InitTable(int currentWeekid) //Вызывается при изменении выбранной недели или при запуске программы
        {
            Days.Clear();

            

            //if (CurrentWeek == null) CurrentWeek = weeks.Where(p => p.idweek==currentWeekid).Last(); //ssssssssssssssssssssssssssssssssssssssssssssssssssssss
           
            currentWeekTimetable = new BindingList<timetable>(timetables.Where(p => p.Week == currentWeekId).ToList<timetable>());
      
            groupsForTable = new BindingList<string>(CreateGroup());

            FirstDay = new BindingList<timetable>();
            SecondDay = new BindingList<timetable>();
            ThirdDay = new BindingList<timetable>();
            FourthDay = new BindingList<timetable>();
            FifthDay = new BindingList<timetable>();
            SixthDay = new BindingList<timetable>();

            Days.Add(FirstDay);
            Days.Add(SecondDay);
            Days.Add(ThirdDay);
            Days.Add(FourthDay);
            Days.Add(FifthDay);
            Days.Add(SixthDay);

            CreateDays();
        }
        public void CreateDays()
        {
            string[] dateStr = GetWeekById(currentWeekId).dateFrom.Split('.');
            DateTime date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]), Convert.ToInt32(dateStr[0]));

            weekDate = new WeekDate(date);
           // weekDate.CreateDate(date);
  
            for (int i = 0; i < Days.Count; i++)
            {
                foreach (course f_course in courses)
                {
                    foreach (group f_group in groups)
                    {
                        foreach (times f_Time in times)
                        {
                            string currentDate = date.AddDays(i).ToShortDateString();
                            int currentDateId = 0;
                            if (dates.Where(p => p.date == currentDate).Count() <= 0)
                            {
                                dates dt = new dates();
                                dt.date = date.AddDays(i).ToShortDateString();
                                if (dates.Count == 0) dt.iddates = 0;
                                else dt.iddates = dates.Last().iddates + 1;
                                dates.Add(dt);
                                currentDateId = dt.iddates;
                                DataBase.timetableDB.SaveChanges();
                            }
                            else
                            {
                                currentDateId = dates.Where(p => p.date == currentDate).Last().iddates;
                            }

 


                            timetable tt = CheckLesson(currentWeekTimetable.ToList<timetable>(), currentDateId, f_Time.idtimes, dbDays[i].idDay, f_course.idcourse, f_group.idgroup);

                            if (tt == null)
                            {                              
                                tt = new timetable();
                                
                                tt.Date = dates.Where(p => p.date == date.AddDays(i).ToShortDateString()).Last().iddates;
                                tt.Day = dbDays[i].idDay;
                                tt.Week = currentWeekId;
                                tt.Group = f_group.idgroup;
                                tt.Course = f_course.idcourse;
                                tt.Time = f_Time.idtimes;
                                tt.times = f_Time;
                            }
                            Days[i].Add(tt);

                            
                        }
                    }
                }
               
            }
        }
        public void UpdateTable() //Синхронизация таблиц в программе и бд, путем записи-перезаписи табл в бд
        {
            for (int i = 0; i < Days.Count; i++)
            {
                for (int j = 0; j < Days[i].Count; j++)
                {
                    if (Days[i][j].teacher1 != null && Days[i][j].subject1 != null && !timetables.Contains(Days[i][j]))
                    {
                        if(timetables.Count>0) Days[i][j].idtimetable = timetables[timetables.Count - 1].idtimetable + 1;
                        else Days[i][j].idtimetable = 1;
                        timetables.Add(Days[i][j]);
                    }else if (Days[i][j].teacher1 == null && Days[i][j].subject1 == null && timetables.Contains(Days[i][j]))
                    {
                       

                        timetables.AllowRemove = true;
                        timetables.Remove(Days[i][j]);

                        timetable tt = new timetable();

                        tt.Date = Days[i][j].Date;
                        tt.Day = Days[i][j].Day;
                        tt.Week = Days[i][j].Week;
                        tt.Group = Days[i][j].Group;
                        tt.Course = Days[i][j].Course;
                        tt.Time = Days[i][j].Time;
                        tt.times = Days[i][j].times;

                        Days[i][j] = tt;
                    }
                    //  else if (Days[i][j].teacher1 == null && Days[i][j].subject1 == null && timetables.Contains(Days[i][j]))
                    // {
                    //     timetables.Remove(Days[i][j]);
                    //   }
                }  
            }
            DataBase.UpdateDB();
        }
        private timetable CheckLesson(List<timetable> currWeek, int date,int time,int day,int course,int group) //Проверка урока на наличие в бд
        {
           
            for (int i = 0; i < currWeek.Count; i++)
            {
                if (currWeek[i].Date == date && currWeek[i].Time == time && currWeek[i].Day == day && currWeek[i].Course == course && currWeek[i].Group == group)
                {
                    return currWeek[i];
                }
            }

            return null; 
        } 
        private week GetWeekById(int id)
        {
            for (int i = 0; i < weeks.ToList<week>().Count; i++)
            {
                if (weeks.ToList<week>()[i].idweek == id) return weeks.ToList<week>()[i];
            }
            return null;
        }
        private List<string> CreateGroup() //Создание групп для понятного отображения, напр. ИПЗ 1 , КИ 2 и тд.
        {
            List<string> groupAbbreviation = new List<string>();
            List<string> groupsForShow = new List<string>();
            foreach (group f_group in groups)
            {
                groupAbbreviation.Add(CreateAbbreviation(f_group.name));
            }

            foreach (course f_course in courses)
            {
                foreach (string f_group in groupAbbreviation)
                {
                    groupsForShow.Add(f_group + " " + f_course.number.ToString());
                }
            }
            return groupsForShow;
        }
        private string CreateAbbreviation(string name)
        {
            string[] mas = name.Split(' ');
            string res = "";
            for (int i = 0; i < mas.Length; i++)
            {
                res += mas[i][0];
            }

            return res.ToUpper(); ;
        }
        private void OnListBoxSelectItemChange(week item)
        {
            //if (currentWeek == null) return;
            currentWeekId = item.idweek;
           // CurrentWeek = weeks.Where(p => p.idweek == currentWeekId).Last();


            InitTable(item.idweek);
        }

        private void DeleteLesson()
        {
            if(selectedItem!=null) 
            {
                if(MessageBox.Show((string)Application.Current.Resources["DeleteLesson"], (string)Application.Current.Resources["DeleteCaption"], MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes){
                    selectedItem.teacher1 = null;
                    selectedItem.subject1 = null;
                }
 
            }
        }
    }

    enum WeekListWidthState {
        Open = 200,
        Close = 25,
    }
}
