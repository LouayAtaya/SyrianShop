using Microsoft.EntityFrameworkCore;
using SyrianShop.EntityConfigurations;
using SyrianShop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.dataContexts
{
    public class SyrianShopContext: DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }


        public SyrianShopContext(DbContextOptions<SyrianShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Product
            modelBuilder.ApplyConfiguration(new ProductConfiguration());


            //ProductImage
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());


            //User
            modelBuilder.ApplyConfiguration(new UserConfiguration());


            //roles
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
