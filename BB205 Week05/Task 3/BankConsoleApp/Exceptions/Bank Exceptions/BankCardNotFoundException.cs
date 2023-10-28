using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.Bank_Exceptions
{
    internal class BankCardNotFoundException:Exception
    {
        public BankCardNotFoundException(string message = "\nThere is no such a bank card in your account!\n") : base(message) { }
    }
}
