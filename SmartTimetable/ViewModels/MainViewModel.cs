using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartTimetable.Controllers;
using SmartTimetable.Properties;
using SmartTimetable.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Resources;

namespace SmartTimetable.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Page Timetable;
        private Page Stuff;
        private Page Subject;
        private Page Group;
        private Page Course;

        public Page CurrentPage { get; set; }

        public bool ttt { get; set; }

        public string userName { get; set; } = Setting.currentUser.name;


        public MainViewModel()
        {
            Timetable = new Pages.Timetable();
            Stuff = new Pages.Stuff();
            Subject = new Pages.Subjects();
            Group = new Pages.Group();
            Course = new Pages.Course();

            CurrentPage = Timetable;
        }

        public ICommand GoToStuffPage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CurrentPage != Stuff)
                    {
                        CurrentPage = Stuff;
                    }
                });
            }
        }

        public ICommand GoToGroupPage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CurrentPage != Group)
                    {
                        CurrentPage = Group;
                    }
                });
            }
        }

        public ICommand GoToCoursePage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CurrentPage != Course)
                    {
                        CurrentPage = Course;
                    }
                });
            }
        }

        public ICommand GoToSubjectPagePage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CurrentPage != Subject)
                    {
                        CurrentPage = Subject;
                    }

                });
            }
        }
        public ICommand GoToTimetablePage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CurrentPage != Timetable)
                    {
                        CurrentPage = Timetable;
                    }
                });
            }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.MainWindow.Close();
                });
            }
        }

        public ICommand MaximizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    }

                });
            }
        }

        public ICommand MinimizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                });
            }
        }


        public void UpdateUserName()
        {
            userName = Setting.currentUser.name;
        }


    }
}
