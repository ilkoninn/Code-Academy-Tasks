using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Transfer_Models
{
    internal class TransferMethodsAZN
    {
        public static void AZNToAZN(BankCard bankCard, BankCard bankCard2,CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.AZN:
                    PATH1:
                    Console.Write("\nMoney value:");
                    string transferMoney = Console.ReadLine();
                    if (decimal.TryParse(transferMoney, out var amount))
                    {
                        if(bankCard.BalanceAZN < amount)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH1;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositAZN(amount);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount, dateTime2, Operations.DepositMoney, currencyType);
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
                        if (bankCard.BalanceAZN < amount2 * (decimal)1.7)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH2;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount2 * (decimal)1.7);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount2 * (decimal)1.7, dateTime, Operations.WithdrawMoney, currencyType);
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
                        if (bankCard.BalanceAZN < amount3 * (decimal)1.8)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH3;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount3 * (decimal)1.8);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount3 * (decimal)1.8, dateTime, Operations.WithdrawMoney, currencyType);
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
        public static void AZNToUSD(BankCard bankCard, BankCard bankCard2, CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.AZN:
                    PATH1:
                    Console.Write("\nMoney value:");
                    string transferMoney = Console.ReadLine();
                    if (decimal.TryParse(transferMoney, out var amount))
                    {
                        if (bankCard.BalanceAZN < amount)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH1;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount, dateTime, Operations.WithdrawMoney, currencyType);
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
                        if (bankCard.BalanceAZN < amount2 * (decimal)1.7)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH2;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount2 * (decimal)1.7);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount2 * (decimal)1.7, dateTime, Operations.WithdrawMoney, currencyType);
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
                        if (bankCard.BalanceAZN < amount3 * (decimal)1.8)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH3;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount3 * (decimal)1.8);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount3 * (decimal)1.8, dateTime, Operations.WithdrawMoney, currencyType);
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
        public static void AZNToEUR(BankCard bankCard, BankCard bankCard2, CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.AZN:
                    PATH1:
                    Console.Write("\nMoney value:");
                    string transferMoney = Console.ReadLine();
                    if (decimal.TryParse(transferMoney, out var amount))
                    {
                        if (bankCard.BalanceAZN < amount)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH1;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount, dateTime, Operations.WithdrawMoney, currencyType);
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
                        if (bankCard.BalanceAZN < amount2 * (decimal)1.7)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH2;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount2 * (decimal)1.7);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount2 * (decimal)1.7, dateTime, Operations.WithdrawMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                        bankCard2.DepositEUR(amount2 * (decimal)0.94);
                        DateTime dateTime2 = DateTime.Now;
                        Transaction transaction2 = new Transaction(amount2 * (decimal)0.94, dateTime2, Operations.DepositMoney, currencyType);
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
                        if (bankCard.BalanceAZN < amount3 * (decimal)1.8)
                        {
                            Console.WriteLine("\nThe amount of money is greater than balance!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH3;
                            }
                            return;
                        }
                        bankCard.WithDrawAZN(amount3 * (decimal)1.8);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(amount3 * (decimal)1.8, dateTime, Operations.WithdrawMoney, currencyType);
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
