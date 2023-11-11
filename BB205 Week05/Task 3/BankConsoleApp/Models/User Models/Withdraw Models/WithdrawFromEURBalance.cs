using BankConsoleApp.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Withdraw_Models
{
    internal static class WithdrawFromEURBalance
    {

        public static void Withdraw(User user, BankCard bankCard, CurrencyType currencyType)
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
                        WithdrawFromEURBankCard(user, bankCard, newAmount * (decimal)0.56, currencyType);
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
                        WithdrawFromEURBankCard(user, bankCard, newAmount2 * (decimal)0.94, currencyType);
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
                        WithdrawFromEURBankCard(user, bankCard, newAmount3, currencyType);
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
        public static void WithdrawFromEURBankCard(User user, BankCard bankCard, decimal amount, CurrencyType currencyType)
        {
            string result;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            StringBuilder sb = new StringBuilder();
            foreach (var item in basePath.Split('\\'))
            {
                if (item == "bin") break;
                sb.Append(item + '\\');
            }

            string userJSONPath = sb + @"Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).WithDrawEUR(amount);
            if (amount > 0)
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

