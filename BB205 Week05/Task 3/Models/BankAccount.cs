using BankConsoleApp.Enums;
using BankConsoleApp.Exceptions;
using BankConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankConsoleApp.Models
{
    internal class BankAccount : IAccount
    {
        // Transaction-ları metodların daxilinə əlavə etmək lazımdır!
        internal protected Transaction[] transactions;

        // Bank User properities
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static string PhoneNumber { get; set; }

        // Bank Account properities
        public int Pincode { get; set; }
        public int AccountId { get; set; }
        static int count;
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }

        public decimal BalanceAZN { get; set; }
        public decimal BalanceUSD { get; set; }
        public decimal BalanceEUR { get; set; }


        public AccountType AccountType { get; set; }

        public CurrencyType CurrencyType { get; set; }

        public BankAccount(int pincode, string cardNumber, DateTime expirationDate, int cvv, AccountType accountType, CurrencyType currencyType)
        {
            AccountId = ++count;
            BalanceAZN = 0;
            BalanceUSD = 0;
            BalanceEUR = 0;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CVV = cvv;
            Pincode = pincode;
            AccountType = accountType;
            CurrencyType = currencyType;
            transactions = new Transaction[0];
        }
        public BankAccount(string name, string surname, string phoneNumber, string email, string password, int pinCode, string cardNumber, DateTime expirationDate, int cvv,AccountType accountType, CurrencyType currencyType)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Pincode = pinCode;
            AccountId = ++count;
            BalanceAZN = 0;
            BalanceUSD = 0;
            BalanceEUR = 0;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CVV = cvv;
            AccountType = accountType;
            CurrencyType = currencyType;
            transactions = new Transaction[0];
        }
        public void DepositAZN(decimal amount)
        {

            BalanceAZN += amount;

        }
        public void DepositUSD(decimal amount)
        {

            BalanceUSD += amount;

        }
        public void DepositEUR(decimal amount)
        {

            BalanceEUR += amount;

        }

        public void WithDrawAZN(decimal amount)
        {
            try
            {
                if(amount > BalanceAZN) 
                {
                    throw new InsufficientFundsException("There are no funds on your card equal to the amount entered");
                }
                else
                {
                    BalanceAZN -= amount;
                }
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
        }
        public void WithDrawUSD(decimal amount)
        {
            try
            {
                if (amount > BalanceUSD)
                {
                    throw new InsufficientFundsException("There are no funds on your card equal to the amount entered");
                }
                else
                {
                    BalanceUSD -= amount;
                }
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
        }
        public void WithDrawEUR(decimal amount)
        {
            try
            {
                if (amount > BalanceEUR)
                {
                    throw new InsufficientFundsException("There are no funds on your card equal to the amount entered");
                }
                else
                {
                    BalanceEUR -= amount;
                }
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
