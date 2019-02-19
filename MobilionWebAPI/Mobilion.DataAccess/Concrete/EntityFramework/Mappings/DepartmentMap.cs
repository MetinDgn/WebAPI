using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.DataAccess.Concrete.EntityFramework.Mappings
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DepartmentId);
            builder.Property(x => x.DepartmentId).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.ToTable(@"Departments", "dbo");
        }
    }
}
