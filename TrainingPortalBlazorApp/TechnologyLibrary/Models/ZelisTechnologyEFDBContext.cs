using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechnologyLibrary.Models
{
    public class ZelisTechnologyEFDBContext : DbContext
    {
        public ZelisTechnologyEFDBContext() { }
        public ZelisTechnologyEFDBContext(DbContextOptions<ZelisTechnologyEFDBContext> options) : base(options) { }
        public DbSet<Technology> Technologies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; Database=BlazorTechDB; integrated security=true");
        }
    }
}
