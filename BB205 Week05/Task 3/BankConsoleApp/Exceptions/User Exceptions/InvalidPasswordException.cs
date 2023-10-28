using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions
{
    internal class InvalidPasswordException:Exception 
    {
        public InvalidPasswordException(string message = "\nPassword does not meet the criteria!\nPassword must contain at least 1 number, 1 uppercase letter, 1 lowercase letter, length should not be less than 8, try again! (Ex: Smth2000)\n"):base(message) { }
    }
}
