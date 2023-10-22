using BankConsoleApp.Enums;
using BankConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankConsoleApp.Models
{
    internal class Bank
    {
        public string Name { get; set; }
        public bool RunCheck = false;
        private BankAccount[] bankAccounts = new BankAccount[0];

        public Bank(string name)
        {
            Name = name;
        }
        public void Register()
        {
            Console.WriteLine("\n\tRegistration section\n");
            // User information section
            Console.Write("Name: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Surname: ");
            string surname = Console.ReadLine().Trim();
            Console.Write("Phone number(+994-XX-XXX-XX-XX): ");
            string phoneNumber = Console.ReadLine().Trim();

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
                else
                {
                    return;
                }
            }

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
                else
                {
                    return;
                }
            }


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
                    else
                    {
                        return;
                    }
                    break;

            }

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
                    else
                    {
                        return;
                    }
                    break;

            }
        // Pincode section
        PATH3:
            Console.Write("\nPincode(Ex: 0000): ");
            string pincode = Console.ReadLine().Trim();

            if (pincode.Length == 4 && int.TryParse(pincode, out int newPincode))
            {
                Random random = new Random();

                string cardNumber = $"4050 6070 {random.Next(1000, 9999)} {random.Next(1000, 9999)}";
                DateTime expirationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                string formattedDate = expirationDate.ToString("MM/yy");
                int cvv = random.Next(100, 999);

                BankAccount bankAccount = new BankAccount(name, surname, phoneNumber, email, password, newPincode, cardNumber, expirationDate, cvv, userAccountType, userCurrencyType);

                Array.Resize(ref bankAccounts, bankAccounts.Length + 1);
                bankAccounts[bankAccounts.Length - 1] = bankAccount;

                Console.WriteLine($"\n\tYour new card information\n");
                Console.WriteLine($"Card number: {cardNumber}");
                Console.WriteLine($"Card expiration date: {formattedDate}");
                Console.WriteLine($"Card number: {cvv}");

                RunCheck = true;
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
                else
                {
                    return;
                }
            }

        }

        public void GetAllAccounts()
        {
            Console.WriteLine("\n\tYour accounts\n");
            Console.WriteLine("Card Number | Card CVV | Card expiration date\n");

            int count = 0;
            foreach (var item in bankAccounts)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
                Console.WriteLine($"Card balance(AZN): {item.BalanceAZN}");
                Console.WriteLine($"Card balance(USD): {item.BalanceUSD}");
                Console.WriteLine($"Card balance(EUR): {item.BalanceEUR}");
                Console.WriteLine($"Account type: {item.AccountType}");
                Console.WriteLine($"Currency type: {item.CurrencyType}");
                Console.WriteLine();
            }

        }

        public void DepositMoney()
        {
            Console.WriteLine("\n\tDeposit Money section\n");
            Console.WriteLine("Please, choose a card: ");
            Console.WriteLine("\nCard Number | Card CVV | Card expiration date\n");
            int count = 0;
            foreach (var item in bankAccounts)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
            }
            Console.WriteLine("0. Exit");
        PATH7:
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                if (choice <= count)
                {
                    BankAccount newBankAccount = null;
                    for (int i = 0; i < bankAccounts.Length; i++)
                    {
                        if (choice == i + 1)
                        {
                            newBankAccount = bankAccounts[i];
                            break;
                        }
                    }
                PATH25:
                    Console.WriteLine("\nWhich kind of currency type you want to be deposit?");
                    Console.WriteLine("1. AZN");
                    Console.WriteLine("2. USD");
                    Console.WriteLine("3. EUR");
                    Console.Write("User choice(1-3): ");
                    string userChoice3 = Console.ReadLine();
                    if (userChoice3 == "1" || userChoice3 == "2" || userChoice3 == "3")
                    {
                        if (Enums.CurrencyType.TryParse(userChoice3, out Enums.CurrencyType currencyType))
                        {

                        PATH8:
                            Console.WriteLine("\nWhich balance type do you want to be deposit?");
                            Console.WriteLine("1. AZN Balance");
                            Console.WriteLine("2. USD Balance");
                            Console.WriteLine("3. EUR Balance");
                            Console.Write("User choice(1-3): ");
                            string userChoice4 = Console.ReadLine();
                            if (userChoice4 == "1" || userChoice4 == "2" || userChoice4 == "3")
                            {
                                if (int.TryParse(userChoice4, out int choice2))
                                {
                                    switch (choice2)
                                    {
                                        case 0:
                                            return;
                                            break;
                                        case 1:
                                            switch (currencyType)
                                            {
                                                case CurrencyType.Default:
                                                    return;
                                                    break;
                                                case CurrencyType.AZN:
                                                    Console.Write("Money value: ");
                                                    string amount = Console.ReadLine();
                                                    if (decimal.TryParse(amount, out decimal newAmount))
                                                    {
                                                        newBankAccount.DepositAZN(newAmount);
                                                        DateTime dateTime = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount, dateTime, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.USD:
                                                    Console.Write("Money value: ");
                                                    string amount3 = Console.ReadLine();
                                                    if (decimal.TryParse(amount3, out decimal newAmount3))
                                                    {
                                                        newBankAccount.DepositAZN(newAmount3 * (decimal)1.7);
                                                        DateTime dateTime2 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount3 * (decimal)1.7, dateTime2, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo3 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo3 == "yes" || yesOrNo3 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.EUR:
                                                    Console.Write("Money value: ");
                                                    string amount4 = Console.ReadLine();
                                                    if (decimal.TryParse(amount4, out decimal newAmount4))
                                                    {
                                                        newBankAccount.DepositAZN(newAmount4 * (decimal)1.8);
                                                        DateTime dateTime3 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount4 * (decimal)1.8, dateTime3, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo4 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo4 == "yes" || yesOrNo4 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInvalid choice, try again!\n");
                                                    goto PATH8;
                                                    break;
                                            }
                                            break;
                                        case 2:
                                            switch (currencyType)
                                            {
                                                case CurrencyType.Default:
                                                    return;
                                                    break;
                                                case CurrencyType.AZN:
                                                    Console.Write("Money value: ");
                                                    string amount = Console.ReadLine();
                                                    if (decimal.TryParse(amount, out decimal newAmount))
                                                    {
                                                        newBankAccount.DepositUSD(newAmount * (decimal)0.59);
                                                        DateTime dateTime = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount * (decimal)0.59, dateTime, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo5 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo5 == "yes" || yesOrNo5 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.USD:
                                                    Console.Write("Money value: ");
                                                    string amount3 = Console.ReadLine();
                                                    if (decimal.TryParse(amount3, out decimal newAmount3))
                                                    {
                                                        newBankAccount.DepositUSD(newAmount3);
                                                        DateTime dateTime2 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount3, dateTime2, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo6 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo6 == "yes" || yesOrNo6 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.EUR:
                                                    Console.Write("Money value: ");
                                                    string amount4 = Console.ReadLine();
                                                    if (decimal.TryParse(amount4, out decimal newAmount4))
                                                    {
                                                        newBankAccount.DepositUSD(newAmount4 * (decimal)1.06);
                                                        DateTime dateTime3 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount4 * (decimal)1.06, dateTime3, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo7 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo7 == "yes" || yesOrNo7 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInvalid choice, try again!\n");
                                                    goto PATH8;
                                                    break;
                                            }
                                            break;
                                        case 3:
                                            switch (currencyType)
                                            {
                                                case CurrencyType.Default:
                                                    return;
                                                    break;
                                                case CurrencyType.AZN:
                                                    Console.Write("Money value: ");
                                                    string amount = Console.ReadLine();
                                                    if (decimal.TryParse(amount, out decimal newAmount))
                                                    {
                                                        newBankAccount.DepositEUR(newAmount * (decimal)0.55);
                                                        DateTime dateTime = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount * (decimal)0.55, dateTime, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo8 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo8 == "yes" || yesOrNo8 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.USD:
                                                    Console.Write("Money value: ");
                                                    string amount3 = Console.ReadLine();
                                                    if (decimal.TryParse(amount3, out decimal newAmount3))
                                                    {
                                                        newBankAccount.DepositEUR(newAmount3 * (decimal)0.94);
                                                        DateTime dateTime2 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount3 * (decimal)0.94, dateTime2, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo9 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo9 == "yes" || yesOrNo9 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.EUR:
                                                    Console.Write("Money value: ");
                                                    string amount4 = Console.ReadLine();
                                                    if (decimal.TryParse(amount4, out decimal newAmount4))
                                                    {
                                                        newBankAccount.DepositEUR(newAmount4);
                                                        DateTime dateTime3 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount4, dateTime3, Enums.Operations.DepositMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo10 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo10 == "yes" || yesOrNo10 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInvalid choice, try again!\n");
                                                    goto PATH8;
                                                    break;
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Invalid choice, try again!");
                                            Console.Write("Continue?(Y/N): ");
                                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                                            if (yesOrNo == "yes" || yesOrNo == "y")
                                            {
                                                goto PATH8;
                                            }
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
                                        goto PATH25;
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
                                    goto PATH25;
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
                                goto PATH25;
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
                            goto PATH25;
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
                        goto PATH7;
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
                    goto PATH7;
                }
            }
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("\n\tWithdraw Money section\n");
            Console.WriteLine("Please, choose a card: ");
            Console.WriteLine("\nCard Number | Card CVV | Card expiration date\n");
            int count = 0;
            foreach (var item in bankAccounts)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
            }
            Console.WriteLine("0. Exit");
        PATH11:
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                if (choice <= count)
                {
                    BankAccount newBankAccount = null;
                    for (int i = 0; i < bankAccounts.Length; i++)
                    {
                        if (choice == i + 1)
                        {
                            newBankAccount = bankAccounts[i];
                            break;
                        }
                    }
                PATH26:
                    Console.WriteLine("\nWhich kind of currency type you want to be withdraw?");
                    Console.WriteLine("1. AZN");
                    Console.WriteLine("2. USD");
                    Console.WriteLine("3. EUR");
                    Console.Write("User choice(1-3): ");
                    string userChoice3 = Console.ReadLine();
                    if (userChoice3 == "1" || userChoice3 == "2" || userChoice3 == "3")
                    {
                        if (Enums.CurrencyType.TryParse(userChoice3, out Enums.CurrencyType currencyType))
                        {
                        PATH8:
                            Console.WriteLine("Which balance type do you want to be deposit?");
                            Console.WriteLine("1. AZN Balance");
                            Console.WriteLine("2. USD Balance");
                            Console.WriteLine("3. EUR Balance");
                            Console.Write("User choice(1-3): ");
                            string userChoice4 = Console.ReadLine();
                            if (userChoice3 == "1" || userChoice3 == "2" || userChoice3 == "3")
                            {
                                if (int.TryParse(userChoice4, out int choice2))
                                {
                                    switch (choice2)
                                    {
                                        case 0:
                                            return;
                                            break;
                                        case 1:
                                            switch (currencyType)
                                            {
                                                case CurrencyType.Default:
                                                    return;
                                                    break;
                                                case CurrencyType.AZN:
                                                    Console.Write("Money value: ");
                                                    string amount = Console.ReadLine();
                                                    if (decimal.TryParse(amount, out decimal newAmount))
                                                    {
                                                        newBankAccount.WithDrawAZN(newAmount);
                                                        DateTime dateTime = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount, dateTime, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo1 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo1 == "yes" || yesOrNo1 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.USD:
                                                    Console.Write("Money value: ");
                                                    string amount3 = Console.ReadLine();
                                                    if (decimal.TryParse(amount3, out decimal newAmount3))
                                                    {
                                                        newBankAccount.WithDrawAZN(newAmount3 * (decimal)1.7);
                                                        DateTime dateTime2 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount3 * (decimal)1.7, dateTime2, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.EUR:
                                                    Console.Write("Money value: ");
                                                    string amount4 = Console.ReadLine();
                                                    if (decimal.TryParse(amount4, out decimal newAmount4))
                                                    {
                                                        newBankAccount.WithDrawAZN(newAmount4 * (decimal)1.8);
                                                        DateTime dateTime3 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount4 * (decimal)1.8, dateTime3, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo3 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo3 == "yes" || yesOrNo3 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInvalid choice, try again!\n");
                                                    goto PATH8;
                                                    break;
                                            }
                                            break;
                                        case 2:
                                            switch (currencyType)
                                            {
                                                case CurrencyType.Default:
                                                    return;
                                                    break;
                                                case CurrencyType.AZN:
                                                    Console.Write("Money value: ");
                                                    string amount = Console.ReadLine();
                                                    if (decimal.TryParse(amount, out decimal newAmount))
                                                    {
                                                        newBankAccount.WithDrawUSD(newAmount * (decimal)0.59);
                                                        DateTime dateTime = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount * (decimal)0.59, dateTime, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo4 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo4 == "yes" || yesOrNo4 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.USD:
                                                    Console.Write("Money value: ");
                                                    string amount3 = Console.ReadLine();
                                                    if (decimal.TryParse(amount3, out decimal newAmount3))
                                                    {
                                                        newBankAccount.WithDrawUSD(newAmount3);
                                                        DateTime dateTime2 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount3, dateTime2, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo5 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo5 == "yes" || yesOrNo5 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.EUR:
                                                    Console.Write("Money value: ");
                                                    string amount4 = Console.ReadLine();
                                                    if (decimal.TryParse(amount4, out decimal newAmount4))
                                                    {
                                                        newBankAccount.WithDrawUSD(newAmount4 * (decimal)1.06);
                                                        DateTime dateTime3 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount4 * (decimal)1.06, dateTime3, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo6 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo6 == "yes" || yesOrNo6 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInvalid choice, try again!\n");
                                                    goto PATH8;
                                                    break;
                                            }
                                            break;
                                        case 3:
                                            switch (currencyType)
                                            {
                                                case CurrencyType.Default:
                                                    return;
                                                    break;
                                                case CurrencyType.AZN:
                                                    Console.Write("Money value: ");
                                                    string amount = Console.ReadLine();
                                                    if (decimal.TryParse(amount, out decimal newAmount))
                                                    {
                                                        newBankAccount.WithDrawEUR(newAmount * (decimal)0.55);
                                                        DateTime dateTime = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount * (decimal)0.55, dateTime, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo7 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo7 == "yes" || yesOrNo7 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.USD:
                                                    Console.Write("Money value: ");
                                                    string amount3 = Console.ReadLine();
                                                    if (decimal.TryParse(amount3, out decimal newAmount3))
                                                    {
                                                        newBankAccount.WithDrawEUR(newAmount3 * (decimal)0.94);
                                                        DateTime dateTime2 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount3 * (decimal)0.94, dateTime2, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo8 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo8 == "yes" || yesOrNo8 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                case CurrencyType.EUR:
                                                    Console.Write("Money value: ");
                                                    string amount4 = Console.ReadLine();
                                                    if (decimal.TryParse(amount4, out decimal newAmount4))
                                                    {
                                                        newBankAccount.WithDrawEUR(newAmount4);
                                                        DateTime dateTime3 = DateTime.Now;
                                                        Transaction transaction = new Transaction(newAmount4, dateTime3, Enums.Operations.WithdrawMoney);
                                                        Array.Resize(ref newBankAccount.transactions, newBankAccount.transactions.Length + 1);
                                                        newBankAccount.transactions[newBankAccount.transactions.Length - 1] = transaction;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The amount of money should be decimal type!");
                                                        Console.Write("Continue?(Y/N): ");
                                                        string yesOrNo9 = Console.ReadLine().ToLower().Trim();
                                                        if (yesOrNo9 == "yes" || yesOrNo9 == "y")
                                                        {
                                                            goto PATH8;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInvalid choice, try again!\n");
                                                    goto PATH8;
                                                    break;
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Invalid choice, try again!");
                                            Console.Write("Continue?(Y/N): ");
                                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                                            if (yesOrNo == "yes" || yesOrNo == "y")
                                            {
                                                goto PATH8;
                                            }
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
                                        goto PATH26;
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
                                    goto PATH26;
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
                                goto PATH26;
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
                            goto PATH26;
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
                        goto PATH11;
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
                    goto PATH11;
                }

            }
        }

        public void ListTransactions()
        {
            Console.WriteLine("\n\tTransaction list\n");
            Console.WriteLine("Please, choose a card: ");
            Console.WriteLine("\nCard Number | Card CVV | Card expiration date\n");
            int count = 0;
            foreach (var item in bankAccounts)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
            }
            Console.WriteLine("0. Exit");
        PATH13:
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                if (choice <= count)
                {
                    BankAccount newBankAccount = null;
                    for (int i = 0; i < bankAccounts.Length; i++)
                    {
                        if (choice == i + 1)
                        {
                            newBankAccount = bankAccounts[i];
                            break;
                        }
                    }
                    Console.WriteLine($"\n\t{newBankAccount.CardNumber} transaction list\n");
                    foreach (var item in newBankAccount.transactions)
                    {
                        Console.WriteLine($"Transaction type: {item.TransactionType}\n" +
                            $"Transaction date: {item.TransactionDate}\n" +
                            $"Transaction amount: {item.Amount}\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH13;
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
                    goto PATH13;
                }
            }
        }

        public void Transfer()
        {

            Console.WriteLine("\n\tMoney transfer section\n");
        PATH14:
            Console.WriteLine("Please, enter the last 8 digits of the first card numbers");
            Console.Write("(4050 6070 XXXX XXXX): ");
            string cardNumber = Console.ReadLine().Trim();
            Console.WriteLine("\nPlease, enter the last 8 digits of the second card numbers");
            Console.Write("(4050 6070 XXXX XXXX): ");
            string cardNumber2 = Console.ReadLine().Trim();
            if (cardNumber.Length == 9 && cardNumber2.Length == 9)
            {
                BankAccount newBankAccount = null;
                BankAccount newBankAccount2 = null;
                bool account1 = false;
                bool account2 = false;
                for (int i = 0; i < bankAccounts.Length; i++)
                {
                    if (bankAccounts[i].CardNumber == $"4050 6070 {cardNumber}")
                    {
                        newBankAccount = bankAccounts[i];
                        account1 = true;
                        break;

                    }
                }
                for (int i = 0; i < bankAccounts.Length; i++)
                {
                    if (bankAccounts[i].CardNumber == $"4050 6070 {cardNumber2}")
                    {
                        newBankAccount2 = bankAccounts[i];
                        account2 = true;
                        break;

                    }
                }
                if (account1 && account2)
                {
                    Console.WriteLine($"\nHow much money do you want to transfer from {newBankAccount.CardNumber} to {newBankAccount2.CardNumber}");
                PATH15:
                    Console.WriteLine("\nWhich kind of currency type you want to be transfer?");
                    Console.WriteLine("1. AZN");
                    Console.WriteLine("2. USD");
                    Console.WriteLine("3. EUR");
                    Console.Write("User choice(1-3): ");
                    string userChoice3 = Console.ReadLine();
                    if (userChoice3 == "1" || userChoice3 == "2" || userChoice3 == "3")
                    {
                        if (Enums.CurrencyType.TryParse(userChoice3, out Enums.CurrencyType currencyType))
                        {
                        PATH30:
                            Console.WriteLine("Which balance type do you want to be deposit?");
                            Console.WriteLine("The first card choice:");
                            Console.WriteLine("1. AZN Balance");
                            Console.WriteLine("2. USD Balance");
                            Console.WriteLine("3. EUR Balance");
                            Console.Write("User choice(1-3): ");
                            string userChoice4 = Console.ReadLine();
                            Console.WriteLine("The second card choice:");
                            Console.WriteLine("1. AZN Balance");
                            Console.WriteLine("2. USD Balance");
                            Console.WriteLine("3. EUR Balance");
                            Console.Write("User choice(1-3): ");
                            string userChoice5 = Console.ReadLine();
                            if ((userChoice4 == "1" || userChoice4 == "2" || userChoice4 == "3") &&
                                (userChoice5 == "1" || userChoice5 == "2" || userChoice5 == "3"))
                            {
                                if (int.TryParse(userChoice4, out int choice2) && int.TryParse(userChoice5, out int choice3))
                                {
                                    if (choice2 == 1 && choice3 == 1)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawAZN(amount);
                                                    newBankAccount2.DepositAZN(amount);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawAZN(amount2 * (decimal)1.7);
                                                    newBankAccount2.DepositAZN(amount2 * (decimal)1.7);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawAZN(amount3 * (decimal)1.8);
                                                    newBankAccount2.DepositAZN(amount3 * (decimal)1.8);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
                                        }
                                    }
                                    else if (choice2 == 1 && choice3 == 2)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawAZN(amount);
                                                    newBankAccount2.DepositUSD(amount * (decimal)0.59);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawAZN(amount2 * (decimal)1.7);
                                                    newBankAccount2.DepositUSD(amount2);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawAZN(amount3 * (decimal)1.8);
                                                    newBankAccount2.DepositUSD(amount3 * (decimal)0.94);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
                                        }
                                    }
                                    else if (choice2 == 1 && choice3 == 3)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawAZN(amount);
                                                    newBankAccount2.DepositEUR(amount * (decimal)0.55);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawAZN(amount2 * (decimal)1.7);
                                                    newBankAccount2.DepositEUR(amount2 * (decimal)0.94);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawAZN(amount3 * (decimal)1.8);
                                                    newBankAccount2.DepositEUR(amount3);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
                                        }
                                    }
                                    else if (choice2 == 2 && choice3 == 1)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawUSD(amount * (decimal)0.59);
                                                    newBankAccount2.DepositAZN(amount * (decimal)1.7);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawUSD(amount2);
                                                    newBankAccount2.DepositAZN(amount2 * (decimal)1.7);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawUSD(amount3 * (decimal)1.06);
                                                    newBankAccount2.DepositAZN(amount3 * (decimal)1.8);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
                                        }
                                    }
                                    else if (choice2 == 2 && choice3 == 2)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawUSD(amount * (decimal)0.59);
                                                    newBankAccount2.DepositUSD(amount * (decimal)0.59);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawUSD(amount2);
                                                    newBankAccount2.DepositUSD(amount2);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawUSD(amount3 * (decimal)1.06);
                                                    newBankAccount2.DepositUSD(amount3 * (decimal)1.06);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
                                        }
                                    }
                                    else if (choice2 == 2 && choice3 == 3)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawUSD(amount * (decimal)0.59);
                                                    newBankAccount2.DepositEUR(amount * (decimal)0.55);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawUSD(amount2);
                                                    newBankAccount2.DepositEUR(amount2 * (decimal)0.55);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawUSD(amount3 * (decimal)1.06);
                                                    newBankAccount2.DepositEUR(amount3);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
                                        }
                                    }
                                    else if (choice2 == 3 && choice3 == 1)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawEUR(amount * (decimal)0.55);
                                                    newBankAccount2.DepositAZN(amount);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawEUR(amount2 * (decimal)0.94);
                                                    newBankAccount2.DepositAZN(amount2 * (decimal)1.7);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawEUR(amount3);
                                                    newBankAccount2.DepositAZN(amount3 * (decimal)1.8);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
                                        }
                                    }
                                    else if (choice2 == 3 && choice3 == 2)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawEUR(amount * (decimal)0.55);
                                                    newBankAccount2.DepositUSD(amount * (decimal)1.7);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawEUR(amount2 * (decimal)0.94);
                                                    newBankAccount2.DepositUSD(amount2);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawEUR(amount3);
                                                    newBankAccount2.DepositUSD(amount3 * (decimal)1.06);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
                                        }
                                    }
                                    else if (choice2 == 3 && choice3 == 3)
                                    {
                                        switch (currencyType)
                                        {
                                            case CurrencyType.AZN:
                                                Console.Write("Money value:");
                                                string transferMoney = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney, out var amount))
                                                {
                                                    newBankAccount.WithDrawEUR(amount * (decimal)0.55);
                                                    newBankAccount2.DepositEUR(amount * (decimal)0.55);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.USD:
                                                Console.Write("Money value:");
                                                string transferMoney2 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney2, out var amount2))
                                                {
                                                    newBankAccount.WithDrawEUR(amount2 * (decimal)0.94);
                                                    newBankAccount2.DepositEUR(amount2 * (decimal)0.94);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            case CurrencyType.EUR:
                                                Console.Write("Money value:");
                                                string transferMoney3 = Console.ReadLine();
                                                if (decimal.TryParse(transferMoney3, out var amount3))
                                                {
                                                    newBankAccount.WithDrawAZN(amount3);
                                                    newBankAccount2.DepositEUR(amount3);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The amount of money should be decimal type!");
                                                    Console.Write("Continue?(Y/N): ");
                                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                                    {
                                                        goto PATH30;
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid choice, try again!\n");
                                                goto PATH30;
                                                break;
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
                                        goto PATH30;
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
                                    goto PATH30;
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
                                goto PATH15;
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
                            goto PATH15;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("\nThere is no such cards in your account!, try again!\n");
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH14;
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
                    goto PATH14;
                }
            }

        }

        public void AddAccount()
        {
            Console.WriteLine("\n\tAdd new account section\n");
        // Account type section
        PATH16:
            Console.WriteLine("\n\tAccount type\n");
            Console.WriteLine("1. Checking"); // 2000 Max
            Console.WriteLine("2. Savings"); // 20000 Max
            Console.WriteLine("3. Business"); // 200000 Max
            Console.Write("\nEnter your choice(1-3): ");
            string accountType = Console.ReadLine();
            if (accountType == "1" || accountType == "2" || accountType == "3")
            {
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

                }

            // Currency type section
            PATH17:
                Console.WriteLine("\n\tCurrency type\n");
                Console.WriteLine("1. AZN");
                Console.WriteLine("2. USD");
                Console.WriteLine("3. EUR");
                Console.Write("\nEnter your choice(1-3): ");
                string currencyType = Console.ReadLine();
                if (currencyType == "1" || currencyType == "2" || currencyType == "3")
                {
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
                    }

                // Pincode section
                PATH20:
                    Console.Write("\nPincode(Ex: 0000): ");
                    string pincode = Console.ReadLine().Trim();

                    if (pincode.Length == 4 && int.TryParse(pincode, out int newPincode))
                    {
                        Random random = new Random();
                        bool checkPincode = true;

                        string cardNumber = $"4050 6070 {random.Next(1000, 9999)} {random.Next(1000, 9999)}";
                        DateTime expirationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        string formattedDate = expirationDate.ToString("MM/yy");
                        int cvv = random.Next(100, 999);

                        for (int i = 0; i < bankAccounts.Length; i++)
                        {
                            if (bankAccounts[i].Pincode == newPincode)
                            {
                                checkPincode = false;
                                break;
                            }
                        }
                        if (checkPincode)
                        {
                            BankAccount bankAccount = new BankAccount(newPincode, cardNumber, expirationDate, cvv, userAccountType, userCurrencyType);

                            Array.Resize(ref bankAccounts, bankAccounts.Length + 1);
                            bankAccounts[bankAccounts.Length - 1] = bankAccount;

                            Console.WriteLine($"\n\tYour new card information\n");
                            Console.WriteLine($"Card number: {cardNumber}");
                            Console.WriteLine($"Card expiration date: {formattedDate}");
                            Console.WriteLine($"Card number: {cvv}");

                            RunCheck = true;
                        }
                        else
                        {
                            Console.WriteLine("\nThis pincode used before, try another pincode!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH20;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPincode length must be equel to 4 and all input contains from numbers!\n");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo == "yes" || yesOrNo == "y")
                        {
                            goto PATH20;
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
                        goto PATH17;
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
                    goto PATH16;
                }
            }
        }

        public void DeleteAccount()
        {
            Console.WriteLine("\n\tDelete Account section\n");
            Console.WriteLine("Please, choose a card: ");
            Console.WriteLine("\nCard Number | Card CVV | Card expiration date\n");
            int count = 0;
            foreach (var item in bankAccounts)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
            }
            Console.WriteLine("0. Exit");
        PATH60:
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                if (choice <= count)
                {
                    BankAccount newBankAccount = null;
                    for (int i = 0; i < bankAccounts.Length; i++)
                    {
                        if (choice == i + 1)
                        {
                            newBankAccount = bankAccounts[i];
                            break;
                        }
                    }
                PATH61:
                    Console.Write("Please, enter card's pincode: ");
                    string userPincode = Console.ReadLine();
                    if (int.TryParse(userPincode, out int pincode) && userPincode.Length == 4)
                    {
                        if (newBankAccount.Pincode == pincode)
                        {
                            BankAccount[] accounts = new BankAccount[bankAccounts.Length - 1];
                            int index = 0;

                            for (int i = 0; i < bankAccounts.Length; i++)
                            {
                                if (newBankAccount != bankAccounts[i])
                                {
                                    accounts[index] = bankAccounts[i];
                                    index++;
                                }
                            }

                            bankAccounts = accounts;
                        }
                        else
                        {
                            Console.WriteLine("\nThis card's pincode is not like that!\n");
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH61;
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
                            goto PATH61;
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
                        goto PATH60;
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
                    goto PATH60;
                }
            }
        }

        public void CurrencyConversion()
        {
            Console.WriteLine("\n\tCurrency conversion section\n");
            Console.WriteLine("Please, choose a card: ");
            Console.WriteLine("\nCard Number | Card CVV | Card expiration date\n");
            int count = 0;
            foreach (var item in bankAccounts)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
            }
            Console.WriteLine("0. Exit");
        PATH40:
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                if (choice <= count)
                {
                    BankAccount newBankAccount = null;
                    for (int i = 0; i < bankAccounts.Length; i++)
                    {
                        if (choice == i + 1)
                        {
                            newBankAccount = bankAccounts[i];
                            break;
                        }
                    }
                PATH41:
                    Console.WriteLine("What kind of conversion do you want?");
                    Console.WriteLine("1. AZN - USD");
                    Console.WriteLine("2. AZN - EUR");
                    Console.WriteLine("3. USD - AZN");
                    Console.WriteLine("4. USD - EUR");
                    Console.WriteLine("5. EUR - AZN");
                    Console.WriteLine("6. EUR - USD");
                    Console.Write("User choice(1-6): ");
                    string userChoice2 = Console.ReadLine();
                    if (userChoice2 == "1" || userChoice2 == "2" || userChoice2 == "3" ||
                        userChoice2 == "4" || userChoice2 == "5" || userChoice2 == "6")
                    {
                        switch (userChoice2)
                        {
                            case "1":
                                Console.Write("Money value:");
                                string transferMoney = Console.ReadLine();
                                if (decimal.TryParse(transferMoney, out var amount))
                                {
                                    newBankAccount.WithDrawAZN(amount);
                                    newBankAccount.DepositUSD(amount * (decimal)0.59);
                                }
                                else
                                {
                                    Console.WriteLine("The amount of money should be decimal type!");
                                    Console.Write("Continue?(Y/N): ");
                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                    {
                                        goto PATH41;
                                    }
                                }
                                break;
                            case "2":
                                Console.Write("Money value:");
                                string transferMoney2 = Console.ReadLine();
                                if (decimal.TryParse(transferMoney2, out var amount2))
                                {
                                    newBankAccount.WithDrawAZN(amount2);
                                    newBankAccount.DepositUSD(amount2 * (decimal)0.55);
                                }
                                else
                                {
                                    Console.WriteLine("The amount of money should be decimal type!");
                                    Console.Write("Continue?(Y/N): ");
                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                    {
                                        goto PATH41;
                                    }
                                }
                                break;
                            case "3":
                                Console.Write("Money value:");
                                string transferMoney3 = Console.ReadLine();
                                if (decimal.TryParse(transferMoney3, out var amount3))
                                {
                                    newBankAccount.WithDrawUSD(amount3);
                                    newBankAccount.DepositAZN(amount3 * (decimal)1.7);
                                }
                                else
                                {
                                    Console.WriteLine("The amount of money should be decimal type!");
                                    Console.Write("Continue?(Y/N): ");
                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                    {
                                        goto PATH41;
                                    }
                                }
                                break;
                            case "4":
                                Console.Write("Money value:");
                                string transferMoney4 = Console.ReadLine();
                                if (decimal.TryParse(transferMoney4, out var amount4))
                                {
                                    newBankAccount.WithDrawUSD(amount4);
                                    newBankAccount.DepositEUR(amount4 * (decimal)0.94);
                                }
                                else
                                {
                                    Console.WriteLine("The amount of money should be decimal type!");
                                    Console.Write("Continue?(Y/N): ");
                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                    {
                                        goto PATH41;
                                    }
                                }
                                break;
                            case "5":
                                Console.Write("Money value:");
                                string transferMoney5 = Console.ReadLine();
                                if (decimal.TryParse(transferMoney5, out var amount5))
                                {
                                    newBankAccount.WithDrawEUR(amount5);
                                    newBankAccount.DepositAZN(amount5 * (decimal)1.8);
                                }
                                else
                                {
                                    Console.WriteLine("The amount of money should be decimal type!");
                                    Console.Write("Continue?(Y/N): ");
                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                    {
                                        goto PATH41;
                                    }
                                }
                                break;
                            case "6":
                                Console.Write("Money value:");
                                string transferMoney6 = Console.ReadLine();
                                if (decimal.TryParse(transferMoney6, out var amount6))
                                {
                                    newBankAccount.WithDrawEUR(amount6);
                                    newBankAccount.DepositUSD(amount6 * (decimal)1.06);
                                }
                                else
                                {
                                    Console.WriteLine("The amount of money should be decimal type!");
                                    Console.Write("Continue?(Y/N): ");
                                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                                    if (yesOrNo == "yes" || yesOrNo == "y")
                                    {
                                        goto PATH41;
                                    }
                                }
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
                            goto PATH41;
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
                        goto PATH40;
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
                    goto PATH40;
                }
            }
        }

        public void Settings()
        {
        PATH54:
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
                            Console.WriteLine($"\nYour name: {BankAccount.Name}");
                            Console.Write("Please, enter your new name: ");
                            string name = Console.ReadLine().Trim();
                            BankAccount.Name = name;
                            Console.WriteLine("Your name has been changed!");
                            break;
                        case 2:
                            Console.WriteLine($"\nYour surname: {BankAccount.Surname}");
                            Console.Write("Please, enter your new surname: ");
                            string surname = Console.ReadLine().Trim();
                            BankAccount.Surname = surname;
                            Console.WriteLine("Your surname has been changed!");
                            break;
                        case 3:
                        PATH51:
                            Console.WriteLine($"\nYour email: {BankAccount.Email}");
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
                                    goto PATH51;
                                }
                                else
                                {
                                    return;
                                }
                            }

                            BankAccount.Email = email;
                            Console.WriteLine("Your email has been changed!");
                            break;
                        case 4:
                        PATH52:
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
                                    goto PATH52;
                                }
                                else
                                {
                                    return;
                                }
                            }

                            BankAccount.Password = password;
                            Console.WriteLine("Your password has been changed!");
                            break;
                        case 5:
                            Console.WriteLine($"\nYour phone number: {BankAccount.PhoneNumber}");
                            Console.Write("Please, enter your new phone number(+994-XX-XXX-XX-XX): ");
                            string phoneNumber = Console.ReadLine().Trim();
                            BankAccount.PhoneNumber = phoneNumber;
                            Console.WriteLine("Your phone number has been changed!");
                            break;
                        case 6:
                        PATH50:
                            Console.WriteLine("Please, choose a card: ");
                            Console.WriteLine("\nCard Number | Card CVV | Card expiration date\n");
                            int count = 0;
                            foreach (var item in bankAccounts)
                            {
                                count++;
                                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
                            }
                            Console.WriteLine("0. Exit");
                            Console.Write($"\nUser choice(0-{count}): ");
                            string userChoice2 = Console.ReadLine();
                            if (userChoice == "0") return;
                            if (int.TryParse(userChoice2, out int choice2))
                            {
                                if (choice2 <= count)
                                {
                                    BankAccount newBankAccount = null;
                                    for (int i = 0; i < bankAccounts.Length; i++)
                                    {
                                        if (choice2 == i + 1)
                                        {
                                            newBankAccount = bankAccounts[i];
                                            break;
                                        }
                                    }
                                    Console.Write("Please, enter your new pincode: ");
                                    string pincode = Console.ReadLine().Trim();
                                    if (pincode.Length == 4 && int.TryParse(pincode, out int newPincode))
                                    {
                                        newBankAccount.Pincode = newPincode;
                                        Console.WriteLine("Your pincode has been changed!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid choice, try again!\n");
                                        Console.Write("Continue?(Y/N): ");
                                        string yesOrNo = Console.ReadLine().ToLower().Trim();
                                        if (yesOrNo == "yes" || yesOrNo == "y")
                                        {
                                            goto PATH50;
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
                                        goto PATH50;
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
                                    goto PATH50;
                                }
                                else
                                {
                                    return;
                                }
                            }
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
                        goto PATH54;
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
                    goto PATH54;
                }
            }

        }
    }
}
