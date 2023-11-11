using BankConsoleApp.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Transfer_Models
{
    internal static class WithdrawAndDepositEURMoneyTransfer
    {
        public static void WithdrawEURDepositAZN(BankCard bankCard, BankCard otherBankCard, decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
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

            BankCard fromBankCard = null;
            BankCard toBankCard = null;

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            foreach (var item in deserializeJson)
            {
                if (item.bankCards.Find(x => x.AccountId == bankCard.AccountId) != null)
                {
                    fromBankCard = item.bankCards.Find(x => x.AccountId == bankCard.AccountId);
                    break;
                }
            }
            foreach (var item in deserializeJson)
            {
                if (item.bankCards.Find(x => x.AccountId == otherBankCard.AccountId) != null)
                {
                    toBankCard = item.bankCards.Find(x => x.AccountId == otherBankCard.AccountId);
                    break;
                }
            }

            fromBankCard.WithDrawEUR(amount1);
            toBankCard.DepositAZN(amount2);
            if (amount1 > 0 && amount2 > 0)
            {
                DateTime dateTime = DateTime.Now;
                Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
                Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
                fromBankCard.transactions.Add(transaction);
                toBankCard.transactions.Add(transaction2);
            }

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void WithdrawEURDepositUSD(BankCard bankCard, BankCard otherBankCard,decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
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

            BankCard fromBankCard = null;
            BankCard toBankCard = null;

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            foreach(var item in deserializeJson)
            {
                if(item.bankCards.Find(x => x.AccountId == bankCard.AccountId) != null)
                {
                    fromBankCard = item.bankCards.Find(x => x.AccountId == bankCard.AccountId);
                    break;
                }
            }
            foreach (var item in deserializeJson)
            {
                if (item.bankCards.Find(x => x.AccountId == otherBankCard.AccountId) != null)
                {
                    toBankCard = item.bankCards.Find(x => x.AccountId == otherBankCard.AccountId);
                    break;
                }
            }

            fromBankCard.WithDrawEUR(amount1);
            toBankCard.DepositUSD(amount2);
            if (amount1 > 0 && amount2 > 0)
            {
                DateTime dateTime = DateTime.Now;
                Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
                Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
                fromBankCard.transactions.Add(transaction);
                toBankCard.transactions.Add(transaction2);
            }

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void WithdrawEURDepositEUR(BankCard bankCard, BankCard otherBankCard, decimal amount1, decimal amount2, CurrencyType currencyType1, CurrencyType currencyType2)
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

            BankCard fromBankCard = null;
            BankCard toBankCard = null;

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            foreach (var item in deserializeJson)
            {
                if (item.bankCards.Find(x => x.AccountId == bankCard.AccountId) != null)
                {
                    fromBankCard = item.bankCards.Find(x => x.AccountId == bankCard.AccountId);
                    break;
                }
            }
            foreach (var item in deserializeJson)
            {
                if (item.bankCards.Find(x => x.AccountId == otherBankCard.AccountId) != null)
                {
                    toBankCard = item.bankCards.Find(x => x.AccountId == otherBankCard.AccountId);
                    break;
                }
            }

            fromBankCard.WithDrawEUR(amount1);
            toBankCard.DepositEUR(amount2);
            if (amount1 > 0 && amount2 > 0)
            {
                DateTime dateTime = DateTime.Now;
                Transaction transaction = new Transaction(amount1, dateTime, Enums.Operations.WithdrawMoney, currencyType1);
                Transaction transaction2 = new Transaction(amount2, dateTime, Enums.Operations.DepositMoney, currencyType2);
                fromBankCard.transactions.Add(transaction);
                toBankCard.transactions.Add(transaction2);
            }

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
    }
}
