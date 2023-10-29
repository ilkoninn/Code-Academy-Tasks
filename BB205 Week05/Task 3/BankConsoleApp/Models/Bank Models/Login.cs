using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.Bank_Models
{
    internal class Login
    {
        public static User UserLogin()
        {
            Console.WriteLine("\n\tLogin section\n");
            User loginUser = null;
            Console.Write("Phone number/Email: ");
            string phoneNumberOrEmail = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            loginUser = CheckUser(phoneNumberOrEmail, password);

            return loginUser;
        }

        public static User CheckUser(string phoneNumberOrEmail, string password)
        {
            User checkUser = null;
            string result;
            string userJSONPath = @"C:\Users\99470\Desktop\BankConsoleApp" + @"\Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            checkUser = deserializeJson.Find(x => (x.PhoneNumber == phoneNumberOrEmail || x.Email == phoneNumberOrEmail) && (x.Password == password));

            return checkUser;
        }

    }
}
