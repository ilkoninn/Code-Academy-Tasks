using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Deposit_Models
{
    internal static class DepositToEURBalance
    {
        public static void Deposit(BankCard bankCard, CurrencyType currencyType)
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
