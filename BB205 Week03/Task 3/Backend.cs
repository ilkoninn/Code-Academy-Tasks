﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Backend : Developer
    {
        public string name;
        public string surname;
        public int age;
        public float experience;
        public float sqlExperienceYear;

        public Backend(string name, string surname, float experience)
        {
            this.name = name;
            this.surname = surname;
            this.experience = experience;
        }
    }
}
