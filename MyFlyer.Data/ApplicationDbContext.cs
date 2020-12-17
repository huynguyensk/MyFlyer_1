using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFlyer.Model.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MyFlyer.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasIndex(p => p.Item_Id).IsUnique();
            modelBuilder.Entity<Flyer>().HasIndex(s => s.Url).IsUnique();
            modelBuilder.Entity<Cart>().HasIndex(s => s.UserName).IsUnique();
            modelBuilder.Entity<Wishlist>().HasIndex(s => s.UserName).IsUnique();
            //modelBuilder.Entity<Merchant>().HasIndex(s => s.Name).IsUnique();
            //modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Menu>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<MerchantCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.MerchantCategories)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<MerchantCategory>()
              .HasOne(x => x.Merchant)
              .WithMany(x => x.MerchantCategories)
              .HasForeignKey(x => x.MerchantId);


            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<Menu>().HasData(new List<Menu>
            {
                new Menu
                {
                    Id =1,
                    Name ="Home"
                },
                 new Menu
                {
                    Id =2,
                    Name ="About"
                },
                  new Menu
                {
                    Id =3,
                    Name ="Service"
                },
                   new Menu
                {
                    Id =4,
                    Name ="Contact"
                },
                   new Menu
                {
                    Id =5,
                    Name ="Login"
                },
                    new Menu
                {
                    Id =6,
                    Name ="Cart"
                }

            });
            modelBuilder.Entity<AppRole>().HasData(new List<AppRole>
            {
                new AppRole {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole {
                    Id = 2,
                    Name = "Staff",
                    NormalizedName = "STAFF"
                },
                new AppRole {
                    Id = 3,
                    Name = "User",
                    NormalizedName = "USER"
                }
            });
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1, // primary key
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAEKvOdqQb/eRx+WE3iCIOAnx24OhVMXmDt9CM0lts/RaP78ykRjUtE6YpiH8XBObFrg==",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new AppUser
                {
                    Id = 2, // primary key
                    UserName = "staff",
                    NormalizedUserName = "STAFF",
                    PasswordHash = "AQAAAAEAACcQAAAAEKvOdqQb/eRx+WE3iCIOAnx24OhVMXmDt9CM0lts/RaP78ykRjUtE6YpiH8XBObFrg==",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new AppUser
                {
                    Id = 3, // primary key
                    UserName = "user",
                    NormalizedUserName = "USER",
                    PasswordHash = "AQAAAAEAACcQAAAAEKvOdqQb/eRx+WE3iCIOAnx24OhVMXmDt9CM0lts/RaP78ykRjUtE6YpiH8XBObFrg==",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                }
            );
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>()
                {
                    RoleId = 1, // for admin username
                    UserId = 1  // for admin role
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 2, // for staff username
                    UserId = 2  // for staff role
                }
            );

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistProduct> WishlistProducts { get; set; }
        public DbSet<Flyer> Flyers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        //public DbSet<MerchantCategory> MerchantCategories { get; set; }
    }
}