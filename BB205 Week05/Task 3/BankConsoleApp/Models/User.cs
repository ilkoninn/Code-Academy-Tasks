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
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<BankCard> bankCards { get; set; }

        public User(string name, string surname, byte age ,string email, string password, string phoneNumber)
        {
            UserId = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Age = age;
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
        public void UserCurrencyConversion(User user)
        {
            CurrencyConversionByUserBalance.CurrencyConversion(user);
        }
        public void UserSettings(User user)
        {
            Settings.UserSettings(user);
        }
    }
}
