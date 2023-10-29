using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.Check_Information_Models
{
    internal static class CheckBankInformation
    {
        public static BankCard GetBankCard(User user, int choice)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);

            for (int i = 0; i < newUser.bankCards.Count; i++)
            {
                if (choice == i + 1)
                {
                    return newUser.bankCards[i];
                }
            }
            return null;

        }
        public static BankCard GetBankCardByDigit(string digit)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            foreach (var item in deserializeJson)
            {
                for (int i = 0; i < item.bankCards.Count; i++)
                {
                    if (item.bankCards[i].CardNumber == $"4050 6070 {digit}")
                    {
                        return item.bankCards[i];
                    }
                }
            }
            return null;
        }
        public static void GetCards(User user)
        {
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);

            Console.WriteLine("Please, choose a card: ");
            Console.WriteLine("\nCard Number | Card CVV | Card expiration date\n");
            int count = 0;
            foreach (var item in newUser.bankCards)
            {
                count++;
                string formattedDate = item.ExpirationDate.ToString("MM/yy");
                Console.WriteLine($"{count}. {item.CardNumber} | {item.CVV} | {formattedDate}");
            }
            Console.WriteLine("0. Exit");
            Console.Write($"\nUser choice(0-{count}): ");

        }
    }
}
