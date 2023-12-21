using Domain.Models.Animalmodels;

namespace Infrastructure.Database.SqlDataBases
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
                AnimalID = Guid.NewGuid(), Name = "Doggo"
            },
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Raggy"
            },
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Scooby"
            },
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Rooby"
            },
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Roo"
            },
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Booby"
            },

        };

        public List<Cat> allCats
        {
            get { return allCatsFromMockDatabase; }
            set { allCatsFromMockDatabase = value; }
        }

        private static List<Cat> allCatsFromMockDatabase = new()
        {
            new Cat
            {
                AnimalID = Guid.NewGuid(), Name = "Mr Whiskers"
            },
            new Cat
            {
                AnimalID = Guid.NewGuid(), Name = "Ragdolian"
            },
            new Cat
            {
                AnimalID = Guid.NewGuid(), Name = "Mr Mjaow"
            },

        };


    }
}
