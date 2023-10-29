using BankConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Interfaces
{
    internal interface Operations
    {
        int TransactionId { get; }
        decimal Amount { get; }
        DateTime TransactionDate { get; }
        Operations TransactionType { get; }
        CurrencyType CurrencyType { get; set; }

    }
}
