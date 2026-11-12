using EF_Core_S03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_S03.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Categories> builder)
        {
            // Primary Key
            builder.HasKey(C => C.Id);

            // Columns
            builder.Property(C => C.CategoryName).IsRequired().HasMaxLength(100);
            builder.Property(C => C.Description).HasMaxLength(500);

            // Relationship
            // Category -> Sub-categories (1:M)
            builder.HasOne(C => C.ParentCategory)
                   .WithMany(C => C.SubCategories)
                   .HasForeignKey(C => C.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            SeedData(builder);
        }
        private static void SeedData(EntityTypeBuilder<Categories> builder)
        {
            builder.HasData(
                // Level 1 (top-level, no parent)
                new Categories { Id = 1, CategoryName = "Programming", Description = "All programming courses.", ParentCategoryId = null },
                new Categories { Id = 6, CategoryName = "Design", Description = null, ParentCategoryId = null },

                // Level 2
                new Categories { Id = 2, CategoryName = "Backend", Description = "Server-side development.", ParentCategoryId = 1 },
                new Categories { Id = 4, CategoryName = "Databases", Description = "Relational and SQL databases.", ParentCategoryId = 1 },

                // Level 3
                new Categories { Id = 3, CategoryName = "ASP.NET", Description = null, ParentCategoryId = 2 },
                new Categories { Id = 5, CategoryName = "SQL Server", Description = "Microsoft SQL Server.", ParentCategoryId = 4 });
        }
    }
}
