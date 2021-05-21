using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartTimetable.Controllers;
using SmartTimetable.Models;
using SmartTimetable.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartTimetable.ViewModels
{
    class UserSettingsWindowVM : ViewModelBase
    {

        public string userName { get; } = Setting.currentUser.name;

        public string newUserName { get; set; } = "";
        public string newUserLogin { get; set; } = "";
        public string newUserPassword { get; set; } = "";
        public string newUserPasswordSecond { get; set; } = "";

        public string newPassword { get; set; } = "";
        public string newPasswordSecond { get; set; } = "";


        public ICommand SaveNewPassword
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if(newPassword == "" || newPasswordSecond == "")
                    {
                        ErrorHandler.NewPasswordsFieldsIsClear();
                    }
                    else if(newPassword.Equals(newPasswordSecond))
                    {
                        Setting.SetNewPassword(sha256(newPassword));
                    }
                    else
                    {
                        ErrorHandler.NewPasswordsNotEquals();
                    }
                });
            }
        }

        public ICommand AddNewUser
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (newUserPassword == "" || newUserPasswordSecond == "" || newUserLogin == "" || newUserName == "")
                    {
                        ErrorHandler.NewUserFieldsIsClear();
                    }
                    else if (newPassword.Equals(newPasswordSecond) )
                    {
                        DataBase.AddNewUser(newUserName,newUserLogin, sha256(newUserPassword));
                    }
                    else
                    {
                        ErrorHandler.NewPasswordsNotEquals();
                    }
                });
            }
        }

        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }
}
