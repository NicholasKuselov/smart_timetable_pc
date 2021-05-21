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

        public static void NewPasswordsNotEquals()
        {
            MessageBox.Show((string)Application.Current.Resources["NewPasswordsNotEqualsText"], (string)Application.Current.Resources["NewPasswordscaption"], MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void NewPasswordsFieldsIsClear()
        {
            MessageBox.Show((string)Application.Current.Resources["NewPasswordsFieldsIsClearText"], (string)Application.Current.Resources["NewPasswordscaption"], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void NewUserFieldsIsClear()
        {
            MessageBox.Show((string)Application.Current.Resources["NewUserFieldsClearText"], (string)Application.Current.Resources["NewUsercaption"], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void NewUserLoginAlreadyRegister()
        {
            MessageBox.Show((string)Application.Current.Resources["NewUserLoginAlreadyRegisterText"], (string)Application.Current.Resources["NewUsercaption"], MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

