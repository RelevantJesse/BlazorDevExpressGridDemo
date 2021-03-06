using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDevExpressGridDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDevExpressGridDemo
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Dep1" },
                new Department { Id = 2, Name = "Dep2" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Role1" },
                new Role { Id = 2, Name = "Role2" }
            );
        }
    }
}
