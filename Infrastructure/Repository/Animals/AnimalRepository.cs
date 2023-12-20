#nullable disable
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.Animals
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly RealDatabase _realDatabase;

        public AnimalRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }
        public async Task<List<Cat>> GetAllCatsAsync()
        {
            return await _realDatabase.Cats.ToListAsync();
        }
        public async Task<List<Dog>> GetAllDogsAsync()
        {
            return await _realDatabase.Dogs.ToListAsync();
        }
        public async Task<Dog> GetDogByIdAsync(Guid id)
        {
            return await _realDatabase.Dogs.FindAsync(id);
        }

        public async Task<Cat> GetCatByIdAsync(Guid id)
        {
            return await _realDatabase.Cats.FindAsync(id);
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            if (entity is Cat cat)
            {
                _realDatabase.Cats.Add(cat);
            }
            else if (entity is Dog dog)
            {
                _realDatabase.Dogs.Add(dog);
            }
            else
            {
                throw new InvalidOperationException("Unsupported entity type");
            }

            await _realDatabase.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            if (entity is Cat cat)
            {
                _realDatabase.Cats.Update(cat);
            }
            else if (entity is Dog dog)
            {
                _realDatabase.Dogs.Update(dog);
            }
            else
            {
                throw new InvalidOperationException("Unsupported entity type");
            }

            await _realDatabase.SaveChangesAsync();
        }


        public async Task DeleteAsync<T>(Guid id) where T : class
        {
            T entity;
            if (typeof(T) == typeof(Cat))
            {
                entity = await _realDatabase.Cats.FindAsync(id) as T;
            }
            else if (typeof(T) == typeof(Dog))
            {
                entity = await _realDatabase.Dogs.FindAsync(id) as T;
            }
            else
            {
                throw new InvalidOperationException("Unsupported entity type");
            }

            if (entity != null)
            {
                _realDatabase.Set<T>().Remove(entity);
                await _realDatabase.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} was not found.");
            }
        }

    }
}
