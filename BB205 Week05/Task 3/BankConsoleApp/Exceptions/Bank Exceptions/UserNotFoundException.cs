using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Exceptions
{
    internal class UserNotFoundException:Exception
    {
        public UserNotFoundException(string message="\nThere is no such a user in Bank!\n"):base(message) { }
    }
}
