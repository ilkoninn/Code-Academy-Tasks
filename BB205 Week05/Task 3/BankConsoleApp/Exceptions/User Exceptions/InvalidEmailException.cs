using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions
{
    internal class InvalidEmailException:Exception
    {
        public InvalidEmailException(string message = "\nEmail does not meet to criteria, try again! (Ex: something@someth.ing)\n") : base(message) { }
    }
}
