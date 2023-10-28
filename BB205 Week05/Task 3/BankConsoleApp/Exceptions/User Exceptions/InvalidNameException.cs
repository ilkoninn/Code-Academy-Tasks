using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions
{
    internal class InvalidNameException:Exception
    {
        public InvalidNameException(string message = "\nName does not meet to criteria, length of name greater and equel than 3, the first letter should be uppercase and no any digit in your name, try again! (Ex: Ilkin)\n"):base(message) { }
    }
}
