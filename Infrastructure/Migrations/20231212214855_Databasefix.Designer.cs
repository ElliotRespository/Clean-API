﻿// <auto-generated />
using System;
using Infrastructure.Database.SqlDataBases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    [Migration("20231212214855_Databasefix")]
    partial class Databasefix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Animalmodels.Dog", b =>
                {
                    b.Property<Guid>("animalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("animalID");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            animalID = new Guid("f5506f95-cd5a-4d60-8d59-5e6af39da8de"),
                            Name = "Kenta"
                        },
                        new
                        {
                            animalID = new Guid("5e41ca41-d37c-410e-a323-ebdcdf6a7c95"),
                            Name = "Knugen"
                        },
                        new
                        {
                            animalID = new Guid("70f25c4b-3db1-49f9-9686-f7b32b978dd1"),
                            Name = "Sjöberg"
                        },
                        new
                        {
                            animalID = new Guid("9739d76e-90c8-4ad5-92ce-21a6bbb7004b"),
                            Name = "Berra"
                        },
                        new
                        {
                            animalID = new Guid("12345678-1234-5678-1234-567812345671"),
                            Name = "DogTest1"
                        },
                        new
                        {
                            animalID = new Guid("12345678-1234-5678-1234-567812345672"),
                            Name = "DogTest2"
                        },
                        new
                        {
                            animalID = new Guid("12345678-1234-5678-1234-567812345673"),
                            Name = "DogTest3"
                        },
                        new
                        {
                            animalID = new Guid("12345678-1234-5678-1234-567812345674"),
                            Name = "DogTest4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
