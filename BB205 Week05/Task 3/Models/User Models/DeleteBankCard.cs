using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal class DeleteBankCard
    {
        public static void DeleteAccount(User user)
        {
            Console.WriteLine("\n\tDelete Account section\n");
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
        PATH12:
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                if (choice <= count)
                {
                    BankCard newBankCard = null;
                    for (int i = 0; i < user.bankCards.Count; i++)
                    {
                        if (choice == i + 1)
                        {
                            newBankCard = user.bankCards[i];
                            break;
                        }
                    }
                PATH13:
                    Console.Write("Please, enter card's pincode: ");
                    string userPincode = Console.ReadLine();
                    if (int.TryParse(userPincode, out int pincode) && userPincode.Length == 4)
                    {
                        if (newBankCard.Pincode == pincode)
                        {
                            user.bankCards.Remove(newBankCard);
                            Console.WriteLine("\nBank card successfully deleted!\n");
                        }
                        else
                        {
                            Console.WriteLine("\nThis card's pincode is not like that!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH13;
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
                            goto PATH13;
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
                        goto PATH12;
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
                    goto PATH12;
                }
            }
        }
    }
}
