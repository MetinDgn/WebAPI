using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        //public int DepartmentId { get; set; }
        //public string UserName { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Address { get; set; }
        //public string Description { get; set; }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserId).HasColumnName("Id");
            builder.Property(x => x.DepartmentId).HasColumnName("DepartmentId");
            builder.Property(x => x.UserName).HasColumnName("UserName");
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.Address).HasColumnName("Address");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.HasKey(x => x.UserId);
            builder.ToTable(@"Users", "dbo");
        }
    }
}
