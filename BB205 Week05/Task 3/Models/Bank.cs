using BankConsoleApp.Enums;
using BankConsoleApp.Exceptions;
using BankConsoleApp.Interfaces;
using BankConsoleApp.Models.Bank_Models;
using BankConsoleApp.Models.User_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankConsoleApp.Models
{
    internal class Bank
    {
        internal protected int BankId { get; set; }
        static int _id;
        internal protected string Name { get; set; }
        internal protected static List<User> UserAccounts;

        public Bank(string name)
        {
            BankId = ++_id;
            Name = name;
            UserAccounts = new List<User>();
        }
        
        public static void Transfer()
        {
            MoneyTransferCardToCard.Transfer();
        }
        public void UserRegisterSection()
        {
            Registration.Register();
        }

        public User UserLoginSection()
        {
            User ourUser = null;
            try
            {   
                ourUser = Login.UserLogin();
                if(ourUser == null)
                {
                    throw new UserNotFoundException();
                }
            }
            catch(UserNotFoundException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
            return ourUser;
        }
        
    }
}
