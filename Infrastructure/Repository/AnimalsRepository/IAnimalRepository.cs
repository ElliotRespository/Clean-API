using Domain.Models;
using Domain.Models.Animalmodels;


namespace Infrastructure.Repository.Animals
{
    public interface IAnimalRepository
    {
        Task<Dog> GetDogByIdAsync(Guid id);
        Task<Cat> GetCatByIdAsync(Guid id);
        Task AddAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(Guid id) where T : class;
        Task<List<Dog>> GetAllDogsAsync();
        Task<List<Cat>> GetAllCatsAsync();
        Task<IEnumerable<UserAnimalModel>> GetUserAnimalsByUserAndAnimalId(Guid userId, Guid animalId);
    }
}
