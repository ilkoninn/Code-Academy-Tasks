using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.Registartion_Exceptions
{
    internal class InvalidAgeException:Exception
    {
        public InvalidAgeException(string message = "Your age is not enough to register from Bank"):base(message) { }
    }
}
