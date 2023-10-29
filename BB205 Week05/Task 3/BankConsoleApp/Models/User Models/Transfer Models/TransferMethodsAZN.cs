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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositAZN(bankCard, bankCard2, amount, amount, CurrencyType.AZN, CurrencyType.AZN);
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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositAZN(bankCard, bankCard2, amount2 * (decimal)1.7, amount2 * (decimal)1.7, CurrencyType.AZN, CurrencyType.AZN);
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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositAZN(bankCard, bankCard2, amount3 * (decimal)1.8, amount3 * (decimal)1.8, CurrencyType.AZN, CurrencyType.AZN);
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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositUSD(bankCard, bankCard2, amount, amount * (decimal)0.59, CurrencyType.AZN, CurrencyType.USD);
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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositUSD(bankCard, bankCard2, amount2 * (decimal)1.7, amount2, CurrencyType.AZN, CurrencyType.USD);
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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositUSD(bankCard, bankCard2, amount3 * (decimal)1.8, amount3 * (decimal)1.06, CurrencyType.AZN, CurrencyType.USD);
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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositEUR(bankCard, bankCard2, amount, amount * (decimal)0.55, CurrencyType.AZN, CurrencyType.EUR);
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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositEUR(bankCard, bankCard2, amount2 * (decimal)1.7, amount2 * (decimal)0.94, CurrencyType.AZN, CurrencyType.EUR);
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
                        WithdrawAndDepositAZNMoneyTransfer.WithdrawAZNDepositEUR(bankCard, bankCard2, amount3 * (decimal)1.8, amount3, CurrencyType.AZN, CurrencyType.EUR);
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
