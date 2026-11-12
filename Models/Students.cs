using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_S03.Models
{
    internal class Students
    {
        // Properties
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Navigation Properties
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
