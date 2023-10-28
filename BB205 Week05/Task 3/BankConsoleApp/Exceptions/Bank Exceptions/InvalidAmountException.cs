using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions
{
    internal class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }
}
