﻿// <auto-generated />
using BakeryApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BakeryApp.Migrations
{
    [DbContext(typeof(BakeryContext))]
    partial class BakeryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BakeryApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnName("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A scrumptious mini-carrot cake encrusted with sliced almonds",
                            ImageName = "carrot_cake.jpg",
                            Name = "Carrot Cake",
                            Price = 8.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "A delicious lemon tart with fresh meringue cooked to perfection",
                            ImageName = "lemon_tart.jpg",
                            Name = "Lemon Tart",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Delectable vanilla and chocolate cupcakes",
                            ImageName = "cupcakes.jpg",
                            Name = "Cupcakes",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fresh baked French-style bread",
                            ImageName = "bread.jpg",
                            Name = "Bread",
                            Price = 1.49m
                        },
                        new
                        {
                            Id = 5,
                            Description = "A glazed pear tart topped with sliced almonds and a dash of cinnamon",
                            ImageName = "pear_tart.jpg",
                            Name = "Pear Tart",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 6,
                            Description = "Rich chocolate frosting cover this chocolate lover's dream",
                            ImageName = "chocolate_cake.jpg",
                            Name = "Chocolate Cake",
                            Price = 8.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
