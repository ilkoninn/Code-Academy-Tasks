using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTask.Models
{
    internal class Money
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal ConvertCurrency(Money money, decimal conversion) 
        {
            decimal convertedAmount = money.Amount * conversion;
            return convertedAmount;
        }
    }
}
