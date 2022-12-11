﻿// <auto-generated />
using System;
using MagnetronAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagnetronAPI.Migrations
{
    [DbContext(typeof(MagnetonContext))]
    partial class MagnetonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagnetronAPI.Model.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DishId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DishId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("MagnetronAPI.Model.Prep", b =>
                {
                    b.Property<int>("PrepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrepId"));

                    b.Property<int?>("DishId")
                        .HasColumnType("int");

                    b.Property<string>("Mode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("Temp")
                        .HasColumnType("int");

                    b.Property<int?>("Watt")
                        .HasColumnType("int");

                    b.HasKey("PrepId");

                    b.HasIndex("DishId");

                    b.ToTable("Preps");
                });

            modelBuilder.Entity("MagnetronAPI.Model.Prep", b =>
                {
                    b.HasOne("MagnetronAPI.Model.Dish", null)
                        .WithMany("Preps")
                        .HasForeignKey("DishId");
                });

            modelBuilder.Entity("MagnetronAPI.Model.Dish", b =>
                {
                    b.Navigation("Preps");
                });
#pragma warning restore 612, 618
        }
    }
}
