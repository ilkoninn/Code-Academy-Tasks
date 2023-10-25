using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal class ShowAllBankCards
    {
        public static void GetAllCards(User user)
        {
            Console.WriteLine("\n\tYour bank cards\n");
            Console.WriteLine("Card Number | Card CVV | Card expiration date\n");

            int count = 0;
            foreach (var item in user.bankCards)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
                Console.WriteLine($"Card balance(AZN): {item.BalanceAZN}");
                Console.WriteLine($"Card balance(USD): {item.BalanceUSD}");
                Console.WriteLine($"Card balance(EUR): {item.BalanceEUR}");
                Console.WriteLine($"Account type: {item.AccountType}");
                Console.WriteLine($"Currency type: {item.CurrencyType}");
                Console.WriteLine();
            }

        }
    }
}
