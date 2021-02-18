using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartTimetable.Models;
using SmartTimetable.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartTimetable.ViewModels
{
    class TimetableWindowViewModel : ViewModelBase
    {
        public Page page { get; set; }
        public BindingList<group> groups { get; set; }
        public BindingList<course> courses { get; set; }
        public BindingList<timetable> timetables { get; set; }
        public BindingList<teacher> teachers { get; set; }
        public BindingList<week> weeks { get; set; }
        public BindingList<subject> subjects { get; set; }

        public BindingList<timetable> currentWeekTimetable { get; set; }

        public int currentWeekId { get; set; }

        public BindingList<timetable> FirstDay { get; set; }
        public BindingList<timetable> SecondDay { get; set; }
        public BindingList<timetable> ThirdDay { get; set; }
        public BindingList<timetable> FourthDay { get; set; }
        public BindingList<timetable> FifthDay { get; set; }
        public BindingList<timetable> SixthDay { get; set; }

        List<BindingList<timetable>> Days = new List<BindingList<timetable>>();

        //public EDM_SmartTimetableDB timetableDB { get; set; }

        public TimetableWindowViewModel()
        {
            //timetableDB = new EDM_SmartTimetableDB();
            currentWeekId = 1;

            page = new TinetableCreationStage();

            DataBase.timetableDB.week.Load();
            DataBase.timetableDB.teacher.Load();
            DataBase.timetableDB.timetable.Load();
            DataBase.timetableDB.group.Load();
            DataBase.timetableDB.course.Load();
            DataBase.timetableDB.subject.Load();

            groups = DataBase.timetableDB.group.Local.ToBindingList();
            weeks = DataBase.timetableDB.week.Local.ToBindingList();
            teachers = DataBase.timetableDB.teacher.Local.ToBindingList();
            timetables = DataBase.timetableDB.timetable.Local.ToBindingList();
            courses = DataBase.timetableDB.course.Local.ToBindingList();
            subjects = DataBase.timetableDB.subject.Local.ToBindingList();
            currentWeekTimetable = new BindingList<timetable>(timetables.Where(p => p.Week == currentWeekId).ToList<timetable>());
            IEnumerable<timetable> fff = timetables.Where(p => p.Week == 1);

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
            //for (int i = 0; i < Days.Count; i++)
            //{
            //    Days[i] = new BindingList<timetable>();
            //}
            //weeks = 
            //Weeks = new ObservableCollection<Week>(DataBase.GetWeeks());
            CreateDays();
        }

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


        public void CreateDays()
        {
            string testDate = "08:02:21";
            
            for (int i = 0; i < Days.Count; i++)
            {
               
                foreach (course f_course in courses)
                {
                    foreach (group f_group in groups)
                    {
                        foreach (LessonTimeModel f_Time in LessonsTime.lessonTimes)
                        {
                            //if(currentWeekTimetable.Where(p => p.Date == testDate.ToString() && p.Time == f_Time.GetTime() && p.Day == i + 1 && p.Course == f_course.idcourse && p.Group == f_group.idgroup).ToList<timetable>().Count>0)

                            timetable tt = CheckLesson(currentWeekTimetable.ToList<timetable>(), testDate.ToString(), f_Time.GetTime(), i + 1, f_course.idcourse, f_group.idgroup);

                            if (tt == null)
                            {
                                tt = new timetable();
                                tt.Date = testDate.ToString(); //??
                                tt.Day = i + 1;
                                tt.Week = currentWeekId;
                                tt.Group = f_group.idgroup;
                                tt.Course = f_course.idcourse;
                                tt.Time = f_Time.GetTime();
                            }
                            Days[i].Add(tt);
                        }
                    }
                }
               
            }
        }

        public void MergerTable()
        {
            
        }

        private timetable CheckLesson(List<timetable> currWeek, string date,string time,int day,int course,int group)
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

    }
}
