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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Role1" },
                new Role { Id = 2, Name = "Role2" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new { Id = 1, Name = "Employee1", RoleId = 1 },
                new { Id = 2, Name = "Employee2", RoleId = 1 }
            );
        }
    }
}
