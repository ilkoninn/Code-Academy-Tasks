using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Animal
    {
        public string Name { get; set; }
        private byte _age;
        public byte Age { 
            get 
            {
                return _age;
            }
            set 
            { 
                if(value < 0)
                {
                    Console.WriteLine("Age should be a positive number!");
                }
                else
                {
                    _age = value;
                }
            } }
        public string Breed { get; set; }

        public Animal(string name, byte age)
        {
            Name = name;
            Age = age;
        }

        public void getInfo()
        {
            Console.WriteLine($"This animal's breed is {Breed}, name is {Name} and age is {Age}");
        }

    }
}
