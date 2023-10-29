using BankConsoleApp.Enums;
using BankConsoleApp.Exceptions.Bank_Exceptions;
using BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions;
using BankConsoleApp.Models.Check_Information_Models;
using BankConsoleApp.Models.User_Models.Deposit_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal static class DepositMoneyToBankCard
    {
        public static void DepositMoney(User user)
        {
            Console.WriteLine("\n\tDeposit Money section\n");
            PATH14:
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
                    PATH15:
                        Console.WriteLine("\nWhich kind of currency type you want to be deposit?");
                        Console.WriteLine("1. AZN");
                        Console.WriteLine("2. USD");
                        Console.WriteLine("3. EUR");
                        Console.Write("User choice(1-3): ");
                        string userChoice2 = Console.ReadLine();
                        if (userChoice2 == "1" || userChoice2 == "2" || userChoice2 == "3")
                        {
                            if (Enums.CurrencyType.TryParse(userChoice2, out Enums.CurrencyType currencyType))
                            {

                            PATH25:
                                Console.WriteLine("\nWhich balance type do you want to be deposit?");
                                Console.WriteLine("1. AZN Balance");
                                Console.WriteLine("2. USD Balance");
                                Console.WriteLine("3. EUR Balance");
                                Console.Write("User choice(1-3): ");
                                string userChoice4 = Console.ReadLine();
                                if (userChoice4 == "1" || userChoice4 == "2" || userChoice4 == "3")
                                {
                                    if (int.TryParse(userChoice4, out int choice2))
                                    {
                                        switch (choice2)
                                        {
                                            case 0:
                                                return;
                                                break;
                                            case 1:
                                                DepositToAZNBalance.Deposit(user, userBankCard, currencyType);
                                                break;
                                            case 2:
                                                DepositToUSDBalance.Deposit(user, userBankCard, currencyType);
                                                break;
                                            case 3:
                                                DepositToEURBalance.Deposit(user, userBankCard, currencyType);
                                                break;
                                            default:
                                                Console.WriteLine("Invalid choice, try again!");
                                                Console.Write("Continue?(Y/N): ");
                                                string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                if (yesOrNo == "yes" || yesOrNo == "y")
                                                {
                                                    goto PATH25;
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid choice, try again!\n");
                                        Console.Write("Continue?(Y/N): ");
                                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                                        if (yesOrNo == "yes" || yesOrNo == "y")
                                        {
                                            goto PATH25;
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
                                        goto PATH25;
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
                                    goto PATH15;
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
                                goto PATH15;
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
                        goto PATH14;
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
                        goto PATH14;
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
                    goto PATH14;
                }
            }
        }        
    }
}
