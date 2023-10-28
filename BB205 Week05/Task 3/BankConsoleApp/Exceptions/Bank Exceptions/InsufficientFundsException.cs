using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions
{
    internal class InsufficientFundsException:Exception
    {
        public InsufficientFundsException(string message = "There are no funds on your card equal to the amount entered") :base(message) { }
    }
}
