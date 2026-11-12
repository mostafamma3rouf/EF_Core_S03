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
    internal class StudentConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            // Primary Key
            builder.HasKey(S => S.Id);

            // Columns
            builder.Property(S => S.FullName).IsRequired().HasMaxLength(150);
            builder.Property(S => S.Email).IsRequired().HasMaxLength(200);
            builder.Property(S => S.DateOfBirth).IsRequired();
        }
    }
}
