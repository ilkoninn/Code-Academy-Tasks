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
        public static void UpdateName(User user)
        {
        PATH1:
            Console.WriteLine($"\nYour name: {user.Name}");
            Console.Write("Please, enter your new name: ");
            string name = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckName(name))
                {
                    user.Name = name;
                    Console.WriteLine("Your name has been changed!");
                }
                else
                {
                    throw new InvalidNameException();
                }
            }
            catch (InvalidNameException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH1;
                }
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH1;
                }
                return;
            }
        }
        public static void UpdateSurname(User user)
        {
        PATH2:
            Console.WriteLine($"\nYour surname: {user.Surname}");
            Console.Write("Please, enter your new surname: ");
            string surname = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckSurname(surname))
                {
                    user.Surname = surname;
                    Console.WriteLine("Your surname has been changed!");

                }
                else
                {
                    throw new InvalidSurnameException();
                }
            }
            catch (InvalidSurnameException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH2;
                }
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH2;
                }
                return;
            }
        }
        public static void UpdateEmail(User user)
        {
        PATH4:
            Console.WriteLine($"\nYour email: {user.Email}");
            Console.Write("Please, enter your new email: ");
            string email = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckEmail(email))
                {
                    user.Email = email;
                    Console.WriteLine("Your email has been changed!");

                }
                else
                {
                    throw new InvalidEmailException();
                }
            }
            catch (InvalidEmailException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH4;
                }
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH4;
                }
                return;
            }
        }
        public static void UpdatePassword(User user)
        {
        PATH5:
            Console.Write("Please, enter your new password: ");
            string password = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckPassword(password))
                {
                    user.Password = password;
                    Console.WriteLine("Your password has been changed!");

                }
                else
                {
                    throw new InvalidPasswordException();
                }
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH5;
                }
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH5;
                }
                return;
            }
        }
        public static void UpdatePhoneNumber(User user)
        {
        PATH3:
            Console.WriteLine($"\nYour phone number: {user.PhoneNumber}");
            Console.Write("Please, enter your new phone number(+994-XX-XXX-XX-XX): ");
            string phoneNumber = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckPhoneNumber(phoneNumber))
                {
                    user.PhoneNumber = phoneNumber;
                    Console.WriteLine("Your phone number has been changed!");

                }
                else
                {
                    throw new InvalidPhoneNumberException();
                }
            }
            catch (InvalidPhoneNumberException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH3;
                }
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH3;
                }
                return;
            }
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
                BankCard userBankCard = CheckBankInformation.GetBankCard(user, choice2);
                try
                {
                    if (userBankCard != null)
                    {
                    PATH6:
                        Console.Write("Please, enter your new pincode: ");
                        string pincode = Console.ReadLine().Trim();
                        try
                        {
                            if (CheckUserInformation.CheckPincode(pincode))
                            {
                                userBankCard.Pincode = int.Parse(pincode);
                            }
                            else
                            {
                                throw new InvalidPincodeException();
                            }
                        }
                        catch (InvalidPincodeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH6;
                            }
                            return;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n" + ex.Message);
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH6;
                            }
                            return;
                        }
                    }
                    else
                    {
                        throw new BankCardNotFoundException();
                    }
                }
                catch (BankCardNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
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
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
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
