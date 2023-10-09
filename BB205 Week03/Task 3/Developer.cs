using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Developer
    {
        public string name;
        public string surname;
        public byte age;
        public byte experience;

        public string AreYouHired(byte exp, byte age)
        {
            if (exp > 1 && age >= 18)
            {
                return "You have been hired!";
            }
            else
            {
                return "You have not been hired!";
            }
        }

    }
}
