using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions
{
    internal class InvalidSurnameException:Exception
    {
        public InvalidSurnameException(string message = "\nSurname does not meet to criteria, length of surname greater and equel than 3, the first letter should be uppercase and no any digit in your surname, try again! (Ex: Rajabov)\n") : base(message) { }
    }
}
