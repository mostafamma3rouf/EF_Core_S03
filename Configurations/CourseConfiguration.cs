using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EF_Core_S03.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_S03.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            // Primary Key
            builder.HasKey(C => C.Id);

            // Columns
            builder.Property(C => C.Title).IsRequired().HasMaxLength(200);
            builder.Property(C => C.Description).HasMaxLength(1000);
            builder.Property(C => C.Price).HasPrecision(10, 2);
            builder.Property(C => C.level).HasMaxLength(20);
            builder.Property(C => C.IsPublished);
            builder.Property(C => C.PublishedDate);

            // Relationships
            // Instructor -> Courses (1:M)
            builder.HasOne(C => C.Instructor)
                   .WithMany(I => I.Courses)
                   .HasForeignKey(C => C.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Category -> Courses (1:M)
            builder.HasOne(C => C.Category)
                   .WithMany(C => C.Courses)
                   .HasForeignKey(C => C.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Courses> builder)
        {
            builder.HasData(
                new Courses
                {
                    Id = 1,
                    Title = "C# Fundamentals",
                    Description = "Learn the basics of C# from scratch.",
                    level = Level.Beginner,
                    Price = 49.99m,
                    IsPublished = true,
                    PublishedDate = new DateTime(2026, 1, 10, 9, 0, 0, DateTimeKind.Utc),
                    InstructorId = 1,
                    CategoryId = 1
                },
                new Courses
                {
                    Id = 2,
                    Title = "ASP.NET Core Web API",
                    Description = "Build REST APIs with ASP.NET Core and EF Core.",
                    level = Level.Intermediate,
                    Price = 79.99m,
                    IsPublished = true,
                    PublishedDate = new DateTime(2026, 2, 1, 9, 0, 0, DateTimeKind.Utc),
                    InstructorId = 1,
                    CategoryId = 3
                },
                new Courses
                {
                    Id = 3,
                    Title = "SQL Server Essentials",
                    Description = null,
                    level = Level.Beginner,
                    Price = 39.99m,
                    IsPublished = true,
                    PublishedDate = new DateTime(2026, 2, 15, 9, 0, 0, DateTimeKind.Utc),
                    InstructorId = 2,
                    CategoryId = 5
                },
                new Courses
                {
                    Id = 4,
                    Title = "Advanced EF Core",
                    Description = "Performance, migrations and advanced mapping.",
                    level = Level.Advanced,
                    Price = 99.99m,
                    IsPublished = false,
                    PublishedDate = null,              // draft
                    InstructorId = 2,
                    CategoryId = 4
                },
                new Courses
                {
                    Id = 5,
                    Title = "UI/UX Principles",
                    Description = "Design clean and usable interfaces.",
                    level = Level.Intermediate,
                    Price = 59.99m,
                    IsPublished = true,
                    PublishedDate = new DateTime(2026, 3, 5, 9, 0, 0, DateTimeKind.Utc),
                    InstructorId = 3,
                    CategoryId = 6
                },
                new Courses
                {
                    Id = 6,
                    Title = "Microservices Architecture",
                    Description = "Design and split systems into services.",
                    level = Level.Advanced,
                    Price = 119.99m,
                    IsPublished = false,
                    PublishedDate = null,              // draft
                    InstructorId = 3,
                    CategoryId = 2
                });
        }
    }
}
