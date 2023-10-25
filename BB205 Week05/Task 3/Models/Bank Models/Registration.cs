using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
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
            string name = UserSectionName();
            if (name == "") return;
            string surname = UserSectionSurname();
            if(surname == "") return;
            string phoneNumber = UserSectionPhoneNumber();
            if (phoneNumber == "") return;
            string email = EmailSection();
            if (email == "") return;
            string password = PasswordSection();
            if (password == "") return;
            int pincode = PincodeSection();
            if (pincode == 0) return;
            AccountType accountType = AccountTypeSection();
            if(accountType == AccountType.Default) return;
            CurrencyType currencyType = CurrencyTypeSection();
            if(currencyType == CurrencyType.Default) return;

            RegisterUserSection(
                name, surname, phoneNumber, email, password, 
                pincode, accountType, currencyType
            );
            
        }
        public static string UserSectionName()
        {
            // User information section
            PATH6:
            Console.Write("Name: ");
            string name = Console.ReadLine().Trim();

            if (!(name.Length >= 3))
            {
                Console.WriteLine("\nName does not meet to criteria, length of name greater and equel than 3, try again! (Ex: Ilkin)\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH6;
                }
                return "";
            }

            return name;
        }
        public static string UserSectionSurname()
        {
            // User information section
            PATH7:
            Console.Write("Surname: ");
            string surname = Console.ReadLine().Trim();

            if (!(surname.Length >= 3))
            {
                Console.WriteLine("\nSurname does not meet to criteria, length of surname greater and equel than 3, try again! (Ex: Ilkin)\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH7;
                }
                return "";
            }

            return surname;
        }
        public static string UserSectionPhoneNumber()
        {
            // User information section
            PATH8:
            Console.Write("Phone number(+994-XX-XXX-XX-XX): ");
            string phoneNumber = Console.ReadLine().Trim();

            if (!(phoneNumber.Length <= 12 && phoneNumber.Length >= 9))
            {
                Console.WriteLine("\nSurname does not meet to criteria, length of surname greater and equel than 3, try again! (Ex: Ilkin)\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH8;
                }
                return "";
            }

            return phoneNumber;
        }
        public static string EmailSection()
        {
            // Email section
            PATH1:
            Console.Write("Email: ");
            string email = Console.ReadLine().Trim();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!regex.IsMatch(email))
            {
                Console.WriteLine("\nEmail does not meet to criteria, try again! (Ex: something@someth.ing)\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH1;
                }
                return "";
            }

            return email;
        }
        public static string PasswordSection()
        {
            // Password section
            PATH2:
            Console.Write("Password: ");
            string password = Console.ReadLine().Trim();
            Regex regex2 = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");

            if (!regex2.IsMatch(password))
            {
                Console.WriteLine("\nPassword does not meet the criteria!\nPassword must contain at least 1 number, 1 uppercase letter, 1 lowercase letter, length should not be less than 8.\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH2;
                }
                return "";
            }

            return password;
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
            int userPincode;

            if (pincode.Length == 4 && int.TryParse(pincode, out int newPincode))
            {
                userPincode = newPincode;
                return userPincode;
            }
            else
            {
                Console.WriteLine("\nPincode length must be equel to 4 and all input contains from numbers!\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH3;
                }
            }

            return 0;
        }
        public static void RegisterUserSection(string name, string surname, string phoneNumber, string email, string password, int newPincode, AccountType userAccountType, CurrencyType userCurrencyType)
        {
            Random random = new Random();

            string cardNumber = $"4050 6070 {random.Next(1000, 9999)} {random.Next(1000, 9999)}";
            DateTime expirationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            string formattedDate = expirationDate.ToString("MM/yy");
            int cvv = random.Next(100, 999);

            User newUser = new User(name, surname, email, password, phoneNumber);
            BankCard bankCard = new BankCard(newPincode, cardNumber, expirationDate, cvv, userAccountType, userCurrencyType);

            newUser.bankCards.Add(bankCard);
            Bank.UserAccounts.Add(newUser);


            Console.WriteLine($"\n\tYour new card information\n");
            Console.WriteLine($"Card number: {cardNumber}");
            Console.WriteLine($"Card expiration date: {formattedDate}");
            Console.WriteLine($"Card number: {cvv}");
        }
    }
}
