﻿// <auto-generated />
using System;
using Infrastructure.Database.SqlDataBases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    partial class RealDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Animal", b =>
                {
                    b.Property<Guid>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("AnimalID");

                    b.ToTable("Animal");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Animal");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.UserAnimalModel", b =>
                {
                    b.Property<Guid>("UserAnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserAnimalId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAnimals");
                });

            modelBuilder.Entity("Domain.Models.UserModels.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cf9e669e-cdbd-4356-8c0d-63554904b139"),
                            Password = "$2a$11$/BmTucWkJ4.XrdRbWoAOh.T2GVBwGzEtBW2Y3un0F/5yEpcvawYtK",
                            Role = "Admin",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("bc2026d5-2b92-4d98-b3df-47793e851bf8"),
                            Password = "$2a$11$wf8/M5gi2nCDr/0uwcIWFedJU2xlHVvO07J2cdSGq4Xmw0j5WBUUq",
                            Role = "Normal",
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("Domain.Models.Animalmodels.Cat", b =>
                {
                    b.HasBaseType("Domain.Models.Animal");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Cat");

                    b.HasData(
                        new
                        {
                            AnimalID = new Guid("472b8d1b-e558-48ab-a8a4-a2a2f5d32f81"),
                            Name = "Fluffig",
                            Weight = 0,
                            LikesToPlay = false
                        },
                        new
                        {
                            AnimalID = new Guid("27b5f033-1709-4d2b-bf9d-bca1acf20b9a"),
                            Name = "Argjävel",
                            Weight = 0,
                            LikesToPlay = false
                        },
                        new
                        {
                            AnimalID = new Guid("0ffc0988-8dfb-433f-b5dc-44b140230976"),
                            Name = "Simba",
                            Weight = 0,
                            LikesToPlay = false
                        },
                        new
                        {
                            AnimalID = new Guid("0c4e6e32-0773-4b10-877e-0955afa5b110"),
                            Name = "LedsenKatt",
                            Weight = 0,
                            LikesToPlay = false
                        });
                });

            modelBuilder.Entity("Domain.Models.Animalmodels.Dog", b =>
                {
                    b.HasBaseType("Domain.Models.Animal");

                    b.HasDiscriminator().HasValue("Dog");

                    b.HasData(
                        new
                        {
                            AnimalID = new Guid("7164111f-9594-446b-8276-8e06054a56be"),
                            Name = "Kenta",
                            Weight = 0
                        },
                        new
                        {
                            AnimalID = new Guid("bfd1f6dc-bb27-43bc-abc3-cd94e03cf1e6"),
                            Name = "Knugen",
                            Weight = 0
                        },
                        new
                        {
                            AnimalID = new Guid("bffe3342-bf51-48cc-a5b6-a8a8cd9653be"),
                            Name = "Sjöberg",
                            Weight = 0
                        },
                        new
                        {
                            AnimalID = new Guid("a5d9c37c-2487-4368-a044-02aea47f0be5"),
                            Name = "Berra",
                            Weight = 0
                        },
                        new
                        {
                            AnimalID = new Guid("12345678-1234-5678-1234-567812345671"),
                            Name = "DogTest1",
                            Weight = 0
                        },
                        new
                        {
                            AnimalID = new Guid("12345678-1234-5678-1234-567812345672"),
                            Name = "DogTest2",
                            Weight = 0
                        },
                        new
                        {
                            AnimalID = new Guid("12345678-1234-5678-1234-567812345673"),
                            Name = "DogTest3",
                            Weight = 0
                        },
                        new
                        {
                            AnimalID = new Guid("12345678-1234-5678-1234-567812345674"),
                            Name = "DogTest4",
                            Weight = 0
                        });
                });

            modelBuilder.Entity("Domain.Models.UserAnimalModel", b =>
                {
                    b.HasOne("Domain.Models.Animal", "Animal")
                        .WithMany("UserAnimals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.UserModels.UserModel", "User")
                        .WithMany("UserAnimals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Animal", b =>
                {
                    b.Navigation("UserAnimals");
                });

            modelBuilder.Entity("Domain.Models.UserModels.UserModel", b =>
                {
                    b.Navigation("UserAnimals");
                });
#pragma warning restore 612, 618
        }
    }
}
