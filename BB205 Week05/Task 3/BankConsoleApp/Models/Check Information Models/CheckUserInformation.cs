using BankConsoleApp.Exceptions.Registartion_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankConsoleApp.Models.Check_Information_Models
{
    internal static class CheckUserInformation
    {
        public static bool CheckName(string name)
        {
            if (!(name.Length >= 3 && char.IsUpper(name[0])))
            {
                return false;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckSurname(string surname)
        {
            if (!(surname.Length >= 3 && char.IsUpper(surname[0])))
            {
                return false;
            }
            for (int i = 1; i < surname.Length; i++)
            {
                if (char.IsDigit(surname[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckAge(string age) 
        {
            if (byte.TryParse(age, out byte userAge))
            {
                if ((userAge >= 18))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckPhoneNumber(string phoneNumber)
        {
            if (!(phoneNumber.Length < 13 && phoneNumber.Length > 8))
            {
                return false;
            }
            return true;
        }
        public static bool CheckEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!regex.IsMatch(email))
            {
                return false;
            }
            return true;
        }
        public static bool CheckPassword(string password)
        {
            Regex regex2 = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");

            if (!regex2.IsMatch(password))
            {
                return false;
            }
            return true;
        }
        public static bool CheckPincode(string pincode)
        {
            if (int.TryParse(pincode, out int newPincode))
            {
                if(newPincode >= 1000 && newPincode <= 9999)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
