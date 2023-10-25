using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal class AddBankCard
    {
        public static void AddCard(User user)
        {
            Console.WriteLine("\n\tAdd new account section\n");
            AddAllInformation(user, AddAccountType(), AddCurrencyType(), AddPincode(user));
            
        }
        public static AccountType AddAccountType()
        {
            PATH9:
            Console.WriteLine("\n\tAccount type\n");
            Console.WriteLine("1. Checking"); // 2000 Max
            Console.WriteLine("2. Savings"); // 20000 Max
            Console.WriteLine("3. Business"); // 200000 Max
            Console.Write("\nEnter your choice(1-3): ");
            string accountType = Console.ReadLine();
            AccountType userAccountType = AccountType.Default;

            if (accountType == "1" || accountType == "2" || accountType == "3")
            {
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
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, try again!\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH9;
                }
            }

            return userAccountType;
        }
        public static CurrencyType AddCurrencyType()
        {
            PATH10:
            Console.WriteLine("\n\tCurrency type\n");
            Console.WriteLine("1. AZN");
            Console.WriteLine("2. USD");
            Console.WriteLine("3. EUR");
            Console.Write("\nEnter your choice(1-3): ");
            string currencyType = Console.ReadLine();
            CurrencyType userCurrencyType = CurrencyType.Default;

            if (currencyType == "1" || currencyType == "2" || currencyType == "3")
            {
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
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, try again!\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH10;
                }
            }

            return userCurrencyType;
        }
        public static int AddPincode(User user)
        {
            PATH11:
            Console.Write("\nPincode(Ex: 0000): ");
            string pincode = Console.ReadLine().Trim();

            if (pincode.Length == 4 && int.TryParse(pincode, out int newPincode))
            {
                bool checkPincode = true;

                for (int i = 0; i < user.bankCards.Count; i++)
                {
                    if (user.bankCards[i].Pincode == newPincode)
                    {
                        checkPincode = false;
                        break;
                    }
                }
                if (checkPincode)
                {
                    return newPincode;
                }
                else
                {
                    Console.WriteLine("\nThis pincode used before, try another pincode!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH11;
                    }
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("\nPincode length must be equel to 4 and all input contains from numbers!\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH11;
                }
                return 0;
            }
        }
        public static void AddAllInformation(User user, AccountType accountType, CurrencyType currencyType, int pincode)
        {
            Random random = new Random();

            string cardNumber = $"4050 6070 {random.Next(1000, 9999)} {random.Next(1000, 9999)}";
            DateTime expirationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            string formattedDate = expirationDate.ToString("MM/yy");
            int cvv = random.Next(100, 999);

            BankCard bankCard = new BankCard(pincode, cardNumber, expirationDate, cvv, accountType, currencyType);
            user.bankCards.Add(bankCard);

            Console.WriteLine($"\n\tYour new card information\n");
            Console.WriteLine($"Card number: {cardNumber}");
            Console.WriteLine($"Card expiration date: {formattedDate}");
            Console.WriteLine($"Card number: {cvv}");
        }
    }
}
