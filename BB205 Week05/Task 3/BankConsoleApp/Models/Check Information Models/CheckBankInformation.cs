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
            for (int i = 0; i < user.bankCards.Count; i++)
            {
                if (choice == i + 1)
                {
                    return user.bankCards[i];
                }
            }
            return null;
        }
        public static BankCard GetBankCardByDigit(string digit)
        {
            foreach (var item in Bank.UserAccounts)
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
    }
}
