using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Interfaces
{
    internal interface IBankCard
    {
        Guid AccountId { get; }
        int Pincode { get; set; }
        string CardNumber { get; set; }
        DateTime ExpirationDate { get; set; }
        int CVV { get; set; }

        decimal BalanceAZN { get; }
        decimal BalanceUSD { get; }
        decimal BalanceEUR { get; }
        AccountType AccountType { get; }
        CurrencyType CurrencyType { get; }


        void DepositAZN(decimal amount);
        void DepositUSD(decimal amount);
        void DepositEUR(decimal amount);
        void WithDrawAZN(decimal amount);
        void WithDrawUSD(decimal amount);
        void WithDrawEUR(decimal amount);

    }
}
