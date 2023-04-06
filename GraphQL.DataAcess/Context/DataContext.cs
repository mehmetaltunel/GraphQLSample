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
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Meyve Suları",
                Description = "meyve suyu",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            },
            new Category
            {
                Id = 2,
                Name = "Gazlı İçecek",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedDate = null
            });
            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 Id = 1,
                 Code = "CP2",
                 Name = "Cappy Karışık",
                 CategoryId = 1,
                 Description = "capy ailesine ait karışık meyve suyu",
                 Price = 14.50F,
                 ListingPrice = 20F
             },
             new Product
             {
                 Id = 2,
                 Code = "CC1",
                 Name = "Coca Cola 1 Litre",
                 CategoryId = 2,
                 Price = 20.50F,
                 ListingPrice = 25F
             },
              new Product
              {
                  Id = 3,
                  Code = "CC1",
                  Name = "Coca Cola 2.5 Litre",
                  CategoryId = 2,
                  Price = 30.50F,
                  ListingPrice = 35F
              },
             new Product
             {
                 Id = 4,
                 Code = "F1",
                 Name = "Fruko",
                 CategoryId = 1,
                 Description = "fruko gazoz",
                 Price = 23.50F,
                 ListingPrice = 28F
             },
             new Product
             {
                 Id = 5,
                 Code = "CP1",
                 Name = "Cappy Şeftali",
                 CategoryId = 1,
                 Description = "capy ailesine ait şeftalili meyve suyu",
                 Price = 14.50F,
                 ListingPrice = 20F
             });
        }
    }
}
