#nullable disable
using Domain.Models;
using Infrastructure.Database.SqlDataBases;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.UserAnimal
{
    public class UserAnimalRepository : IUserAnimalRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserAnimalRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Guid> CreateUserAnimal(UserAnimalModel userAnimal)
        {
            _realDatabase.UserAnimals.Add(userAnimal);
            await _realDatabase.SaveChangesAsync();
            return userAnimal.UserAnimalId;
        }

        public async Task UpdateUserAnimal(UserAnimalModel userAnimal)
        {
            _realDatabase.UserAnimals.Update(userAnimal);
            await _realDatabase.SaveChangesAsync();
        }

        public async Task DeleteUserAnimal(Guid userAnimalId)
        {
            var userAnimal = await _realDatabase.UserAnimals.FindAsync(userAnimalId);
            if (userAnimal != null)
            {
                _realDatabase.UserAnimals.Remove(userAnimal);
                await _realDatabase.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserAnimalModel>> GetAllUserAnimals()
        {
            return await _realDatabase.UserAnimals
                    .Include(ua => ua.User)
                    .Include(ua => ua.Animal)
                    .ToListAsync();
        }

        public async Task<UserAnimalModel> GetUserAnimalById(Guid userAnimalId)
        {
            return await _realDatabase.UserAnimals.FindAsync(userAnimalId);
        }
    }


}

