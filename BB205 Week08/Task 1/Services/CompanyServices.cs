using EntityFramework.DAL;
using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    internal class CompanyServices
    {
        AppDbContext dbContext = new AppDbContext();

        public void Add(Company company)
        {
            dbContext.Add(company);
            dbContext.SaveChanges();
        }
        public void Delete(int Id)
        {
            var removedCompany = dbContext.Companies.ToList().Find(x => x.Id == Id);
            dbContext.Remove(removedCompany);
            dbContext.SaveChanges();
        }
        public void Update(Company company)
        {
            var updatedCompany = dbContext.Companies.FirstOrDefault(x => x.Id == company.Id);
            updatedCompany.Title = company.Title;
            dbContext.Update(updatedCompany);
            dbContext.SaveChanges();
        }

        public List<Company> GetAll()
        {
            return dbContext.Companies.ToList();
        }
    }
}
