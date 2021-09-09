﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data.EF;

namespace Store.Data.EF.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20210909162709_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProdStore.Data.OrderDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProdStore.Data.OrderItemDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ProdStore.Data.ProductDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Articul")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Articul = "6589100",
                            Category = "Sweet",
                            Image = "/img/1.jpg",
                            Name = "Cake",
                            Price = 17.2m
                        },
                        new
                        {
                            Id = 2,
                            Articul = "5232178",
                            Category = "Liquid",
                            Image = "/img/1.jpg",
                            Name = "Water",
                            Price = 7.8m
                        },
                        new
                        {
                            Id = 3,
                            Articul = "7895030",
                            Category = "Sweet",
                            Image = "/img/1.jpg",
                            Name = "Candies",
                            Price = 9.5m
                        },
                        new
                        {
                            Id = 4,
                            Articul = "0013872",
                            Category = "Liquid",
                            Image = "/img/1.jpg",
                            Name = "Juice",
                            Price = 5.2m
                        },
                        new
                        {
                            Id = 5,
                            Articul = "8999741",
                            Category = "Fruit",
                            Image = "/img/1.jpg",
                            Name = "Oranje",
                            Price = 8.1m
                        },
                        new
                        {
                            Id = 6,
                            Articul = "9805246",
                            Category = "Liquid",
                            Image = "/img/1.jpg",
                            Name = "Pepsi",
                            Price = 17.54m
                        },
                        new
                        {
                            Id = 7,
                            Articul = "0018539",
                            Category = "Liquid",
                            Image = "/img/1.jpg",
                            Name = "Fanta",
                            Price = 24.7m
                        },
                        new
                        {
                            Id = 8,
                            Articul = "4396524",
                            Category = "Cheeze",
                            Image = "/img/1.jpg",
                            Name = "Mozzarella",
                            Price = 51.99m
                        },
                        new
                        {
                            Id = 9,
                            Articul = "4028609",
                            Category = "Sweet",
                            Image = "/img/1.jpg",
                            Name = "Snikers",
                            Price = 24.59m
                        },
                        new
                        {
                            Id = 10,
                            Articul = "5745016",
                            Category = "Sweet",
                            Image = "/img/1.jpg",
                            Name = "Orbit",
                            Price = 10.39m
                        },
                        new
                        {
                            Id = 11,
                            Articul = "9002917",
                            Category = "Sweet",
                            Image = "/img/1.jpg",
                            Name = "lion",
                            Price = 7.8m
                        });
                });

            modelBuilder.Entity("ProdStore.Data.RoleDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("ProdStore.Data.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Password = "123456",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("ProdStore.Data.OrderItemDto", b =>
                {
                    b.HasOne("ProdStore.Data.OrderDto", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ProdStore.Data.UserDto", b =>
                {
                    b.HasOne("ProdStore.Data.RoleDto", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProdStore.Data.OrderDto", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ProdStore.Data.RoleDto", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
