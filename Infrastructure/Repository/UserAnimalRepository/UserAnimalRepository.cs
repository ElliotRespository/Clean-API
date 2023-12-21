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
            try
            {
                _realDatabase.UserAnimals.Add(userAnimal);
                await _realDatabase.SaveChangesAsync();
                return userAnimal.UserAnimalId;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error creating UserAnimal: {ex.Message}", ex);
            }
        }

        public async Task UpdateUserAnimal(UserAnimalModel userAnimal)
        {
            try
            {
                _realDatabase.UserAnimals.Update(userAnimal);
                await _realDatabase.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error updating UserAnimal: {ex.Message}", ex);
            }
        }

        public async Task DeleteUserAnimal(Guid userAnimalId)
        {
            try
            {
                var userAnimal = await _realDatabase.UserAnimals.FindAsync(userAnimalId);
                if (userAnimal != null)
                {
                    _realDatabase.UserAnimals.Remove(userAnimal);
                    await _realDatabase.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("UserAnimal not found with the specified ID.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error deleting UserAnimal: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<UserAnimalModel>> GetAllUserAnimals()
        {
            try
            {
                return await _realDatabase.UserAnimals
                        .Include(ua => ua.User)
                        .Include(ua => ua.Animal)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error retrieving UserAnimals: {ex.Message}", ex);
            }
        }

        public async Task<UserAnimalModel> GetUserAnimalById(Guid userAnimalId)
        {
            try
            {
                var userAnimal = await _realDatabase.UserAnimals.FindAsync(userAnimalId);
                if (userAnimal == null)
                {
                    throw new KeyNotFoundException($"UserAnimal with ID {userAnimalId} not found.");
                }
                return userAnimal;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error retrieving UserAnimal: {ex.Message}", ex);
            }
        }


    }
}
