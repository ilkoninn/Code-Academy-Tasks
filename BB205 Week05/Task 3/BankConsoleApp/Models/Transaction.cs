using BankConsoleApp.Enums;
using BankConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models
{
    internal class Transaction
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set;  }
        public DateTime TransactionDate { get; set; }
        public Enums.Operations TransactionType { get; set; }
        public CurrencyType CurrencyType { get; set; }

        public Transaction(decimal amount, DateTime transactionDate, Enums.Operations transactionType, CurrencyType currencyType)
        {
            Amount = amount;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
            CurrencyType = currencyType;
            TransactionId = Guid.NewGuid();
        }

    }
}
