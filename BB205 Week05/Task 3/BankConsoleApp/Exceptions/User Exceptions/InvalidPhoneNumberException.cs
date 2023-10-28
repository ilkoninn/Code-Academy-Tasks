using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions
{
    internal class InvalidPhoneNumberException:Exception
    {
        public InvalidPhoneNumberException(string message = "\nPhone number does not meet to criteria, length of phone number greater 8 and lower than 13, try again! (Ex: 70 660 00 17)\n") : base(message) { }
    }
}
