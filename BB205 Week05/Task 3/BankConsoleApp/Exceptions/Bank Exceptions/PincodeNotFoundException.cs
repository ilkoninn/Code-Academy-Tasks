using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.Bank_Exceptions
{
    internal class PincodeNotFoundException:Exception
    {
        public PincodeNotFoundException(string message = "\nThis pincode is not equal to your bank card's pincode!\n"):base(message) { }
    }
}
