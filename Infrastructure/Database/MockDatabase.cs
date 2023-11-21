using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> allDogs
        {
            get { return allDogsFromMockDatabase; }
            set { allDogsFromMockDatabase = value; }
        }
        private static List<Dog> allDogsFromMockDatabase = new()
        {
            new Dog
            {
                animalID = Guid.NewGuid(), Name = "Doggo"
            },
            new Dog
            {
                animalID = Guid.NewGuid(), Name = "Raggy"
            },
            new Dog
            {
                animalID = Guid.NewGuid(), Name = "Scooby"
            },
            new Dog
            {
                animalID = Guid.NewGuid(), Name = "Rooby"
            },
            new Dog
            {
                animalID = Guid.NewGuid(), Name = "Roo"
            },
            new Dog
            {
                animalID = Guid.NewGuid(), Name = "Booby"
            },

        };
        

        
    }
}
