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
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            if (!Departments.Any())
            {
                Departments.AddRange(new Department { Id = 1, Name = "Department1" }, new Department { Id = 2, Name = "Department2" });
            }

            if (!Roles.Any())
            {
                Roles.AddRange(new Role { Id = 1, Name = "Role1" }, new Role { Id = 2, Name = "Role2" });
            }

            SaveChanges();
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
