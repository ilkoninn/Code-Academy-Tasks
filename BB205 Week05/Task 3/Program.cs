using BankConsoleApp.Enums;
using BankConsoleApp.Models;
using System.ComponentModel.Design;
using System.IO.Pipes;

namespace BankConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();   
        }

        public static void Menu()
        {
            // Variables section
            bool running = true;
            Bank bank = new Bank("Ilkin");

            Console.WriteLine("==========================================");
            
            do
            {
                // Before operations Menu
                if(!bank.RunCheck)
                {
                    Console.WriteLine($"\n\tWelcome to {bank.Name} Bank\n");
                    Console.WriteLine("1. Sign up");
                    Console.WriteLine("0. Exit");
                    Console.Write("\nPlease, enter a number(0-1): ");
                    string userChoice = Console.ReadLine();
                    if (int.TryParse(userChoice, out int choice))
                    {
                        if(choice == 0) running = false;
                        FirstMenu(choice, bank);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, you should be enter a number!");
                    }
                }
                // After operations Menu
                else
                {
                    Console.WriteLine($"\n\tWelcome {BankAccount.Name} {BankAccount.Surname} \n");
                    Console.WriteLine("1. Deposit money");
                    Console.WriteLine("2. Withdraw money"); 
                    Console.WriteLine("3. History");
                    Console.WriteLine("4. Transfer");
                    Console.WriteLine("5. Accounts");
                    Console.WriteLine("6. Add account");
                    Console.WriteLine("7. Delete account");
                    Console.WriteLine("8. Currency conversion");
                    Console.WriteLine("9. Settings");
                    Console.WriteLine("0. Exit");
                    Console.Write("\nPlease, enter a number(0-8): ");
                    string userChoice = Console.ReadLine();
                    if (Operations.TryParse(userChoice, out Operations choice))
                    {
                        if (choice == Operations.Default) running = false;
                        SecondMenu(choice, bank);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, you should be enter a number!");
                    }
                }

            } while (running);

            Console.WriteLine("\n\tProgram has been stopped!\n");
            Console.WriteLine("==========================================\n");
            Console.ReadKey();

        }

        public static void FirstMenu(int userChoice, Bank bank)
        {
            switch (userChoice)
            {
                case 0:
                    return;
                    break;
                case 1:
                    bank.Register();
                    break;
            }
        }

        public static void SecondMenu(Operations userChoice, Bank bank)
        {
            switch(userChoice)
            {
                case 0:
                    return;
                    break;
                case Operations.DepositMoney:
                    bank.DepositMoney();
                    break;
                case Operations.WithdrawMoney:
                    bank.WithdrawMoney();
                    break;
                case Operations.History:
                    bank.ListTransactions();
                    break;
                case Operations.Transfer:
                    bank.Transfer();
                    break;
                case Operations.Accounts:
                    bank.GetAllAccounts();
                    break;
                case Operations.AddAccount:
                    bank.AddAccount();
                    break;
                case Operations.CurrencyConversion:
                    bank.CurrencyConversion();
                    break;
                case Operations.DeleteAccount:
                    bank.DeleteAccount();
                    break;
                case Operations.Settings:
                    bank.Settings();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again!(0-8)");
                    break;
            }
        }
    }
}