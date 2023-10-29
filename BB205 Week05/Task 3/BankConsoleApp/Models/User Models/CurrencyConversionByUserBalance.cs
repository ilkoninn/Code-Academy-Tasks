using BankConsoleApp.Exceptions.Bank_Exceptions;
using BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions;
using BankConsoleApp.Models.Check_Information_Models;
using BankConsoleApp.Models.User_Models.Currency_Conversion_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal static class CurrencyConversionByUserBalance
    {
        public static void CurrencyConversion(User user)
        {
            Console.WriteLine("\n\tCurrency conversion section\n");
        PATH40:
            CheckBankInformation.GetCards(user);
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
                            ConversionType(user, userBankCard, userChoice2);
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

        public static void ConversionType(User user, BankCard bankCard,string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    CurrencyConversionMoneyToMoney.FromAZNToUSD(user, bankCard);
                    break;
                case "2":
                    CurrencyConversionMoneyToMoney.FromAZNToEUR(user, bankCard);
                    break;
                case "3":
                    CurrencyConversionMoneyToMoney.FromUSDToAZN(user, bankCard);
                    break;
                case "4":
                    CurrencyConversionMoneyToMoney.FromUSDToEUR(user, bankCard);
                    break;
                case "5":
                    CurrencyConversionMoneyToMoney.FromEURToAZN(user, bankCard);
                    break;
                case "6":
                    CurrencyConversionMoneyToMoney.FromEURToUSD(user, bankCard);
                    break;
            }
        }

    }
}
