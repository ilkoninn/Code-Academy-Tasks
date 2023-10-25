using BankConsoleApp.Enums;
using BankConsoleApp.Models;
using System.ComponentModel.Design;
using System.IO.Pipes;

namespace BankConsoleApp
{
    internal class Program
    {
        internal protected static User LoggedInUser { get; set; }
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
                if(LoggedInUser == null)
                {
                    Console.WriteLine($"\n\tWelcome to {bank.Name} Bank\n");
                    Console.WriteLine("1. Sign up");
                    Console.WriteLine("2. Sign in");
                    Console.WriteLine("0. Exit");
                    Console.Write("\nPlease, enter a number(0-2): ");
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
                    Console.WriteLine($"\n\tWelcome {LoggedInUser.Name} {LoggedInUser.Surname} \n");
                    Console.WriteLine("1. Deposit money");
                    Console.WriteLine("2. Withdraw money"); 
                    Console.WriteLine("3. History");
                    Console.WriteLine("4. Transfer");
                    Console.WriteLine("5. Bank cards");
                    Console.WriteLine("6. Add bank card");
                    Console.WriteLine("7. Delete bank card");
                    Console.WriteLine("8. Currency conversion");
                    Console.WriteLine("9. Settings");
                    Console.WriteLine("10. Log out");
                    Console.WriteLine("0. Exit");
                    Console.Write("\nPlease, enter a number(0-10): ");
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
                    bank.UserRegisterSection(); 
                    //LoggedInUser = bank.UserLoginSection();
                    break;
                case 2:
                    LoggedInUser = bank.UserLoginSection();    
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, try again!\n");
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
                    LoggedInUser.DepositMoney(LoggedInUser);
                    break;
                case Operations.WithdrawMoney:
                    LoggedInUser.WithdrawMoney(LoggedInUser);
                    break;
                case Operations.History:
                    LoggedInUser.ListTransaction(LoggedInUser);                    
                    break;
                case Operations.Transfer:
                    Bank.Transfer();
                    break;
                case Operations.Cards:
                    LoggedInUser.ShowAllCards(LoggedInUser);
                    break;
                case Operations.AddCard:
                    LoggedInUser.AddCard(LoggedInUser);
                    break;
                case Operations.CurrencyConversion:
                    LoggedInUser.UserCurrencyConversion(LoggedInUser);
                    break;
                case Operations.DeleteCard:
                    LoggedInUser.DeleteCard(LoggedInUser);
                    break;
                case Operations.Settings:
                    LoggedInUser.UserSettings(LoggedInUser);
                    break;
                case Operations.Logout:
                    LoggedInUser = null;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again!(0-10)");
                    break;
            }
        }
    }
}