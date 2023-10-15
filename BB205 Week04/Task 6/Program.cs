using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Xml;

namespace CompanyConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            bool running = true;
            bool checkLogin = false;


            Console.WriteLine("============ Welcome to Company App ============\n");
            do
            {
                if (company.Name == null)
                {
                    Console.WriteLine("      ========= Create Section =========\n");
                    Console.WriteLine("\t1. Create Company");
                    Console.WriteLine("\t0. Exit");
                    Console.Write("\n\tPlease, enter a number(0-1): ");
                    string userChoice = Console.ReadLine();
                    if (int.Parse(userChoice) == 0) running = false;
                    if (int.TryParse(userChoice, out int choice))
                    {
                        FirstMenu(company, choice);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, you should be enter a number!");
                    }
                }
                else if (company.GetAll().Length == 1 && !checkLogin)
                {
                    Console.WriteLine($"\n      ============== {company.Name} ==============\n");
                    Console.WriteLine("\t1. Register");
                    Console.WriteLine("\t2. Login");
                    Console.WriteLine("\t0. Exit");
                    Console.Write("\n\tPlease, enter a number(0-2): ");
                    string userChoice = Console.ReadLine();
                    if (int.Parse(userChoice) == 0) running = false;
                    if (int.TryParse(userChoice, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                UserRegistration(company);
                                break;
                            case 2:
                                if(UserLogin(company)) checkLogin = true;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, you should be enter a number!");
                    }
                }
                else
                {
                    Console.WriteLine($"\n      ============== {company.Name} ==============\n");
                    Console.WriteLine("\t1. Register a user(to company)");
                    Console.WriteLine("\t2. Delete user from company");
                    Console.WriteLine("\t3. See all users in a company");
                    Console.WriteLine("\t4. Get users information by search bar");
                    Console.WriteLine("\t5. Get one user by username");
                    Console.WriteLine("\t6. Update user's data");
                    Console.WriteLine("\t0. Exit");
                    Console.Write("\n\tPlease, enter a number(0-6): ");
                    string userChoice = Console.ReadLine();
                    if (int.TryParse(userChoice, out int choice))
                    {
                        SecondMenu(company, choice);
                    }
                    else
                    {
                        Console.WriteLine("\tInvalid choice, you should be enter a number!");
                    }
                }

            } while (running);
            Console.WriteLine("\n\t  Program has been stopped! \n");
            Console.WriteLine("================================================");
        }
        public static void FirstMenu(Company company, int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nPlease, enter company's information:");
                    Console.Write("Company name: ");
                    company.Name = Console.ReadLine();
                    Console.WriteLine("\nNew company has been created!\n");
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("\nInvalid input!\n");
                    break;
            }
        }
        public static void SecondMenu(Company company, int choice)
        {
            switch (choice)
            {
                case 1:
                    UserRegistration(company);
                    break;
                case 2:
                    UserDelete(company);
                    break;
                case 3:
                    AllUserInfo(company);
                    break;
                case 4:
                    UserSearch(company);
                    break;
                case 5:
                    UserByUsername(company);
                    break;
                case 6:
                    UserUpdate(company);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again!");
                    break;
            }
        }
        public static void UserRegistration(Company company)
        {
            Console.WriteLine("\n\t===== User Register Section =====\n");
            Console.Write("First Name: ");
            string name = Console.ReadLine();
            Console.Write("Last Name: ");
            string surname = Console.ReadLine();
            USER:
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");
            if (regex.IsMatch(password))
            {
                company.Register(name.Trim(), surname.Trim(), password.Trim());
            }
            else
            {
                Console.WriteLine("\nPassword does not meet the criteria!\nPassword must contain at least 1 number, 1 uppercase letter, 1 lowercase letter, length should not be less than 8.\n");
                goto USER;
            }
        }
        public static bool UserLogin(Company company)
        {
            bool checkLogin = false;
            Console.WriteLine("\n\t===== User Login Section =====\n");
            PATH:
            Console.Write("\nUsername: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string userPassword = Console.ReadLine();
            if (company.Login(username, userPassword))
            {
                Console.WriteLine("\nYou are logged in!\n");
                checkLogin = true;
            }
            else
            {
                Console.WriteLine("\nUsername or password is wrong, try again!\n");
                Console.WriteLine("\nDo you want to create a user or change your user information?:");
                Console.WriteLine("\n1. Create a user");
                Console.WriteLine("2. Change user information");
                Console.WriteLine("3. Continue to login");
                Console.WriteLine("4. Go back to Menu");
                PATH1:
                Console.Write("Please, enter a number: ");
                string userChoice2 = Console.ReadLine();
                if (userChoice2 == "3") goto PATH;
                if (int.TryParse(userChoice2, out int choice2))
                {
                    UserChanges(company, choice2);
                }
                else
                {
                    Console.WriteLine("\n\tInvalid choice, you should be enter a number!\n");
                    goto PATH1;
                }
            }

            return checkLogin;
        }
        public static void AllUserInfo(Company company)
        {
            Console.WriteLine("\n============ All Users Information ============");
            Console.WriteLine("\n\tName | Surname | Email | Username\n");
            foreach (var item in company.GetAll())
            {
                Console.WriteLine($"{item.Name} | {item.Surname} | {item.Email} | {item.Username}");
            }
        }
        public static void UserSearch(Company company)
        {
            Console.WriteLine("\nPlease, enter a text for search information of users:");
            Console.Write("Your input: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("\n============ All Users according to search text ============\n");
            Console.WriteLine("\n\tName | Surname | Email | Username\n");
            foreach (var item in company.GetBySearch(userInput))
            {
                Console.WriteLine($"{item.Name} | {item.Surname} | {item.Email} | {item.Username}");
            }
        }
        public static void UserByUsername(Company company)
        {
            Console.WriteLine("\n============ User related to username ============");
            Console.Write("\nPlease, enter username for search: ");
            string username = Console.ReadLine();
            if(company.GetByUsername(username) != null)
            {
                Console.WriteLine("\n\tName | Surname | Email | Username\n");
                Console.WriteLine($"{company.GetByUsername(username).Name} | {company.GetByUsername(username).Surname} | {company.GetByUsername(username).Email} | {company.GetByUsername(username).Username}");
            }
            else
            {
                Console.WriteLine("\nThere is no such a user in Company!");
            }

        }
        public static void UserUpdate(Company company)
        {
            Console.WriteLine("\nPlease, enter a choice and username for update his/her information:");
            Console.Write("Username: ");
            string userInput2 = Console.ReadLine();
            company.UpdateByUsername(userInput2);
        }
        public static void UserDelete(Company company) 
        {
            Console.WriteLine("Please, enter a username and password for delete his/her information:");
            Console.Write("Username: ");
            string userInput3 = Console.ReadLine();
            Console.Write("Password: ");
            string userInput4 = Console.ReadLine();
            company.DeleteUser(userInput3, userInput4);
        }
        public static void UserChanges(Company company, int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    UserRegistration(company);
                    break;
                case 2:
                    UserUpdate(company);
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;

            }
        }
    }
}
