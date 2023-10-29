using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Withdraw_Models
{
    internal static class WithdrawFromAZNBalance
    {

        public static void Withdraw(BankCard bankCard, CurrencyType currencyType)
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
                        bankCard.WithDrawAZN(newAmount);
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
                        bankCard.WithDrawAZN(newAmount2 * (decimal)1.7);
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
                        bankCard.WithDrawAZN(newAmount3 * (decimal)1.8);
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
    }
}
