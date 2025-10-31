using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerLibrary.Models
{
    public class ZelisTrainerEFDBContext : DbContext
    {
        public ZelisTrainerEFDBContext() { }
        public ZelisTrainerEFDBContext(DbContextOptions<ZelisTrainerEFDBContext> options) : base(options) { }
        public DbSet<Trainer> Trainers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; Database=BlazorTrainerDB; integrated security=true");
        }
    }
}
