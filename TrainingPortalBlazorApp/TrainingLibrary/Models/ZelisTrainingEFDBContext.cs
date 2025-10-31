using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    public class ZelisTrainingEFDBContext : DbContext
    {
        public ZelisTrainingEFDBContext() { }
        public ZelisTrainingEFDBContext(DbContextOptions<ZelisTrainingEFDBContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; Database=BlazorTrainingDB; integrated security=true");
        }

    }
}
