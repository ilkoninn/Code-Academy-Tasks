﻿using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Transfer_Models
{
    internal class TransferMethodsUSD
    {
        public static void USDToAZN(BankCard bankCard, BankCard bankCard2, CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.AZN:
                PATH1:
                    Console.Write("\nMoney value:");
                    string transferMoney = Console.ReadLine();
                    if (decimal.TryParse(transferMoney, out var amount))
                    {
                        bankCard.WithDrawUSD(amount * (decimal)0.59);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount * (decimal)0.59, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositAZN(amount * (decimal)1.7);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount * (decimal)1.7, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!\n");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH1;
                        }
                    }
                    break;
                case CurrencyType.USD:
                PATH2:
                    Console.Write("\nMoney value:");
                    string transferMoney2 = Console.ReadLine();
                    if (decimal.TryParse(transferMoney2, out var amount2))
                    {
                        bankCard.WithDrawUSD(amount2);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount2, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositAZN(amount2 * (decimal)1.7);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount2 * (decimal)1.7, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!\n");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH2;
                        }
                    }
                    break;
                case CurrencyType.EUR:
                PATH3:
                    Console.Write("\nMoney value:");
                    string transferMoney3 = Console.ReadLine();
                    if (decimal.TryParse(transferMoney3, out var amount3))
                    {
                        bankCard.WithDrawUSD(amount3 * (decimal)1.06);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount3 * (decimal)1.06, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositAZN(amount3 * (decimal)1.8);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount3 * (decimal)1.8, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!\n");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH3;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    break;
            }
        }
        public static void USDToUSD(BankCard bankCard, BankCard bankCard2, CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.AZN:
                PATH1:
                    Console.Write("\nMoney value:");
                    string transferMoney = Console.ReadLine();
                    if (decimal.TryParse(transferMoney, out var amount))
                    {
                        bankCard.WithDrawUSD(amount * (decimal)0.59);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount * (decimal)0.59, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositUSD(amount * (decimal)0.59);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount * (decimal)0.59, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH1;
                        }
                    }
                    break;
                case CurrencyType.USD:
                PATH2:
                    Console.Write("\nMoney value:");
                    string transferMoney2 = Console.ReadLine();
                    if (decimal.TryParse(transferMoney2, out var amount2))
                    {
                        bankCard.WithDrawUSD(amount2);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount2, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositUSD(amount2);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount2, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH2;
                        }
                    }
                    break;
                case CurrencyType.EUR:
                PATH3:
                    Console.Write("\nMoney value:");
                    string transferMoney3 = Console.ReadLine();
                    if (decimal.TryParse(transferMoney3, out var amount3))
                    {
                        bankCard.WithDrawAZN(amount3 * (decimal)1.06);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount3 * (decimal)1.06, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositUSD(amount3 * (decimal)1.06);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount3 * (decimal)1.06, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH3;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    break;
            }
        }
        public static void USDToEUR(BankCard bankCard, BankCard bankCard2, CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.AZN:
                PATH1:
                    Console.Write("\nMoney value:");
                    string transferMoney = Console.ReadLine();
                    if (decimal.TryParse(transferMoney, out var amount))
                    {
                        bankCard.WithDrawUSD(amount * (decimal)0.59);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount * (decimal)0.59, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositEUR(amount * (decimal)0.55);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount * (decimal)0.55, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH1;
                        }
                    }
                    break;
                case CurrencyType.USD:
                PATH2:
                    Console.Write("\nMoney value:");
                    string transferMoney2 = Console.ReadLine();
                    if (decimal.TryParse(transferMoney2, out var amount2))
                    {
                        bankCard.WithDrawUSD(amount2);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount2, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositEUR(amount2 * (decimal)0.55);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount2 * (decimal)0.55, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH2;
                        }
                    }
                    break;
                case CurrencyType.EUR:
                PATH3:
                    Console.Write("\nMoney value:");
                    string transferMoney3 = Console.ReadLine();
                    if (decimal.TryParse(transferMoney3, out var amount3))
                    {
                        bankCard.WithDrawUSD(amount3 * (decimal)1.06);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount3 * (decimal)1.06, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositEUR(amount3);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount3, dateTime2, Operations.DepositMoney, currencyType);
                        bankCard2.transactions.Add(transaction2);
                    }
                    else
                    {
                        Console.WriteLine("\nThe amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH3;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    break;
            }
        }
    }
}
