using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Model
{
    public partial class MyDemoDbContext : DbContext
    {
        public MyDemoDbContext()
        {

        }
        public MyDemoDbContext(DbContextOptions<MyDemoDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserProfile> userProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("userProfiles",schema:"dbo").StartsAt(0).IncrementsBy(1);
            modelBuilder.Entity<Employee>().HasOne(e => e.Department).WithMany(x => x.Employee).HasForeignKey(d => d.FkDeptId);
            modelBuilder.Entity<UserProfile>().HasOne(u => u.Role).WithMany(x => x.userProfiles).HasForeignKey(r => r.FkRoleId);
        }
    }
}
