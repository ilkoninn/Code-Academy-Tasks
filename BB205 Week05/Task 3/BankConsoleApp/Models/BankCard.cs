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
    internal class BankCard : IBankCard
    {
        // Transaction-ları metodların daxilinə əlavə etmək lazımdır!
        public List<Transaction> transactions;


        // Bank Account properities
        public int Pincode { get; set; }
        public Guid AccountId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }

        public decimal BalanceAZN { get; set; }
        public decimal BalanceUSD { get; set; }
        public decimal BalanceEUR { get; set; }


        public AccountType AccountType { get; set; }

        public CurrencyType CurrencyType { get; set; }

        public BankCard(int pincode, string cardNumber, DateTime expirationDate, int cvv, AccountType accountType, CurrencyType currencyType)
        {
            AccountId = Guid.NewGuid();
            BalanceAZN = 0;
            BalanceUSD = 0;
            BalanceEUR = 0;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CVV = cvv;
            Pincode = pincode;
            AccountType = accountType;
            CurrencyType = currencyType;
            transactions = new List<Transaction> { };
        }

        public void DepositAZN(decimal amount)
        {
            try
            {
                if(amount > 0)
                {
                    BalanceAZN += amount;
                }
                else
                {
                    throw new InvalidAmountException("Deposit amount must be greater than 0, try again!");
                }
            }
            catch(InvalidAmountException ex) 
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }

        }
        public void DepositUSD(decimal amount)
        {
            try
            {
                if (amount > 0)
                {
                    BalanceUSD += amount;
                }
                else
                {
                    throw new InvalidAmountException("Deposit amount must be greater than 0, try again!");
                }
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }
        public void DepositEUR(decimal amount)
        {
            try
            {
                if (amount > 0)
                {
                    BalanceEUR += amount;
                }
                else
                {
                    throw new InvalidAmountException("Deposit amount must be greater than 0, try again!");
                }
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }

        public void WithDrawAZN(decimal amount)
        {
            try
            {
                if (amount > 0)
                {
                    if (amount > BalanceAZN)
                    {
                        throw new InsufficientFundsException("There are no funds on your card equal to the amount entered");
                    }
                    else
                    {
                        BalanceAZN -= amount;
                    }
                }
                else
                {
                    throw new InvalidAmountException("Withdraw amount must be greater than 0, try again!");
                }

            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }
        public void WithDrawUSD(decimal amount)
        {
            try
            {
                if (amount > 0)
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
                else
                {
                    throw new InvalidAmountException("Withdraw amount must be greater than 0, try again!");
                }

            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }
        public void WithDrawEUR(decimal amount)
        {
            try
            {
                if (amount > 0)
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
                else
                {
                    throw new InvalidAmountException("Withdraw amount must be greater than 0, try again!");
                }

            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }
    }
}
