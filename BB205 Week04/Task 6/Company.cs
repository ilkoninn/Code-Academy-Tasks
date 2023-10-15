using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyConsoleApp
{
    internal class Company
    {
        private string _name;
        public string Name { get; set; }
        User[] users;

        public Company()
        {
            users = new User[1];
            users[0] = new User("admin1", "admin2", "admin@gmail.com", "Admin2003", "admin");

        }
        public void Register(string name, string surname, string password)
        {
            bool checkUser = true;
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Name == name &&
                    users[i].Surname == surname &&
                    users[i].Password == password)
                {
                    checkUser = false;
                    break;
                }
            }
            if (checkUser)
            {
                string usernameInput = $"{name.ToLower()}.{surname.ToLower()}";
                string emailInput = $"{name.ToLower()}.{surname.ToLower()}@gmail.com";
                User newUser = new User(name, surname, emailInput, password, usernameInput);

                Array.Resize(ref users, users.Length + 1);
                users[users.Length - 1] = newUser;

                Console.WriteLine($"\nNew user added to Data!");

                Console.WriteLine($"\n  Your default email: {emailInput}\n  Your default username: {usernameInput}");
            }
            else
            {
                Console.WriteLine("\nThere is a such user in Company!");
            }
        }
        public bool Login(string username, string password)
        {
            bool checkLogin = false;
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Username == username && users[i].Password == password)
                {
                    checkLogin = true;
                    break;
                }
            }
            
            return checkLogin;
        }
        public User[] GetAll()
        {
            return users;
        }

        public User[] GetBySearch(string username)
        {
            User[] newUsers = new User[0];

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Username.ToLower().Contains(username))
                {
                    Array.Resize(ref newUsers, newUsers.Length + 1);
                    newUsers[newUsers.Length - 1] = users[i];
                }
            }

            return newUsers;
        }

        public void UpdateByUsername(string username)
        {
            bool checkUser = false;
            User user = null;
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Username == username)
                {
                    user = users[i];
                    checkUser = true;
                    break;
                }
            }
            if (checkUser)
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("\n a. Update name\n b. Update surname\n c. Update username\n d. Update email\n" +
                        " e. Update password\n");
                    Console.Write("User choice: ");
                    string userChoice = Console.ReadLine();
                    switch (userChoice)
                    {
                        case "a":
                            Console.Write("Please, enter name for change: ");
                            string name = Console.ReadLine().Trim();
                            user.Name = name;
                            user.Username = $"{name.ToLower()}.{user.Surname.ToLower()}";
                            Console.WriteLine($"User's Name has been changed! New username: {user.Username}");
                            running = false;
                            break;
                        case "b":
                            Console.Write("Please, enter surname for change:");
                            string surname = Console.ReadLine().Trim();
                            user.Surname = surname;
                            user.Username = $"{user.Name.ToLower()}.{surname.ToLower()}";
                            Console.WriteLine($"User's Surname has been changed! New username: {user.Username}");
                            running = false;
                            break;
                        case "c":
                            Console.Write("Please, enter username for change(lower case): ");
                            string userName = Console.ReadLine();
                            user.Username = userName.Trim().ToLower();
                            Console.WriteLine("User's Userame has been changed!");
                            running = false;
                            break;
                        case "d":
                            Console.Write("Please, enter email for change(lower case): ");
                            string email = Console.ReadLine();
                            user.Email = email.Trim();
                            Console.WriteLine("User's Email has been changed!");
                            running = false;
                            break;
                        case "e":
                            PATH6:
                            Console.Write("Please, enter new password for change: ");
                            string newPassword = Console.ReadLine();
                            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");
                            if (regex.IsMatch(newPassword))
                            {
                                user.Password = newPassword;
                            }
                            else
                            {
                                Console.WriteLine("\nPassword does not meet the criteria!\nPassword must contain at least 1 number, 1 uppercase letter, 1 lowercase letter, length should not be less than 8.\n");
                                goto PATH6;
                            }
                            Console.WriteLine("\nUser's password has been changed!");

                            running = false;
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice, try again!\n");
                            running = true;
                            break;
                    }
                }
            }
            else if(username == "")
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nThere is no such a user in Company\n");
            }
        }

        public void DeleteUser(string username, string password)
        {
            bool userCheck = false;
            for (int i = 1; i < users.Length; i++)
            {
                if (users[i].Username == username &&
                    users[i].Password == password)
                {
                    userCheck = true;
                    break;
                }
            }
            if (userCheck)
            {
                User[] newUsers = new User[users.Length - 1];
                int index = 0;

                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i].Username != username)
                    {
                        newUsers[index] = users[i];
                        index++;
                    }
                }

                users = newUsers;

                Console.WriteLine("\nUser succesfully deleted!");
            }
            else if (users[0].Username == username)
            {
                Console.WriteLine("\nAdmin user can not remove from Data!");
            }
            else
            {
                Console.WriteLine("\nThere is no such a user in Company!\n\nDo you want to change user infomation?");
                Console.WriteLine("1. Change user information");
                Console.WriteLine("2. Go back to menu");
                PATH10:
                Console.Write("User choice: ");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    UpdateByUsername(username);
                }
                else if (userChoice == "2")
                {
                    UpdateByUsername("");
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again!");
                    goto PATH10;
                }
            }
        }
    }
}
