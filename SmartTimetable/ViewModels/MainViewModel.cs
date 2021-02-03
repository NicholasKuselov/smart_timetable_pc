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
        

        public bool AllowTrans {get;set;}

        private Page Timetable;
        private Page Stuff;
        private Button tb;

        public Page CurrentPage { get; set; }

        public bool ttt { get; set; }

        public MainViewModel()
        {
            Timetable = new Pages.Timetable();
            Stuff = new Pages.Stuff();

            CurrentPage = Timetable;
            AllowTrans = false;

        }
        
        public ICommand testClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentPage = Stuff;
                    
                    //Style appButtonStyle =  Resources["appButtonStyle"];
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

                    //Style appButtonStyle =  Resources["appButtonStyle"];
                });
            }
        }

        public ICommand MaximizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    AllowTrans = true;

                    //Style appButtonStyle =  Resources["appButtonStyle"];
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

                    //Style appButtonStyle =  Resources["appButtonStyle"];
                });
            }
        }

    }
}
