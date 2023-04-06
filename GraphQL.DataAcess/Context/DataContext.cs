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
        public DbSet<Category> Categories { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Alkollü İçecek",
                Description = "alkol var",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            },
            new Category
            {
                Id = 2,
                Name = "Alkolsüz İçecek",
                Description = "alkol yok",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            },
            new Category
            {
                Id = 3,
                Name = "Gazlı İçecek",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            },
            new Category
            {
                Id = 4,
                Name = "Meyve Suları",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            });
        }
    }
}
