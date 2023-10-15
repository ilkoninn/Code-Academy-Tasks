using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
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
            users = new User[0];
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

        public User[] GetByUsername(string username)
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
                    Console.WriteLine("\n a. Update name\r\n b. Update surname\r\n c. Update username\r\n d. Update email\n");
                    Console.Write("User choice: ");
                    string userChoice = Console.ReadLine();
                    switch (userChoice)
                    {
                        case "a":
                            Console.Write("Please, enter name for change: ");
                            string name = Console.ReadLine();
                            user.Name = name.Trim();
                            user.Username = $"{name}.{user.Surname}";
                            Console.WriteLine($"User's Name has been changed! New username: {user.Username}");
                            running = false;
                            break;
                        case "b":
                            Console.Write("Please, enter surname for change:");
                            string surname = Console.ReadLine();
                            user.Surname = surname.Trim();
                            user.Username = $"{user.Name}.{surname}";
                            Console.WriteLine($"User's Surname has been changed! New username: {user.Username}");
                            running = false;
                            break;
                        case "c":
                            Console.Write("Please, enter username for change: ");
                            string userName = Console.ReadLine();
                            user.Username = userName.Trim();
                            Console.WriteLine("User's Userame has been changed!");
                            running = false;
                            break;
                        case "d":
                            Console.Write("Please, enter email for change: ");
                            string email = Console.ReadLine();
                            user.Email = email.Trim();
                            Console.WriteLine("User's Email has been changed!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice, try again!\n");
                            running = true;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nThere is no such a user in Company\n");
            }
        }

        public void DeleteByUsername(string username)
        {
            bool userCheck = false;
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Username == username)
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
            else
            {
                Console.WriteLine("\nThere is no such a user in Company!");
            }
        }
    }
}
