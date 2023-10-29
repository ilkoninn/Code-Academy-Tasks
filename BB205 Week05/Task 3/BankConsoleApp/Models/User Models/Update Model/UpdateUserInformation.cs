using BankConsoleApp.Exceptions.Bank_Exceptions;
using BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions;
using BankConsoleApp.Interfaces;
using BankConsoleApp.Models.Check_Information_Models;
using BankConsoleApp.Models.User_Models.Update_Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal static class UpdateUserInformation
    {
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
                    ChangeUserInfomation.UpdateName(user, name);
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
                    ChangeUserInfomation.UpdateSurname(user, surname);
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
                    ChangeUserInfomation.UpdateEmail(user, email);
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
                    ChangeUserInfomation.UpdatePassword(user, password);
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
                    ChangeUserInfomation.UpdatePhoneNumber(user, phoneNumber);
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
            CheckBankInformation.GetCards(user);
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
                                ChangeUserInfomation.UpdatePincode(user, userBankCard, int.Parse(pincode));
                                Console.WriteLine("\nYour bank card's pincode has been changed!\n");

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
