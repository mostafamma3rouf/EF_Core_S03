using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_S03.Models
{
    internal class Enrollment
    {
        // Properties
        public DateTime EnrollmentDate { get; set; }
        public decimal ProgressPercentage { get; set; }
        public EnrollmentStatus Status { get; set; }
        public decimal? FinalGrade { get; set; } // Optional

        // Functional Properties
        public void UpdateProgress(decimal Progress)
        {
            if (Progress < 0 || Progress > 100)
                throw new Exception("Progress must be between 0 and 100.");

            ProgressPercentage = Progress;

            if (Progress == 100)
                Status = EnrollmentStatus.Completed;
        }

        // Navigation Properties
        public int StudentId { get; set; }
        public Students Student { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
    }
}
