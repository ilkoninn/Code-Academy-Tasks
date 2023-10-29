using BankConsoleApp.Exceptions;
using BankConsoleApp.Exceptions.Bank_Exceptions;
using BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions;
using BankConsoleApp.Models.Check_Information_Models;
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
                if (choice <= 6)
                {
                    switch (choice)
                    {
                        case 1:
                            UpdateUserInformation.UpdateName(user);
                            break;
                        case 2:
                            UpdateUserInformation.UpdateSurname(user);
                            break;
                        case 3:
                            UpdateUserInformation.UpdateEmail(user);
                            break;
                        case 4:
                            UpdateUserInformation.UpdatePassword(user);
                            break;
                        case 5:
                            UpdateUserInformation.UpdatePhoneNumber(user);
                            break;
                        case 6:
                            UpdateUserInformation.UpdateCardPincode(user);
                            break;
                    }
                    goto PATH2;
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
    }
}
