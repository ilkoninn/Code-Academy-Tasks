using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Phone : Store
    {
        private string _phonename;
        public string PhoneName
        {
            get
            {
                return _phonename;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _phonename = value;
                }
                else
                {
                    Console.WriteLine("Store name should be longer than 3 character!");
                }
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("ID should be a positive number");
                }
                else
                {
                    _id = value;
                }
            }
        }
        private string _brandname
        public string BrandName 
        {
            get
            {
                return _brandname;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _brandname = value;
                }
                else
                {
                    Console.WriteLine("Store name should be longer than 3 character!");
                }
            }
        }
        public double Price { get; set; }
        public int Count { get; set; }

        public Phone()
        {

        }
        public Phone(string name, string brandName, double price, int count, int phoneId)
        {
            PhoneName = name;
            BrandName = brandName;
            Price = price;
            Count = count;
            Id = phoneId;
        }
        
    }
}
