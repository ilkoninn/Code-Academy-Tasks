using System.Text.RegularExpressions;

namespace CompanyConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            bool running = true;

            Console.WriteLine("============ Welcome to Company App ============\n");
            do
            {
                if (company.Name == null)
                {
                    Console.WriteLine("\t======= Create Section =======\n");
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
                else
                {
                    Console.WriteLine($"\n      ============== {company.Name} ==============\n");
                    Console.WriteLine("\t1. Register a user(to company");
                    Console.WriteLine("\t2. Login a user(to company)");
                    Console.WriteLine("\t3. See all users in a company(GetAll)");
                    Console.WriteLine("\t4. Get users information with search text");
                    Console.WriteLine("\t5. Update user's data(UpdateByUsername)");
                    Console.WriteLine("\t6. Delete user from company(DeleteByUsername)\n" +
                        "\t0. Exit");
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
                    UserLogin(company);
                    break;
                case 3:
                    AllUserInfo(company);
                    break;
                case 4:
                    UserSearch(company);
                    break;
                case 5:
                    UserUpdate(company);
                    break;
                case 6:
                    UserDelete(company);
                    break;
                case 7:
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

        public static void UserLogin(Company company)
        {
            Console.WriteLine("\n\t===== User Login Section =====\n");
            PATH:
            Console.Write("\nUsername: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string userPassword = Console.ReadLine();
            if (company.Login(username, userPassword))
            {
                Console.WriteLine("\nYou are logged in!\n");
            }
            else
            {
                Console.WriteLine("\nUsername or password is wrong, try again!\n");
                Console.WriteLine("\nDo you want to create a user or change your user information?:");
                Console.WriteLine("1. Create a user");
                Console.WriteLine("2. Change user information");
                Console.WriteLine("3. Continue to login");
                Console.WriteLine("4. Go back to Menu");
                Console.Write("Please, enter a number: ");
                string userChoice2 = Console.ReadLine();
                if (userChoice2 == "3") goto PATH;
                if (int.TryParse(userChoice2, out int choice2))
                {
                    UserChanges(company, choice2);
                }
                else
                {
                    Console.WriteLine("\tInvalid choice, you should be enter a number!");
                }

            }
        }
        public static void AllUserInfo(Company company)
        {
            Console.WriteLine("\n============ All Users Information ============\n");
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
            foreach (var item in company.GetByUsername(userInput))
            {
                Console.WriteLine($"{item.Name} | {item.Surname} | {item.Email} | {item.Username}");
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
            Console.WriteLine("Please, enter a username for delete his/her information:");
            Console.Write("Username: ");
            string userInput3 = Console.ReadLine();
            company.DeleteByUsername(userInput3);
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