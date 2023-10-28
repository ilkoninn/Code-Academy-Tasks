using BankConsoleApp.Exceptions.Bank_Exceptions;
using BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions;
using BankConsoleApp.Models.Check_Information_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal class CurrencyConversionByUserBalance
    {
        public static void CurrencyConversion(User user)
        {
            Console.WriteLine("\n\tCurrency conversion section\n");
            PATH40:
            Console.WriteLine("Please, choose a card: ");
            Console.WriteLine("\nCard Number | Card CVV | Card expiration date\n");
            int count = 0;
            foreach (var item in user.bankCards)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
            }
            Console.WriteLine("0. Exit");
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                BankCard userBankCard = CheckBankInformation.GetBankCard(user, choice);
                try
                {
                    if (userBankCard != null)
                    {
                    PATH41:
                        Console.WriteLine("What kind of conversion do you want?");
                        Console.WriteLine("1. AZN - USD");
                        Console.WriteLine("2. AZN - EUR");
                        Console.WriteLine("3. USD - AZN");
                        Console.WriteLine("4. USD - EUR");
                        Console.WriteLine("5. EUR - AZN");
                        Console.WriteLine("6. EUR - USD");
                        Console.Write("User choice(1-6): ");
                        string userChoice2 = Console.ReadLine();
                        if (userChoice2 == "1" || userChoice2 == "2" || userChoice2 == "3" ||
                            userChoice2 == "4" || userChoice2 == "5" || userChoice2 == "6")
                        {
                            ConversionType(userBankCard, userChoice2);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choice, try again!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH41;
                            }
                        }
                    }
                    else
                    {
                        throw new BankCardNotFoundException();
                    }
                }
                catch (BankCardNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH40;
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH40;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, try again!\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH40;
                }
            }
        }

        public static void ConversionType(BankCard bankCard,string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    FromAZNToUSD(bankCard);
                    break;
                case "2":
                    FromAZNToEUR(bankCard);
                    break;
                case "3":
                    FromUSDToAZN(bankCard);
                    break;
                case "4":
                    FromUSDToEUR(bankCard);
                    break;
                case "5":
                    FromEURToAZN(bankCard);
                    break;
                case "6":
                    FromEURToUSD(bankCard);
                    break;
            }
        }

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
