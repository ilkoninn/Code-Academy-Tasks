using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Backend : Developer
    {
        public decimal sqlExperienceYear;

        public Backend(string name, string surname, decimal experience)
        {
            this.name = name;
            this.surname = surname;
            this.experience = experience;
        }
    }
}
