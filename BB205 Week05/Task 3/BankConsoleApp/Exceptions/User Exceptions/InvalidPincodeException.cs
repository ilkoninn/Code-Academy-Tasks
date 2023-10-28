using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions
{
    internal class InvalidPincodeException:Exception
    {
        public InvalidPincodeException(string message = "\nPincode length must be equel to 4 and all input contains from numbers!\n") :base(message) { }
    }
}
