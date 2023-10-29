using BankConsoleApp.Enums;
using BankConsoleApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Deposit_Models
{
    internal static class DepositToAZNBalance
    {
        public static void Deposit(User user, BankCard bankCard, CurrencyType currencyType)
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
                        DepositToAZNBankCard(user, bankCard, newAmount, currencyType);
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
                        DepositToAZNBankCard(user, bankCard, newAmount2 * (decimal)1.7, currencyType);
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
                        DepositToAZNBankCard(user, bankCard, newAmount3 * (decimal)1.8, currencyType);
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

        public static void DepositToAZNBankCard(User user, BankCard bankCard, decimal amount, CurrencyType currencyType)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).DepositAZN(amount);
            if(amount > 0)
            {
                DateTime dateTime = DateTime.Now;
                Transaction transaction = new Transaction(amount, dateTime, Enums.Operations.DepositMoney, currencyType);
                newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction);
            }

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
    }
}
