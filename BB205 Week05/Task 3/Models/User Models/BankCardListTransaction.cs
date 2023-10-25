using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal class BankCardListTransaction
    {
        public static void ListTransactions(User user)
        {
            Console.WriteLine("\n\tTransaction list\n");
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
            PATH26:
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
                    Console.WriteLine($"\n\t{newBankCard.CardNumber} transaction list\n");
                    foreach (var item in newBankCard.transactions)
                    {
                        Console.WriteLine($"Transaction type: {item.TransactionType}\n" +
                            $"Transaction date: {item.TransactionDate}\n" +
                            $"Transaction amount: {item.Amount}\n" +
                            $"Transaction currency type: {item.CurrencyType}\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH26;
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
                    goto PATH26;
                }
            }
        }
    }
}
