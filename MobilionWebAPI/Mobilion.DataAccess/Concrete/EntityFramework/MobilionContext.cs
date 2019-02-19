using Microsoft.EntityFrameworkCore;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.DataAccess.Concrete.EntityFramework
{
    public class MobilionContext :DbContext
    {
        public MobilionContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=MobilionAPI; Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DataAccess.Concrete.EntityFramework.Mappings.UserMap());
            modelBuilder.ApplyConfiguration(new DataAccess.Concrete.EntityFramework.Mappings.DepartmentMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}
