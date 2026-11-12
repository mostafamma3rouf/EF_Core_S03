using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_S03.Models
{
    internal class Instructors
    {
        // Properties
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? ShortBio { get; set; } // Optional
        public DateTime JoinedDate { get; set; }

        // Navigation Properties
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();

    }
}
