
using BankConsoleApp.Enums;
using BankConsoleApp.Exceptions.Bank_Exceptions;
using BankConsoleApp.Models.Check_Information_Models;
using BankConsoleApp.Models.User_Models.Transfer_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal class MoneyTransferCardToCard
    {
        public static void Transfer(User user)
        {

            Console.WriteLine("\n\tMoney transfer section\n");
        PATH14:
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
                        Console.WriteLine("\nPlease, enter the last 8 digits of the other card numbers");
                        Console.Write("(4050 6070 XXXX XXXX): ");
                        string otherCardNumber = Console.ReadLine().Trim();
                        if (otherCardNumber.Length == 9)
                        {
                            BankCard otherBankCard = CheckBankInformation.GetBankCardByDigit(otherCardNumber);

                            if (otherBankCard != null)
                            {
                                Console.WriteLine($"\nHow much money do you want to transfer from {userBankCard.CardNumber} to {otherBankCard.CardNumber}");
                            PATH15:
                                Console.WriteLine("\nWhich kind of currency type you want to be transfer?");
                                Console.WriteLine("1. AZN");
                                Console.WriteLine("2. USD");
                                Console.WriteLine("3. EUR");
                                Console.Write("User choice(1-3): ");
                                string userChoice3 = Console.ReadLine();
                                if (userChoice3 == "1" || userChoice3 == "2" || userChoice3 == "3")
                                {
                                    if (Enums.CurrencyType.TryParse(userChoice3, out Enums.CurrencyType currencyType))
                                    {
                                    PATH30:
                                        Console.WriteLine("\nWhich balance type do you want to be deposit?");
                                        Console.WriteLine("The first card choice:");
                                        Console.WriteLine("1. AZN Balance");
                                        Console.WriteLine("2. USD Balance");
                                        Console.WriteLine("3. EUR Balance");
                                        Console.Write("User choice(1-3): ");
                                        string userChoice4 = Console.ReadLine();
                                        Console.WriteLine("The second card choice:");
                                        Console.WriteLine("1. AZN Balance");
                                        Console.WriteLine("2. USD Balance");
                                        Console.WriteLine("3. EUR Balance");
                                        Console.Write("User choice(1-3): ");
                                        string userChoice5 = Console.ReadLine();
                                        if ((userChoice4 == "1" || userChoice4 == "2" || userChoice4 == "3") &&
                                            (userChoice5 == "1" || userChoice5 == "2" || userChoice5 == "3"))
                                        {
                                            if (int.TryParse(userChoice4, out int choice2) && int.TryParse(userChoice5, out int choice3))
                                            {
                                                if (choice2 == 1 && choice3 == 1)
                                                {
                                                    TransferMethodsAZN.AZNToAZN(userBankCard, otherBankCard, currencyType);
                                                }
                                                else if (choice2 == 1 && choice3 == 2)
                                                {
                                                    TransferMethodsAZN.AZNToUSD(userBankCard, otherBankCard, currencyType);
                                                }
                                                else if (choice2 == 1 && choice3 == 3)
                                                {
                                                    TransferMethodsAZN.AZNToEUR(userBankCard, otherBankCard, currencyType);
                                                }
                                                else if (choice2 == 2 && choice3 == 1)
                                                {
                                                    TransferMethodsUSD.USDToAZN(userBankCard, otherBankCard, currencyType);
                                                }
                                                else if (choice2 == 2 && choice3 == 2)
                                                {
                                                    TransferMethodsUSD.USDToUSD(userBankCard, otherBankCard, currencyType);
                                                }
                                                else if (choice2 == 2 && choice3 == 3)
                                                {
                                                    TransferMethodsUSD.USDToEUR(userBankCard, otherBankCard, currencyType);
                                                }
                                                else if (choice2 == 3 && choice3 == 1)
                                                {
                                                    TransferMethodsEUR.EURToAZN(userBankCard, otherBankCard, currencyType);
                                                }
                                                else if (choice2 == 3 && choice3 == 2)
                                                {
                                                    TransferMethodsEUR.EURToUSD(userBankCard, otherBankCard, currencyType);
                                                }
                                                else if (choice2 == 3 && choice3 == 3)
                                                {
                                                    TransferMethodsEUR.EURToEUR(userBankCard, otherBankCard, currencyType);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                Console.Write("Continue?(Y/N): ");
                                                string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                if (yesOrNo == "yes" || yesOrNo == "y")
                                                {
                                                    goto PATH30;
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
                                                goto PATH30;
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
                        else
                        {
                            throw new BankCardNotFoundException();
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
                return;
            }
        }
    }
}
