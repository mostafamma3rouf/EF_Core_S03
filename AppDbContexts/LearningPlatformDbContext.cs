using EF_Core_S03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_S03.AppDbContexts
{
    internal class LearningPlatformDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; DataBase = LearningPlatform; Trusted_Connection = true; TrustServerCertificate = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LearningPlatformDbContext).Assembly);
        }

        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
