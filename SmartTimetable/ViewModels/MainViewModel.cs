using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartTimetable.Properties;
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
    class MainViewModel : ViewModelBase
    {
        private Page Timetable;
        private Page Stuff;
        private Page Subject;

        public Page CurrentPage { get; set; }

        public bool ttt { get; set; }

        public MainViewModel()
        {
            Timetable = new Pages.Timetable();
            Stuff = new Pages.Stuff();
            Subject = new Pages.Subjects();

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

        public ICommand GoToSubjectPagePage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CurrentPage!=Subject)
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
                    if(Application.Current.MainWindow.WindowState == WindowState.Maximized)
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

    }
}
