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
        public int age;
        public float experience;

        public string AreYouHired(float exp, int age)
        {
            if(exp > 1 && age >= 18)
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
