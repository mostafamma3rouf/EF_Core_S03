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
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructors>
    {
        public void Configure(EntityTypeBuilder<Instructors> builder)
        {
            // Primary Key
            builder.HasKey(I => I.Id);

            // Columns
            builder.Property(I => I.FullName).IsRequired().HasMaxLength(150);
            builder.Property(I => I.Email).IsRequired().HasMaxLength(250);
            builder.Property(I => I.ShortBio).HasMaxLength(500);
            builder.Property(I => I.JoinedDate).IsRequired();

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Instructors> builder)
        {
            builder.HasData(
            new Instructors
            {
                Id = 1,
                FullName = "Ahmed Hassan",
                Email = "ahmed.hassan@example.com",
                ShortBio = "Backend developer with 10 years of experience in C# and ASP.NET.",
                JoinedDate = new DateTime(2024, 3, 1)
            },
            new Instructors
            {
                Id = 2,
                FullName = "Sara Mostafa",
                Email = "sara.mostafa@example.com",
                ShortBio = null,                                       // Bio is optional
                JoinedDate = new DateTime(2024, 9, 15)
            },
            new Instructors
            {
                Id = 3,
                FullName = "Mahmoud Fathy",
                Email = "mahmoud.fathy@example.com",
                ShortBio = "UI/UX designer and software architect.",
                JoinedDate = new DateTime(2025, 2, 10)
            });
        }
    }
}