using GalaSoft.MvvmLight;
using SmartTimetable.Controllers;
using SmartTimetable.Models.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartTimetable.Models
{
    static class DataBase
    {
        public static SmartTimetableDBContext timetableDB = new SmartTimetableDBContext();

        public static void Init()
        {
            timetableDB = new SmartTimetableDBContext();
        }

        public static void UpdateDB()
        {
            try
            {
                timetableDB.SaveChanges();
                MessageBox.Show("Операція виконана успішно", "Збереження змін", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"Помилка збереження змін",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        
        public static bool Auth(string login,string passHex)
        {
            users[] us = DataBase.timetableDB.users.Where(p => p.login == login).Where(p => p.password == passHex).ToArray();
            if (us.Length > 0)
            {
                Setting.currentUser = us[0];
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddNewUser(string name,string login,string passwordHex)
        {
            if (DataBase.timetableDB.users.Where(p => p.login == login).Count() > 0)
            {
                ErrorHandler.NewUserLoginAlreadyRegister();
            }
            else
            {
                users tmp = new users();
                tmp.idusers = timetableDB.users.Last().idusers++;
                tmp.name = name;
                tmp.password = passwordHex;
                tmp.login = login;
                timetableDB.users.Add(tmp);
                UpdateDB();
            }
        }
    }
}
