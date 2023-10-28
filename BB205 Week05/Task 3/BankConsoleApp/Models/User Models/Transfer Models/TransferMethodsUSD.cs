using BankConsoleApp.Enums;
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
                        bankCard2.DepositAZN(amount * (decimal)1.7);
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
                        bankCard2.DepositAZN(amount2 * (decimal)1.7);
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
                        bankCard2.DepositAZN(amount3 * (decimal)1.8);
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
                        bankCard2.DepositUSD(amount * (decimal)0.59);
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
                        bankCard2.DepositUSD(amount2);
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
                        bankCard2.DepositUSD(amount3 * (decimal)1.06);
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
                        bankCard2.DepositEUR(amount * (decimal)0.55);
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
                        bankCard2.DepositEUR(amount2 * (decimal)0.55);
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
                        bankCard2.DepositEUR(amount3);
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
