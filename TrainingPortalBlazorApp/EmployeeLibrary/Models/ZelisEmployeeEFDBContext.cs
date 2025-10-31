using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeLibrary.Models
{
    public class ZelisEmployeeEFDBContext : DbContext 
    {
        public ZelisEmployeeEFDBContext() { }
        public ZelisEmployeeEFDBContext(DbContextOptions<ZelisEmployeeEFDBContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; Database=BlazorEmpDB; integrated security=true");
        }

    }
}
