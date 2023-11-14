using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public Person(int id, string name, string surname, string address, string city, string phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            City = city;
            PhoneNumber = phoneNumber;
        }
        public Person(string name, string surname, string address, string city, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            Address = address;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}
