using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Product>().Property(p => p.Title)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description)
               .HasMaxLength(500);
            modelBuilder.Entity<Product>().Property(p => p.Quantity)
              .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price)
              .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.CreationDate);

            //ProductImage
            modelBuilder.Entity<ProductImage>().Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<ProductImage>().Property(p => p.Path)
               .HasMaxLength(200);

            //User
            modelBuilder.Entity<User>().Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Password)
               .HasMaxLength(50)
               .IsRequired();

            //roles
            modelBuilder.Entity<Role>().Property(p => p.Name)
               .HasMaxLength(50)
               .IsRequired();
            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
