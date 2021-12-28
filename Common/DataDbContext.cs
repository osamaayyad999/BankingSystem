using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DataDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountD> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountBalance> AccountBalances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;Database=BankDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            //optionsBuilder.UseSqlServer("Data Source = SD-WIN10-OAYYAD; Database=BankDbdll; Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

    }
}
