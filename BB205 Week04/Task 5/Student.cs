using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Student
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(value.Length >= 3)
                {
                    _name = value;
                }
                else Console.WriteLine("Entered name is invalid!");
            }
        }

        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _surname = value;
                }
                else Console.WriteLine("Entered surname is invalid!");
            }
        }
        private int _avgpoint;
        public int AvgPoint
        {
            get
            {
                return _avgpoint;
            }
            set
            {
                if(value >= 0 && value <= 100)
                {
                    _avgpoint = value;
                }
                else Console.WriteLine("Entered average point is invalid!");

            }
        }
        public Student(string name, string surname, int avgpoint, int id)
        {
            Name = name;
            Surname = surname;
            AvgPoint = avgpoint;
            Id = id;
        }
        public string GetStudentInfo()
        {
            return $"{Id}. {Name} {Surname} {AvgPoint}";
        }
    }
}
