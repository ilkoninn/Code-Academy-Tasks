using EntityFramework.DAL;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    internal class PersonServices
    {
        AppDbContext dbContext = new AppDbContext();

        public void Add(Person person)
        {
            dbContext.Add(person);
            dbContext.SaveChanges();
        }
        public void Delete(int Id)
        {
            var removedPerson = dbContext.Persons.ToList().Find(x => x.Id == Id);
            dbContext.Remove(removedPerson);
            dbContext.SaveChanges();
        }
        public void Update(Person person)
        {
            var updatedPerson = dbContext.Persons.FirstOrDefault(x => x.Id == person.Id);
            updatedPerson.Name = person.Name;
            updatedPerson.Surname = person.Surname;
            updatedPerson.Address = person.Address;
            updatedPerson.City = person.City;
            updatedPerson.PhoneNumber = person.PhoneNumber;
            dbContext.Update(updatedPerson);
            dbContext.SaveChanges();
        }

        public List<Person> GetAll()
        {
            return dbContext.Persons.ToList();
        }
    }
}
