using ConsoleApp3;
using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    namespace ConsoleApp2
    {
        internal class Store
        {
            private string _name;
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (value.Length >= 3)
                    {
                        _name = value;
                    }
                    else
                    {
                        Console.WriteLine("Store name should be longer than 3 character!");
                    }
                }
            }
            public Phone[] Phones = new Phone[0];

            public void AddPhone(Phone phone)
            {
                bool idCheck = false;
                for (int i = 0; i < Phones.Length; i++)
                {
                    if (Phones[i].Name == phone.Name)
                    {
                        idCheck = true;
                        break;
                    }
                }
                if (!idCheck) 
                {
                    Phone[] newPhones = new Phone[Phones.Length + 1];

                    for (int i = 0; i < Phones.Length; i++)
                    {
                        newPhones[i] = Phones[i];
                    }

                    newPhones[newPhones.Length - 1] = phone;
                    Phones = newPhones;
                    Console.WriteLine("\nNew Phone added to Data\n");
                }
                else
                {
                    Console.WriteLine($"There is such a phone in Data");
                }
            }

            public Phone[] ShowAllPhone()
            {
                return Phones;
            }

            public void ShowInfo(int phoneId)
            {
                for (int i = 0; i < Phones.Length; i++)
                {
                    if (Phones[i].Id == phoneId)
                    {
                        Console.WriteLine($"ID: {phoneId} Phone information:");
                        Console.WriteLine($"\n{Phones[i].Id}. Phone information:\n" +
                            $"Phone name: {Phones[i].PhoneName}\n" +
                            $"Phone brand name: {Phones[i].BrandName}\n" +
                            $"Phone price: {Phones[i].Price}\n" +
                            $"Phone count in Data: {Phones[i].Count}");
                        break;
                    }
                }
            }
            public void RemovePhone(int phoneId)
            {
                bool idCheck = false;
                for (int i = 0; i < Phones.Length; i++)
                {
                    if (Phones[i].Id == phoneId)
                    {
                        idCheck = true;
                        break;
                    }
                }
                if (idCheck)
                {
                    Phone[] newPhones = new Phone[Phones.Length - 1];
                    int index = 0;

                    for (int i = 0; i < Phones.Length; i++)
                    {
                        if (Phones[i].Id != phoneId)
                        {
                            newPhones[index] = Phones[i];
                            index++;
                        }
                    }
                    Phones = newPhones;
                    Console.WriteLine($"\n{phoneId}. Phone has been removed from Data");
                }
                else
                {
                    Console.WriteLine($"\nThere is no such a Phone in Data!");
                }
            }
            public void ShowPhoneForPrice(double minPrice, double maxPrice)
            {
                Console.WriteLine("-----------------------------------------");
                for (int i = 0; i < Phones.Length; i++)
                    {
                        if (Phones[i].Price >= minPrice && Phones[i].Price <= maxPrice)
                        {
                        Console.WriteLine($"\n{Phones[i].Id}. Phone information:\n" +
                            $"Phone name: {Phones[i].PhoneName}\n" +
                            $"Phone brand name: {Phones[i].BrandName}\n" +
                            $"Phone price: {Phones[i].Price}\n" +
                            $"Phone count in Data: {Phones[i].Count}");
                        }
                    }
                Console.WriteLine("\n-----------------------------------------");
        }

        }
    }
