using Microsoft.EntityFrameworkCore;
using ProdStore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.EF
{
    public class StoreDbContext: DbContext
    {
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<OrderItemDto> OrderItems { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<RoleDto> Roles { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildProducts(modelBuilder);
            BuildOrderItems(modelBuilder);
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "123456";
            RoleDto adminRole = new RoleDto { Id = 1, Name = adminRoleName };
            RoleDto userRole = new RoleDto { Id = 2, Name = userRoleName };
            UserDto adminUser = new UserDto { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            modelBuilder.Entity<RoleDto>().HasData(new RoleDto[] { adminRole, userRole });
            modelBuilder.Entity<UserDto>().HasData(new UserDto[] { adminUser });

        }

   

        private static void BuildOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDto>(action =>
            {
                action.Property(dto => dto.Price).HasColumnType("money");
                action.HasOne(dto => dto.Order).WithMany(dto => dto.Items).IsRequired();
            });
        }

        private static void BuildProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDto>(action =>
            {
                action.Property(dto => dto.Articul).HasMaxLength(7).IsRequired();
                action.Property(dto => dto.Name).IsRequired();
                action.Property(dto => dto.Price).HasColumnType("money");
                action.Property(dto => dto.Category).IsRequired();
                action.HasData(
                                new ProductDto
                                {
                                    Id = 1,
                                    Articul = "6589100",
                                    Name = "Cake",
                                    Price = 17.2m,
                                    Category = "Sweet",
                                    Image= "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 2,
                                    Articul = "5232178",
                                    Name = "Water",
                                    Price = 7.8m,
                                    Category = "Liquid",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 3,
                                    Articul = "7895030",
                                    Name = "Candies",
                                    Price = 9.5m,
                                    Category = "Sweet",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 4,
                                    Articul = "0013872",
                                    Name = "Juice",
                                    Price = 5.2m,
                                    Category = "Liquid",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 5,
                                    Articul = "8999741",
                                    Name = "Oranje",
                                    Price = 8.1m,
                                    Category = "Fruit",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 6,
                                    Articul = "9805246",
                                    Name = "Pepsi",
                                    Price = 17.54m,
                                    Category = "Liquid",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 7,
                                    Articul = "0018539",
                                    Name = "Fanta",
                                    Price = 24.7m,
                                    Category = "Liquid",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 8,
                                    Articul = "4396524",
                                    Name = "Mozzarella",
                                    Price = 51.99m,
                                    Category = "Cheeze",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 9,
                                    Articul = "4028609",
                                    Name = "Snikers",
                                    Price = 24.59m,
                                    Category = "Sweet",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 10,
                                    Articul = "5745016",
                                    Name = "Orbit",
                                    Price =10.39m ,
                                    Category = "Sweet",
                                    Image = "/img/1.jpg"
                                },
                                new ProductDto
                                {
                                    Id = 11,
                                    Articul = "9002917",
                                    Name = "lion",
                                    Price = 7.8m,
                                    Category = "Sweet",
                                    Image = "/img/1.jpg"
                                }
                                );
            });
        }
    }
}
