using BankConsoleApp.Enums;
using BankConsoleApp.Exceptions.Registartion_Exceptions;
using BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions;
using BankConsoleApp.Interfaces;
using BankConsoleApp.Models.Check_Information_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankConsoleApp.Models.Bank_Models
{
    internal class Registration
    {
        public static void Register()
        {
            Console.WriteLine("\n\tRegistration section\n");
            Console.WriteLine("User information:\n");
            string name = UserSectionName();
            if (name == "") return;
            string surname = UserSectionSurname();
            if(surname == "") return;
            byte age = UserSectionAge();
            if (age == 0) return;
            string phoneNumber = UserSectionPhoneNumber();
            if (phoneNumber == "") return;
            string email = EmailSection();
            if (email == "") return;
            string password = PasswordSection();
            Console.WriteLine("\nUser bank card information:");
            if (password == "") return;
            int pincode = PincodeSection();
            if (pincode == 0) return;
            AccountType accountType = AccountTypeSection();
            if(accountType == AccountType.Default) return;
            CurrencyType currencyType = CurrencyTypeSection();
            if(currencyType == CurrencyType.Default) return;

            RegisterUserSection(
                name, surname, age, phoneNumber, email, password, 
                pincode, accountType, currencyType
            );
            
        }
        public static string UserSectionName()
        {
            // User information section
            PATH6:
            Console.Write("Name: ");
            string name = Console.ReadLine().Trim();

            try
            {
                if (CheckUserInformation.CheckName(name))
                {
                    return name;
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
                    goto PATH6;
                }
                return "";
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
                return "";
            }
        }
        public static string UserSectionSurname()
        {
            // User information section
            PATH7:
            Console.Write("Surname: ");
            string surname = Console.ReadLine().Trim();

            try
            {
                if (CheckUserInformation.CheckSurname(surname))
                {
                    return surname;
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
                    goto PATH7;
                }
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH7;
                }
                return "";
            }
        }
        public static byte UserSectionAge()
        {
            // User information section
            PATH9:
            Console.Write("Age: ");
            string age = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckAge(age))
                {
                    return byte.Parse(age);
                }
                else
                {
                    throw new InvalidAgeException();
                }
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                return 0;
            }
        }
        public static string UserSectionPhoneNumber()
        {
            // User information section
            PATH8:
            Console.Write("Phone number(+994-XX-XXX-XX-XX): ");
            string phoneNumber = Console.ReadLine().Trim();

            try
            {
                if (CheckUserInformation.CheckPhoneNumber(phoneNumber))
                {
                    return phoneNumber;
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
                    goto PATH8;
                }
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH8;
                }
                return "";
            }
        }
        public static string EmailSection()
        {
            // Email section
            PATH1:
            Console.Write("Email: ");
            string email = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckEmail(email))
                {
                    return email;
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
                    goto PATH1;
                }
                return "";
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
                return "";
            }

        }
        public static string PasswordSection()
        {
            // Password section
            PATH2:
            Console.Write("Password: ");
            string password = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckPassword(password))
                {
                    return password;
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
                    goto PATH2;
                }
                return "";
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
                return "";
            }
        }
        public static AccountType AccountTypeSection()
        {
            // Account type section
            PATH5:
            Console.WriteLine("\n\tAccount type\n");
            Console.WriteLine("1. Checking"); // 2000 Max
            Console.WriteLine("2. Savings"); // 20000 Max
            Console.WriteLine("3. Business"); // 200000 Max
            Console.Write("\nEnter your choice(1-3): ");
            string accountType = Console.ReadLine();
            AccountType userAccountType = AccountType.Default;
            switch (accountType)
            {
                case "1":
                    userAccountType = AccountType.Checking;
                    break;
                case "2":
                    userAccountType = AccountType.Savings;
                    break;
                case "3":
                    userAccountType = AccountType.Business;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again!");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH5;
                    }
                    return AccountType.Default;
                    break;

            }

            return userAccountType;
        }
        public static CurrencyType CurrencyTypeSection()
        {
            // Currency type section
            PATH6:
            Console.WriteLine("\n\tCurrency type\n");
            Console.WriteLine("1. AZN");
            Console.WriteLine("2. USD");
            Console.WriteLine("3. EUR");
            Console.Write("\nEnter your choice(1-3): ");
            string currencyType = Console.ReadLine();
            CurrencyType userCurrencyType = CurrencyType.Default;
            switch (currencyType)
            {
                case "1":
                    userCurrencyType = CurrencyType.AZN;
                    break;
                case "2":
                    userCurrencyType = CurrencyType.USD;
                    break;
                case "3":
                    userCurrencyType = CurrencyType.EUR;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again!");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH6;
                    }
                    return CurrencyType.Default;
                    break;
            }

            return userCurrencyType;
        }
        public static int PincodeSection()
        {
            // Pincode section
            PATH3:
            Console.Write("\nPincode(Ex: 0000): ");
            string pincode = Console.ReadLine().Trim();
            try
            {
                if (CheckUserInformation.CheckPincode(pincode))
                {
                    return int.Parse(pincode);
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
                    goto PATH3;
                }
                return 0;
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
                return 0;
            }

        }
        public static void RegisterUserSection(string name, string surname, byte age, string phoneNumber, string email, string password, int newPincode, AccountType userAccountType, CurrencyType userCurrencyType)
        {
            Random random = new Random();

            string cardNumber = $"4050 6070 {random.Next(1000, 9999)} {random.Next(1000, 9999)}";
            DateTime expirationDate = new DateTime(DateTime.Now.Year + 3, DateTime.Now.Month, 1);
            string formattedDate = expirationDate.ToString("MM/yy");
            int cvv = random.Next(100, 999);

            User newUser = new User(name, surname, age, email, password, phoneNumber);
            BankCard bankCard = new BankCard(newPincode, cardNumber, expirationDate, cvv, userAccountType, userCurrencyType);

            GetAndPutJSONData(newUser, bankCard, cardNumber, formattedDate, cvv);

            
        }
        public static void GetAndPutJSONData(User user, BankCard bankCard, string cardNumber, string formattedDate, int cvv)
        {
            bool checkUser = false;
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);
            
            for (int i = 0; i < deserializeJson.Count; i++)
            {
                if (deserializeJson[i].Email == user.Email &&
                    deserializeJson[i].Password == user.Password)
                {
                    checkUser = true;
                    break;
                }
            }

            if (checkUser)
            {
                Console.WriteLine("\nThere is a such user in Bank!(Email and password used before), try to login your account");
            }
            else
            {
                user.bankCards.Add(bankCard);
                deserializeJson.Add(user);

                var serializeJson = JsonConvert.SerializeObject(deserializeJson);

                using (StreamWriter sw = new StreamWriter(userJSONPath))
                {
                    sw.WriteLine(serializeJson);
                }

                Console.WriteLine("\nYour new account successfully created, please log in!");
                Console.WriteLine($"\n\tYour new card information\n");
                Console.WriteLine($"Card number: {cardNumber}");
                Console.WriteLine($"Card expiration date: {formattedDate}");
                Console.WriteLine($"Card number: {cvv}");
            }
        }
    }
}
