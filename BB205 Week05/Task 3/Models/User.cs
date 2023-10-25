using BankConsoleApp.Models.User_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models
{
    internal class User
    {
        // Bank User properities
        int UserId { get; set; }
        static int _id;
        internal protected string Name { get; set; }
        internal protected string Surname { get; set; }
        internal protected string Email { get; set; }
        internal protected string Password { get; set; }
        internal protected string PhoneNumber { get; set; }
        internal protected List<BankCard> bankCards { get; set; }

        public User(string name, string surname, string email, string password, string phoneNumber)
        {
            UserId = ++_id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            bankCards = new List<BankCard> { };
        }

        public void DepositMoney(User user)
        {
            DepositMoneyToBankCard.DepositMoney(user);
        }
        public void WithdrawMoney(User user)
        {
            WithdrawMoneyFromBankCard.WithdrawMoney(user);
        }
        public void ListTransaction(User user)
        {
            BankCardListTransaction.ListTransactions(user);
        }
        public void ShowAllCards(User user)
        {
            ShowAllBankCards.GetAllCards(user);
        }
        public void AddCard(User user)
        {
            AddBankCard.AddCard(user);
        }
        public void DeleteCard(User user)
        {
            DeleteBankCard.DeleteAccount(user);
        }
        public void UserSettings(User user)
        {
            Settings.UserSettings(user);
        }
    }
}
