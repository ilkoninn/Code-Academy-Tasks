using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Enums
{
    internal enum Operations
    {
        Default = 0,
        DepositMoney = 1,
        WithdrawMoney,
        History,
        Transfer,
        Cards,
        AddCard,
        DeleteCard,
        CurrencyConversion,
        Settings,
        Logout,
    }
}
