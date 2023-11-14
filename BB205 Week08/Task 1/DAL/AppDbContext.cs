using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DAL
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=LAPTOP-15LA12GG;database=LimeFlixCompany;trusted_connection=true;integrated security=true;encrypt=false");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
