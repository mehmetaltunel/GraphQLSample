using GraphQL.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DataAcess.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                Name = "Mehmet",
                Roll = "1001",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            },
            new Student
            {
                Id = 2,
                Name = "Ahmet",
                Roll = "1002",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            },
            new Student
            {
                Id = 3,
                Name = "Maho",
                Roll = "1003",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            },
            new Student
            {
                Id = 4,
                Name = "Ümido",
                Roll = "1004",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            });
        }
    }
}
