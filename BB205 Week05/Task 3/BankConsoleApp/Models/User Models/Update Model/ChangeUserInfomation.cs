using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models.Update_Model
{
    internal static class ChangeUserInfomation
    {
        public static void UpdateName(User user, string name)
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
            newUser.Name = name;

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void UpdateSurname(User user, string surname)
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
            newUser.Surname = surname;

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void UpdateEmail(User user, string email)
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
            newUser.Surname = email;

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void UpdatePassword(User user, string password)
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
            newUser.Password = password;

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void UpdatePhoneNumber(User user, string phoneNumber)
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
            newUser.PhoneNumber = phoneNumber;

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
        public static void UpdatePincode(User user, BankCard bankCard, int pincode)
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
            BankCard userBankCard = newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId);
            userBankCard.Pincode = pincode;

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }
        }
    }
}
