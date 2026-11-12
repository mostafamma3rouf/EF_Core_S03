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
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            // Composite Primary Key
            builder.HasKey(E => new { E.StudentId, E.CourseId});

            // Columns
            builder.Property(E => E.EnrollmentDate);
            builder.Property(E => E.ProgressPercentage).HasPrecision(10, 2);
            builder.Property(E => E.Status);
            builder.Property(E => E.FinalGrade).HasPrecision(10, 2);

            // Relationships
            // Student -> Enrollments (1:M)
            builder.HasOne(E => E.Student)
                   .WithMany(S => S.Enrollments)
                   .HasForeignKey(E => E.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Course -> Enrollments (1:M)
            builder.HasOne(E => E.Course)
                   .WithMany(C => C.Enrollments)
                   .HasForeignKey(E => E.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
