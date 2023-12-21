using Domain.Models.Animalmodels;
using Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Database.DataBaseSeed
{
    public static class DataBaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedUsers(modelBuilder);
            SeedCats(modelBuilder);
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { AnimalID = Guid.NewGuid(), Name = "Kenta" },
                new Dog { AnimalID = Guid.NewGuid(), Name = "Knugen" },
                new Dog { AnimalID = Guid.NewGuid(), Name = "Sjöberg" },
                new Dog { AnimalID = Guid.NewGuid(), Name = "Berra" },
                new Dog { AnimalID = new Guid("12345678-1234-5678-1234-567812345671"), Name = "DogTest1" },
                new Dog { AnimalID = new Guid("12345678-1234-5678-1234-567812345672"), Name = "DogTest2" },
                new Dog { AnimalID = new Guid("12345678-1234-5678-1234-567812345673"), Name = "DogTest3" },
                new Dog { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "DogTest4" }
            );
        }

        private static void SeedCats(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasData(
                new Cat { AnimalID = Guid.NewGuid(), Name = "Fluffig" },
                new Cat { AnimalID = Guid.NewGuid(), Name = "Argjävel" },
                new Cat { AnimalID = Guid.NewGuid(), Name = "Simba" },
                new Cat { AnimalID = Guid.NewGuid(), Name = "LedsenKatt" }

            );
        }
        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
               new UserModel
               {
                   Id = Guid.NewGuid(),
                   UserName = "admin",
                   Password = BCrypt.Net.BCrypt.HashPassword("Adminpassword12!"),
                   Role = "Admin"
               },
               new UserModel
               {
                   Id = Guid.NewGuid(),
                   UserName = "user",
                   Password = BCrypt.Net.BCrypt.HashPassword("Userpassword12!"),
                   Role = "Normal"
               }
           );
        }


    }
}
