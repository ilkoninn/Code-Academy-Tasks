using BankConsoleApp.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Currency_Conversion_Model
{
    internal static class WithdrawAndDepositMoneyConversion
    {
        public static void WithdrawAZNDepositUSD(User user, BankCard bankCard, decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);

            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).WithDrawAZN(amount1);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).DepositUSD(amount2);
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
            Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction2);

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void WithdrawAZNDepositEUR(User user, BankCard bankCard, decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);

            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).WithDrawAZN(amount1);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).DepositEUR(amount2);
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
            Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction2);

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void WithdrawUSDDepositAZN(User user, BankCard bankCard, decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);

            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).WithDrawUSD(amount1);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).DepositAZN(amount2);
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
            Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction2);

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void WithdrawUSDDepositEUR(User user, BankCard bankCard, decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);

            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).WithDrawUSD(amount1);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).DepositEUR(amount2);
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
            Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction2);

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void WithdrawEURDepositAZN(User user, BankCard bankCard, decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);

            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).WithDrawEUR(amount1);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).DepositAZN(amount2);
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
            Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction2);

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void WithdrawEURDepositUSD(User user, BankCard bankCard, decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);

            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).WithDrawEUR(amount1);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).DepositUSD(amount2);
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
            Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction);
            newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId).transactions.Add(transaction2);

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }

    }
}
