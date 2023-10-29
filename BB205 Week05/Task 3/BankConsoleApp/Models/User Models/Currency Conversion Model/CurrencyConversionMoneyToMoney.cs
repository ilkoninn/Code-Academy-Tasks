using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Currency_Conversion_Model
{
    internal static class CurrencyConversionMoneyToMoney
    {
        public static void FromAZNToUSD(BankCard bankCard)
        {
        PATH1:
            Console.Write("\nMoney value:");
            string transferMoney = Console.ReadLine();
            if (decimal.TryParse(transferMoney, out var amount))
            {
                bankCard.WithDrawAZN(amount);
                bankCard.DepositUSD(amount * (decimal)0.59);
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
        public static void FromAZNToEUR(BankCard bankCard)
        {
        PATH2:
            Console.Write("\nMoney value:");
            string transferMoney2 = Console.ReadLine();
            if (decimal.TryParse(transferMoney2, out var amount2))
            {
                bankCard.WithDrawAZN(amount2);
                bankCard.DepositEUR(amount2 * (decimal)0.55);
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
        public static void FromUSDToAZN(BankCard bankCard)
        {
        PATH3:
            Console.Write("\nMoney value:");
            string transferMoney3 = Console.ReadLine();
            if (decimal.TryParse(transferMoney3, out var amount3))
            {
                bankCard.WithDrawUSD(amount3);
                bankCard.DepositAZN(amount3 * (decimal)1.7);
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
        public static void FromUSDToEUR(BankCard bankCard)
        {
        PATH4:
            Console.Write("\nMoney value:");
            string transferMoney4 = Console.ReadLine();
            if (decimal.TryParse(transferMoney4, out var amount4))
            {
                bankCard.WithDrawUSD(amount4);
                bankCard.DepositEUR(amount4 * (decimal)0.94);
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
        public static void FromEURToAZN(BankCard bankCard)
        {
        PATH5:
            Console.Write("\nMoney value:");
            string transferMoney5 = Console.ReadLine();
            if (decimal.TryParse(transferMoney5, out var amount5))
            {
                bankCard.WithDrawEUR(amount5);
                bankCard.DepositAZN(amount5 * (decimal)1.8);
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
        public static void FromEURToUSD(BankCard bankCard)
        {
        PATH6:
            Console.Write("\nMoney value:");
            string transferMoney6 = Console.ReadLine();
            if (decimal.TryParse(transferMoney6, out var amount6))
            {
                bankCard.WithDrawEUR(amount6);
                bankCard.DepositUSD(amount6 * (decimal)1.06);
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
