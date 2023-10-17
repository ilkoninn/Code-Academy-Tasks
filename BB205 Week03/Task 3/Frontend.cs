using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Frontend : Developer
    {
        public byte ReactExperienceYear;
        
        public Frontend(string name, string surname, byte experience)
        {
            this.name = name;
            this.surname = surname;
            this.experience = experience;
        }
    }
}
