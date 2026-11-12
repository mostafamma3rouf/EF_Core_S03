using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_S03.Models
{
    internal class Courses
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; } // Optional
        public decimal Price { get; set; }
        public Level level { get;set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; } // Optional

        // Functional Properties
        public void Publish()
        {
            IsPublished = true;
            PublishedDate = DateTime.Now;
        }

        public void Enroll(Students Student)
        {
            if (!IsPublished)
                throw new Exception("Only published courses accept enrollments.");

            Enrollments.Add(new Enrollment { Student = Student });
        }

        // Navigation Properties
        public int InstructorId { get; set; }
        public Instructors Instructor { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
