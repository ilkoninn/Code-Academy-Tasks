using EntityFramework.Models;
using EntityFramework.Services;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonServices services = new PersonServices();

            // Add Section
            Person person1 = new Person("Miraga", "Eliyev", "Nizami rayonu", "Baku", "070 320 00 00");
            services.Add(person1);

            // Delete Section
            services.Delete(3);

            // Update Section
            Person person3 = new Person(6, "Miraga", "Eliyev", "Nizami rayonu", "Baku", "070 320 00 00");
            services.Update(person3);

            //Get All Section
            var persons = services.GetAll();

            Console.WriteLine("\tPerson table information\n");
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Id}|{person.Name}|{person.Surname}|{person.PhoneNumber}|{person.Address}|{person.City}");
            }

            CompanyServices companyServices = new CompanyServices();

            // Add Section
            Company company1 = new Company("LimeFlix");
            companyServices.Add(company1);

            // Delete Section
            companyServices.Delete(1);

            // Update Section
            Company company2 = new Company(1, "LabHome");
            companyServices.Update(company2);

            // Get All Section
            var companies = companyServices.GetAll();
            Console.WriteLine("\tCompany table information\n");

            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Id}|{company.Title}");
            }

        }
    }
}
