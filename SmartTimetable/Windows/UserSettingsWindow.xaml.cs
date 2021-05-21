using SmartTimetable.ViewModels;
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
using System.Windows.Shapes;

namespace SmartTimetable.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserSettingsWindow.xaml
    /// </summary>
    public partial class UserSettingsWindow : Window
    {
        MainWindow parent;
        public UserSettingsWindow(MainWindow parent)
        {
            InitializeComponent();
            this.DataContext = new UserSettingsWindowVM();
            this.parent = parent;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            parent.StartAuth();
            this.Close();
        }
    }
}
