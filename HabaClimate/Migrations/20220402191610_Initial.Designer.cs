﻿// <auto-generated />
using System;
using HabaClimate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HabaClimate.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220402191610_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HabaClimate.Data.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<string>("LongDesc")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShortDesc")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("HabaClimate.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.Property<string>("Desc")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HabaClimate.Data.Models.Good", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<int?>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<string>("LongDesc")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ShortDesc")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Good");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Good");
                });

            modelBuilder.Entity("HabaClimate.Data.Models.AirConditioner", b =>
                {
                    b.HasBaseType("HabaClimate.Data.Models.Good");

                    b.Property<string>("EnergyEfficiencyClass")
                        .HasColumnType("text");

                    b.Property<bool>("IsInverter")
                        .HasColumnType("boolean");

                    b.Property<int>("SquareRoom")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("AirConditioner");
                });

            modelBuilder.Entity("HabaClimate.Data.Models.Good", b =>
                {
                    b.HasOne("HabaClimate.Data.Models.Brand", "Brand")
                        .WithMany("Goods")
                        .HasForeignKey("BrandId");

                    b.HasOne("HabaClimate.Data.Models.Category", "Category")
                        .WithMany("Goods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HabaClimate.Data.Models.Brand", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("HabaClimate.Data.Models.Category", b =>
                {
                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
