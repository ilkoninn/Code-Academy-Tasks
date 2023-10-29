using BankConsoleApp.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Currency_Conversion_Model
{
    internal static class CurrencyConversionMoneyToMoney
    {
        public static void FromAZNToUSD(User user, BankCard bankCard)
        {
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
                WithdrawAndDepositMoneyConversion.WithdrawAZNDepositUSD(user, bankCard, amount, amount * (decimal)0.59, CurrencyType.AZN, CurrencyType.USD);
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
        }
        public static void FromAZNToEUR(User user, BankCard bankCard)
        {
        PATH2:
            Console.Write("\nMoney value:");
            string transferMoney2 = Console.ReadLine();
            if (decimal.TryParse(transferMoney2, out var amount2))
            {
                if (bankCard.BalanceAZN < amount2)
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
                WithdrawAndDepositMoneyConversion.WithdrawAZNDepositEUR(user, bankCard, amount2, amount2 * (decimal)0.55, CurrencyType.AZN, CurrencyType.EUR);
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
        }
        public static void FromUSDToAZN(User user, BankCard bankCard)
        {
        PATH3:
            Console.Write("\nMoney value:");
            string transferMoney3 = Console.ReadLine();
            if (decimal.TryParse(transferMoney3, out var amount3))
            {
                if (bankCard.BalanceUSD < amount3)
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
                WithdrawAndDepositMoneyConversion.WithdrawUSDDepositAZN(user, bankCard, amount3, amount3 * (decimal)1.7, CurrencyType.USD, CurrencyType.AZN);
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
        }
        public static void FromUSDToEUR(User user, BankCard bankCard)
        {
        PATH4:
            Console.Write("\nMoney value:");
            string transferMoney4 = Console.ReadLine();
            if (decimal.TryParse(transferMoney4, out var amount4))
            {
                if (bankCard.BalanceUSD < amount4)
                {
                    Console.WriteLine("\nThe amount of money is greater than balance!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH4;
                    }
                    return;
                }
                WithdrawAndDepositMoneyConversion.WithdrawUSDDepositEUR(user, bankCard, amount4, amount4 * (decimal)0.94, CurrencyType.USD, CurrencyType.EUR);
            }
            else
            {
                Console.WriteLine("\nThe amount of money should be decimal type!");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH4;
                }
            }
        }
        public static void FromEURToAZN(User user, BankCard bankCard)
        {
        PATH5:
            Console.Write("\nMoney value:");
            string transferMoney5 = Console.ReadLine();
            if (decimal.TryParse(transferMoney5, out var amount5))
            {
                if (bankCard.BalanceEUR < amount5)
                {
                    Console.WriteLine("\nThe amount of money is greater than balance!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH5;
                    }
                    return;
                }
                WithdrawAndDepositMoneyConversion.WithdrawEURDepositAZN(user, bankCard, amount5, amount5 * (decimal)1.8, CurrencyType.EUR, CurrencyType.AZN);
            }
            else
            {
                Console.WriteLine("\nThe amount of money should be decimal type!");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH5;
                }
            }
        }
        public static void FromEURToUSD(User user, BankCard bankCard)
        {
        PATH6:
            Console.Write("\nMoney value:");
            string transferMoney6 = Console.ReadLine();
            if (decimal.TryParse(transferMoney6, out var amount6))
            {
                if (bankCard.BalanceEUR < amount6)
                {
                    Console.WriteLine("\nThe amount of money is greater than balance!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH6;
                    }
                    return;
                }
                WithdrawAndDepositMoneyConversion.WithdrawEURDepositUSD(user, bankCard, amount6, amount6 * (decimal)1.06, CurrencyType.EUR, CurrencyType.USD);
            }
            else
            {
                Console.WriteLine("\nThe amount of money should be decimal type!");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH6;
                }
            }
        }
    }
}
