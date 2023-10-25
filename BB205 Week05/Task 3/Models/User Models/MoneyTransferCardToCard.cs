
using BankConsoleApp.Enums;
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
        public static void Transfer()
        {

            Console.WriteLine("\n\tMoney transfer section\n");
        PATH14:
            Console.WriteLine("Please, enter the last 8 digits of the first card numbers");
            Console.Write("(4050 6070 XXXX XXXX): ");
            string cardNumber = Console.ReadLine().Trim();
            Console.WriteLine("\nPlease, enter the last 8 digits of the second card numbers");
            Console.Write("(4050 6070 XXXX XXXX): ");
            string cardNumber2 = Console.ReadLine().Trim();
            if (cardNumber.Length == 9 && cardNumber2.Length == 9)
            {
                BankCard newBankCard = null;
                BankCard newBankCard2 = null;
                
                foreach (var item in Bank.UserAccounts)
                {
                    for(int i = 0; i < item.bankCards.Count; i++)
                    {
                        if (item.bankCards[i].CardNumber == $"4050 6070 {cardNumber2}")
                        {
                            newBankCard = item.bankCards[i];
                            break;
                        }
                    }
                }
                foreach (var item in Bank.UserAccounts)
                {
                    for(int i = 0; i < item.bankCards.Count; i++)
                    {
                        if (item.bankCards[i].CardNumber == $"4050 6070 {cardNumber2}")
                        {
                            newBankCard2 = item.bankCards[i];
                            break;
                        }
                    }
                }

                if (newBankCard != null && newBankCard2 != null)
                {
                    Console.WriteLine($"\nHow much money do you want to transfer from {newBankCard.CardNumber} to {newBankCard2.CardNumber}");
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
                                        TransferMethodsAZN.AZNToAZN(newBankCard, newBankCard2, currencyType);
                                    }
                                    else if (choice2 == 1 && choice3 == 2)
                                    {
                                        TransferMethodsAZN.AZNToUSD(newBankCard, newBankCard2, currencyType);
                                    }
                                    else if (choice2 == 1 && choice3 == 3)
                                    {
                                        TransferMethodsAZN.AZNToEUR(newBankCard, newBankCard2, currencyType);
                                    }
                                    else if (choice2 == 2 && choice3 == 1)
                                    {
                                        TransferMethodsUSD.USDToAZN(newBankCard, newBankCard2, currencyType);
                                    }
                                    else if (choice2 == 2 && choice3 == 2)
                                    {
                                        TransferMethodsUSD.USDToUSD(newBankCard, newBankCard2, currencyType);
                                    }
                                    else if (choice2 == 2 && choice3 == 3)
                                    {
                                        TransferMethodsUSD.USDToEUR(newBankCard, newBankCard2, currencyType);
                                    }
                                    else if (choice2 == 3 && choice3 == 1)
                                    {
                                        TransferMethodsEUR.EURToAZN(newBankCard, newBankCard2, currencyType);
                                    }
                                    else if (choice2 == 3 && choice3 == 2)
                                    {
                                        TransferMethodsEUR.EURToUSD(newBankCard, newBankCard2, currencyType);
                                    }
                                    else if (choice2 == 3 && choice3 == 3)
                                    {
                                        TransferMethodsEUR.EURToEUR(newBankCard, newBankCard2, currencyType);
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
                    Console.WriteLine("\nThere is no such cards in your account!, try again!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH14;
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
