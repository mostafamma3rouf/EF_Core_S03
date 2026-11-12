using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_S03.Models
{
    internal class Categories
    {
        // Properties
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; } // Optional

        // Navigation Property
        public int? ParentCategoryId { get; set; }
        public Categories ParentCategory { get; set; }
        public ICollection<Categories> SubCategories { get; set; } = new List<Categories>();
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}
