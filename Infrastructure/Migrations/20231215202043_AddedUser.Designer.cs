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
    [Migration("20231215202043_AddedUser")]
    partial class AddedUser
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
                            animalID = new Guid("f8bc0cc4-a8db-4e1d-a435-e7b542aa12b5"),
                            Name = "Kenta"
                        },
                        new
                        {
                            animalID = new Guid("c3e58d7b-e7b7-4999-a5ed-34ca304ec5a1"),
                            Name = "Knugen"
                        },
                        new
                        {
                            animalID = new Guid("89c8914f-9282-41b9-a8e2-cedcca405101"),
                            Name = "Sjöberg"
                        },
                        new
                        {
                            animalID = new Guid("bb4a9eb5-5f26-4697-b507-8692201ff4db"),
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

            modelBuilder.Entity("Domain.Models.UserModels.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
