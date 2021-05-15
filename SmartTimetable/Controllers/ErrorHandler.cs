using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartTimetable.Controllers
{
    class ErrorHandler
    {
        public static void AuthFailed()
        {
            MessageBox.Show((string)Application.Current.Resources["AuthFailText"], (string)Application.Current.Resources["AuthFailcaption"], MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

