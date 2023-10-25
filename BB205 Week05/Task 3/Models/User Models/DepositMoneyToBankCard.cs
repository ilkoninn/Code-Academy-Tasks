using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal class DepositMoneyToBankCard
    {
        public static void DepositMoney(User user)
        {
            Console.WriteLine("\n\tDeposit Money section\n");
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
            PATH14:
            Console.Write($"\nUser choice(0-{count}): ");
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                if (choice <= count)
                {
                    BankCard newBankCard = null;
                    for (int i = 0; i < user.bankCards.Count; i++)
                    {
                        if (choice == i + 1)
                        {
                            newBankCard = user.bankCards[i];
                            break;
                        }
                    }
                    PATH15:
                    Console.WriteLine("\nWhich kind of currency type you want to be deposit?");
                    Console.WriteLine("1. AZN");
                    Console.WriteLine("2. USD");
                    Console.WriteLine("3. EUR");
                    Console.Write("User choice(1-3): ");
                    string userChoice2 = Console.ReadLine();
                    if (userChoice2 == "1" || userChoice2 == "2" || userChoice2 == "3")
                    {
                        if (Enums.CurrencyType.TryParse(userChoice2, out Enums.CurrencyType currencyType))
                        {

                            PATH25:
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
                                            DepositToAZNBalance(newBankCard, currencyType);
                                            break;
                                        case 2:
                                            DepositToUSDBalance(newBankCard, currencyType);
                                            break;
                                        case 3:
                                            DepositToEURBalance(newBankCard, currencyType);
                                            break;
                                        default:
                                            Console.WriteLine("Invalid choice, try again!");
                                            Console.Write("Continue?(Y/N): ");
                                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                                            if (yesOrNo == "yes" || yesOrNo == "y")
                                            {
                                                goto PATH25;
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
                    Console.WriteLine("\nInvalid choice, try again!\n");
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

        public static void DepositToAZNBalance(BankCard bankCard,CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.Default:
                    return;
                    break;
                case CurrencyType.AZN:
                    PATH16:
                    Console.Write("\nMoney value: ");
                    string amount = Console.ReadLine();
                    if (decimal.TryParse(amount, out decimal newAmount))
                    {
                        bankCard.DepositAZN(newAmount);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH16;
                        }
                    }
                    break;
                case CurrencyType.USD:
                    PATH17:
                    Console.Write("\nMoney value: ");
                    string amount2 = Console.ReadLine();
                    if (decimal.TryParse(amount2, out decimal newAmount2))
                    {
                        bankCard.DepositAZN(newAmount2 * (decimal)1.7);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount2, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH17;
                        }
                    }
                    break;
                case CurrencyType.EUR:
                    PATH18:
                    Console.Write("\nMoney value: ");
                    string amount3 = Console.ReadLine();
                    if (decimal.TryParse(amount3, out decimal newAmount3))
                    {
                        bankCard.DepositAZN(newAmount3 * (decimal)1.8);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount3, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH18;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    break;
            }
        }
        public static void DepositToUSDBalance(BankCard bankCard, CurrencyType currencyType) 
        {
            switch (currencyType)
            {
                case CurrencyType.Default:
                    return;
                    break;
                case CurrencyType.AZN:
                    PATH19:
                    Console.Write("\nMoney value: ");
                    string amount = Console.ReadLine();
                    if (decimal.TryParse(amount, out decimal newAmount))
                    {
                        bankCard.DepositUSD(newAmount *(decimal)0.59);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH19;
                        }
                    }
                    break;
                case CurrencyType.USD:
                    PATH20:
                    Console.Write("\nMoney value: ");
                    string amount2 = Console.ReadLine();
                    if (decimal.TryParse(amount2, out decimal newAmount2))
                    {
                        bankCard.DepositUSD(newAmount2);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount2, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH20;
                        }
                    }
                    break;
                case CurrencyType.EUR:
                    PATH21:
                    Console.Write("\nMoney value: ");
                    string amount3 = Console.ReadLine();
                    if (decimal.TryParse(amount3, out decimal newAmount3))
                    {
                        bankCard.DepositUSD(newAmount3 * (decimal)1.06);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount3, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH21;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    break;
            }
        }
        public static void DepositToEURBalance(BankCard bankCard, CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.Default:
                    return;
                    break;
                case CurrencyType.AZN:
                    PATH22:
                    Console.Write("\nMoney value: ");
                    string amount = Console.ReadLine();
                    if (decimal.TryParse(amount, out decimal newAmount))
                    {
                        bankCard.DepositEUR(newAmount * (decimal)0.56);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH22;
                        }
                    }
                    break;
                case CurrencyType.USD:
                    PATH23:
                    Console.Write("\nMoney value: ");
                    string amount2 = Console.ReadLine();
                    if (decimal.TryParse(amount2, out decimal newAmount2))
                    {
                        bankCard.DepositEUR(newAmount2 * (decimal)0.94);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount2, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH23;
                        }
                    }
                    break;
                case CurrencyType.EUR:
                    PATH24:
                    Console.Write("\nMoney value: ");
                    string amount3 = Console.ReadLine();
                    if (decimal.TryParse(amount3, out decimal newAmount3))
                    {
                        bankCard.DepositEUR(newAmount3);
                        DateTime dateTime = DateTime.Now;
                        Transaction transaction = new Transaction(newAmount3, dateTime, Enums.Operations.DepositMoney, currencyType);
                        bankCard.transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("The amount of money should be decimal type!");
                        Console.Write("Continue?(Y/N): ");
                        string yesOrNo2 = Console.ReadLine().ToLower().Trim();
                        if (yesOrNo2 == "yes" || yesOrNo2 == "y")
                        {
                            goto PATH24;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, try again!\n");
                    break;
            }
        }
    }
}
