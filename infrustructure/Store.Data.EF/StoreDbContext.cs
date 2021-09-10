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
                                    Name = "Батончик Snickers Super з арахісом у молочному шоколаді",
                                    Price = 17.2m,
                                    Category = "Сладости",
                                    Image= "https://gotoshop.ua/img/p/2020/09/121032/1834638-121032-batonchik-snickers-super-z-arakhisom-u-molochnomu-shokoladi-1125g.jpg?t=t1599687385",
                                    Volume = "112,5г"
                                },
                                new ProductDto
                                {
                                    Id = 2,
                                    Articul = "5232178",
                                    Name = "Вода мінеральна «Моршинська» негазована",
                                    Price = 7.8m,
                                    Category = "Напитки",
                                    Image = "https://www.morshynska.ua/images/products/bottle/negaz/pet_033.png",
                                    Volume = "0,5л"
                                },
                                new ProductDto
                                {
                                    Id = 3,
                                    Articul = "7895030",
                                    Name = "Цукерки Raffaello",
                                    Price = 9.5m,
                                    Category = "Сладости",
                                    Image = "https://market.rukavychka.ua/image/cache/catalog/tovaru/cukerki-rafaello-150g-tm-ferrero-507030201-700x500.jpg",
                                    Volume = "150г"
                                },
                                new ProductDto
                                {
                                    Id = 4,
                                    Articul = "0013872",
                                    Name = "Сік Sandora апельсиновий",
                                    Price = 5.2m,
                                    Category = "Напитки",
                                    Image = "https://img.fozzyshop.com.ua/rivne/25416-large_default/sok-sandora-apelsinovyj-05l.jpg",
                                    Volume = "1л"
                                },
                                new ProductDto
                                {
                                    Id = 5,
                                    Articul = "8999741",
                                    Name = "Напій Coca-Cola",
                                    Price = 8.1m,
                                    Category = "Напитки",
                                    Image = "https://www.korzyna.com/img/600/744/resize/6/9/694510DSCF8905.jpg",
                                    Volume = "1л"
                                },
                                new ProductDto
                                {
                                    Id = 6,
                                    Articul = "9805246",
                                    Name = "Напій енергетичний Red Bull",
                                    Price = 17.54m,
                                    Category = "Напитки",
                                    Image = "https://www.korzyna.com/img/600/744/resize/5/2/520407DSCF6788.jpg",
                                    Volume = "0,5л"
                                },
                                new ProductDto
                                {
                                    Id = 7,
                                    Articul = "0018539",
                                    Name = "Напій Fanta Orange",
                                    Price = 24.7m,
                                    Category = "Напитки",
                                    Image = "https://images.ua.prom.st/3078569493_w700_h500_gazirovannyj-napitok-fanta.jpg",
                                    Volume = "1л"
                                },
                                new ProductDto
                                {
                                    Id = 8,
                                    Articul = "4396524",
                                    Name = "Сир Premialle «Фета» 45%",
                                    Price = 51.99m,
                                    Category = "Сыр",
                                    Image = "https://img2.zakaz.ua/food.1612550279.ad72436478c_2021-02-07_Tatyana_L/food.1612550279.SNCPSG10.obj.0.1.jpg.oe.jpg.pf.jpg.350nowm.jpg.350x.jpg",
                                    Volume = "230г"
                                },
                                new ProductDto
                                {
                                    Id = 9,
                                    Articul = "4028609",
                                    Name = " Яйце шоколадне Kinder «Сюрприз»",
                                    Price = 24.59m,
                                    Category = "Сладости",
                                    Image = "https://www.i-igrushki.ru/upload/iblock/351/351d149b382875999294dcd2ca848117.jpg",
                                    Volume = "20г"
                                },
                                new ProductDto
                                {
                                    Id = 10,
                                    Articul = "5745016",
                                    Name = "Гумка жувальна Orbit Tabs «М'ята»",
                                    Price =10.39m ,
                                    Category = "Сладости",
                                    Image = "https://images.ua.prom.st/2217550375_zhevatelnaya-rezinka-orbit.jpg",
                                    Volume = "27г"
                                },
                                new ProductDto
                                {
                                    Id = 11,
                                    Articul = "9002917",
                                    Name = "Батончик Nestle Lion",
                                    Price = 7.8m,
                                    Category = "Сладости",
                                    Image = "https://gastronom.com.ua/images/sets/803_av.jpg",
                                    Volume= "42г"
                                }
                                );
            });
        }
    }
}
