﻿

using Kontakt.App.Models;
using Kontakt.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kontakt.App.Context
{
    public class KontaktDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountCategory> DiscountsCategories { get; set; }
        public DbSet<DiscountofProduct> DiscountofProducts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DiscountImage> DiscountsImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CategoryBrand> categoryBrands { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProductCredit> ProductCredits { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public KontaktDbContext(DbContextOptions<KontaktDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.MainProperties, mp =>
                {
                    mp.ToTable("ProductMainProperties"); // Specify the table name
                    mp.Property<string>("Key").HasColumnName("PropertyKey");
                    mp.Property<string>("Value").HasColumnName("PropertyValue");
                });

            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.OtherProperties, op =>
                {
                    op.ToTable("ProductOtherProperties"); // Specify the table name
                    op.Property<string>("Key").HasColumnName("PropertyKey");
                    op.Property<string>("Value").HasColumnName("PropertyValue");
                });

            modelBuilder.Entity<Product>()
               .HasOne(p => p.DiscountofProduct)
                    .WithMany()
             .HasForeignKey(p => p.DiscountofProductId)
            .OnDelete(DeleteBehavior.NoAction);




        }

    }
}
