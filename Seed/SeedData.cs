using EF_Core_S03.Models;
using Microsoft.EntityFrameworkCore;
using EF_Core_S03.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_S03.Seed
{
    internal class SeedData
    {
        public static void SeedStudents(LearningPlatformDbContext context)
        {
            if (context.Students.Any())
            {
                Console.WriteLine("  The Students table is not empty, nothing to add.");
                return;
            }

            var students = new List<Students>
        {
            new Students { FullName = "Ali Mohamed",   Email = "ali@mail.com",     DateOfBirth = new DateTime(2000, 5, 14) },
            new Students { FullName = "Mona Ibrahim",  Email = "mona@mail.com",    DateOfBirth = new DateTime(1999, 11, 2) },
            new Students { FullName = "Youssef Tarek", Email = "youssef@mail.com", DateOfBirth = new DateTime(2001, 3, 20) },
            new Students { FullName = "Nour Adel",     Email = "nour@mail.com",    DateOfBirth = new DateTime(1998, 7, 9)  },
            new Students { FullName = "Hana Samir",    Email = "hana@mail.com",    DateOfBirth = new DateTime(2002, 1, 25) }
        };

            context.Students.AddRange(students);

            if (!TrySave(context)) return;

            Console.WriteLine($"  {students.Count} students added.");
        }

        // Enrollments (8): 3 Active, 3 Completed, 2 Dropped
        public static void SeedEnrollments(LearningPlatformDbContext context)
        {
            if (context.Enrollments.Any())
            {
                Console.WriteLine("  The Enrollments table is not empty, nothing to add.");
                return;
            }

            if (context.Students.Count() < 5 || context.Courses.Count() < 6)
            {
                Console.WriteLine("  Students or courses are missing. Apply the migrations and seed the students first.");
                return;
            }

            var enrollments = new List<Enrollment>
        {
            // ---------- Active ----------
            new Enrollment { StudentId = 1, CourseId = 1, Status = EnrollmentStatus.Active,    ProgressPercentage = 25,  EnrollmentDate = new DateTime(2026, 11, 1) },
            new Enrollment { StudentId = 2, CourseId = 3, Status = EnrollmentStatus.Active,    ProgressPercentage = 50,  EnrollmentDate = new DateTime(2026, 11, 2) },
            new Enrollment { StudentId = 3, CourseId = 2, Status = EnrollmentStatus.Active,    ProgressPercentage = 70,  EnrollmentDate = new DateTime(2026, 11, 3) },
 
            // ---------- Completed (always 100%) ----------
            new Enrollment { StudentId = 4, CourseId = 1, Status = EnrollmentStatus.Completed, ProgressPercentage = 100, EnrollmentDate = new DateTime(2026, 8, 1) },
            new Enrollment { StudentId = 5, CourseId = 2, Status = EnrollmentStatus.Completed, ProgressPercentage = 100, EnrollmentDate = new DateTime(2026, 7, 1) },
            new Enrollment { StudentId = 1, CourseId = 3, Status = EnrollmentStatus.Completed, ProgressPercentage = 100, EnrollmentDate = new DateTime(2026, 9, 1) },
 
            // ---------- Dropped (low progress) ----------
            new Enrollment { StudentId = 2, CourseId = 5, Status = EnrollmentStatus.Dropped,   ProgressPercentage = 15,  EnrollmentDate = new DateTime(2026, 10, 30) },
            new Enrollment { StudentId = 3, CourseId = 5, Status = EnrollmentStatus.Dropped,   ProgressPercentage = 0,   EnrollmentDate = new DateTime(2026, 11, 5) }
        };

            context.Enrollments.AddRange(enrollments);

            if (!TrySave(context)) return;

            Console.WriteLine($"  {enrollments.Count} enrollments added.");
        }

        private static bool TrySave(LearningPlatformDbContext context)
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"  Could not save the seed data: {ex.InnerException?.Message ?? ex.Message}");
                return false;
            }
        }
    }
}
