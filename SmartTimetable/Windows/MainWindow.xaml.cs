using SmartTimetable.Controllers;
using SmartTimetable.ViewModels;
using SmartTimetable.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartTimetable
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            DataContext = new MainViewModel();
            this.SourceInitialized += new EventHandler(Window1_SourceInitialized);
            StartAuth();
        }
        void Window1_SourceInitialized(object sender, EventArgs e)
        {
            WindowSizing.WindowInitialized(this);
        }

        public void AuthSuccess()
        {
            ((MainViewModel)this.DataContext).UpdateUserName();
            this.Show();
        }

        public void StartAuth()
        {
            this.Hide();
            new EntryWindow(this).Show();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            new UserSettingsWindow(this).Show();
        }
    }
}
