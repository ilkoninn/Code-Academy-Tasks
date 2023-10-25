using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal class Settings
    {
        public static void UserSettings(User user)
        {
            PATH2:
            Console.WriteLine("\n\tSettings section\n");
            Console.WriteLine("1. Update name");
            Console.WriteLine("2. Update surname");
            Console.WriteLine("3. Update email");
            Console.WriteLine("4. Update password");
            Console.WriteLine("5. Update phone number");
            Console.WriteLine("6. Update pincode");
            Console.WriteLine("0. Exit");
            Console.Write("User choice(0-6): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                if (choice <= 8)
                {
                    switch (choice)
                    {
                        case 1:
                            UpdateName(user);
                            break;
                        case 2:
                            UpdateSurname(user);
                            break;
                        case 3:
                            UpdateEmail(user);
                            break;
                        case 4:
                            UpdatePassword(user);
                            break;
                        case 5:
                            UpdatePhoneNumber(user);
                            break;
                        case 6:
                            UpdateCardPincode(user);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH2;
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
                    goto PATH2;
                }
            }

        }

        public static void UpdateName(User user)
        {
            Console.WriteLine($"\nYour name: {user.Name}");
            Console.Write("Please, enter your new name: ");
            string name = Console.ReadLine().Trim();
            user.Name = name;
            Console.WriteLine("Your name has been changed!");
        }
        public static void UpdateSurname(User user)
        {
            Console.WriteLine($"\nYour surname: {user.Surname}");
            Console.Write("Please, enter your new surname: ");
            string surname = Console.ReadLine().Trim();
            user.Surname = surname;
            Console.WriteLine("Your surname has been changed!");
        }
        public static void UpdateEmail(User user)
        {
            PATH3:
            Console.WriteLine($"\nYour email: {user.Email}");
            Console.Write("Please, enter your new email: ");
            string email = Console.ReadLine().Trim();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!regex.IsMatch(email))
            {
                Console.WriteLine("\nEmail does not meet to criteria, try again! (Ex: something@someth.ing)\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH3;
                }
                else
                {
                    return;
                }
            }

            user.Email = email;
            Console.WriteLine("Your email has been changed!");
        }
        public static void UpdatePassword(User user)
        {
            PATH4:
            Console.Write("Please, enter your new password: ");
            string password = Console.ReadLine().Trim();
            Regex regex2 = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");

            if (!regex2.IsMatch(password))
            {
                Console.WriteLine("\nPassword does not meet the criteria!\nPassword must contain at least 1 number, 1 uppercase letter, 1 lowercase letter, length should not be less than 8.\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH4;
                }
                else
                {
                    return;
                }
            }

            user.Password = password;
            Console.WriteLine("Your password has been changed!");
        }
        public static void UpdatePhoneNumber(User user)
        {
            Console.WriteLine($"\nYour phone number: {user.PhoneNumber}");
            Console.Write("Please, enter your new phone number(+994-XX-XXX-XX-XX): ");
            string phoneNumber = Console.ReadLine().Trim();
            user.PhoneNumber = phoneNumber;
            Console.WriteLine("Your phone number has been changed!");
        }
        public static void UpdateCardPincode(User user)
        {
        PATH5:
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
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice2 = Console.ReadLine();
            if (userChoice2 == "0") return;
            if (int.TryParse(userChoice2, out int choice2))
            {
                if (choice2 <= count)
                {
                    BankCard newBankCard = null;
                    for (int i = 0; i < user.bankCards.Count; i++)
                    {
                        if (choice2 == i + 1)
                        {
                            newBankCard = user.bankCards[i];
                            break;
                        }
                    }
                    Console.Write("Please, enter your new pincode: ");
                    string pincode = Console.ReadLine().Trim();
                    if (pincode.Length == 4 && int.TryParse(pincode, out int newPincode))
                    {
                        newBankCard.Pincode = newPincode;
                        Console.WriteLine("Your pincode has been changed!");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice, try again!\n");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH5;
                        }
                        else
                        {
                            return;
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
                        goto PATH5;
                    }
                    else
                    {
                        return;
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
                    goto PATH5;
                }
                else
                {
                    return;
                }
            }

        }

    }
}
