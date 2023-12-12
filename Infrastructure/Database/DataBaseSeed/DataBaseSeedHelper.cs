using Domain.Models.Animalmodels;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Database.DataBaseSeed
{
    public static class DataBaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { animalID = Guid.NewGuid(), Name = "Kenta" },
                new Dog { animalID = Guid.NewGuid(), Name = "Knugen" },
                new Dog { animalID = Guid.NewGuid(), Name = "Sjöberg" },
                new Dog { animalID = Guid.NewGuid(), Name = "Berra" },
                new Dog { animalID = new Guid("12345678-1234-5678-1234-567812345671"), Name = "DogTest1" },
                new Dog { animalID = new Guid("12345678-1234-5678-1234-567812345672"), Name = "DogTest2" },
                new Dog { animalID = new Guid("12345678-1234-5678-1234-567812345673"), Name = "DogTest3" },
                new Dog { animalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "DogTest4" }
            );
        }
    }
}
