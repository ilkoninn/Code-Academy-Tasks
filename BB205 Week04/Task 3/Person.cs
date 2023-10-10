using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Person
    {
        private int _age;
        public int Age 
        {
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
            }
        }

        private string _fullname;
        public string Fullname 
        {
            get
            {
                return _fullname;
            }
            set
            {
                string[] newValue = value.Split(" ");
                if(newValue.Length != 2 )
                {
                    Console.WriteLine("Fullname should contain with two word.");
                }
                else 
                {
                    if (char.IsUpper(newValue[0][0]) && char.IsUpper(newValue[1][0]))
                    {
                        _fullname = value;
                    }
                    else
                    {
                        Console.WriteLine("First name and last name first letter should be upper case!");
                    }
                }
            } 
        }
        private string _phonenumber;
        public string PhoneNumber 
        {
            get
            {
                return _phonenumber;
            }
            set
            {
                if(value.Substring(0, 4) == "+994")
                {
                    _phonenumber = value;
                }
                else
                {
                    Console.WriteLine("Your phone number information is wrong!");
                }
            }
        }

        public Person(string name, int age, string phonenumber)
        {
            Fullname = name;
            Age = age;
            PhoneNumber = phonenumber;
        }

    }
}
