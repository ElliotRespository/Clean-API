using Domain.Models;


namespace Infrastructure.Repository.UserAnimal
{
    public interface IUserAnimalRepository
    {
        Task<Guid> CreateUserAnimal(UserAnimalModel userAnimal);
        Task UpdateUserAnimal(UserAnimalModel userAnimal);
        Task DeleteUserAnimal(Guid id);
        Task<IEnumerable<UserAnimalModel>> GetAllUserAnimals();
        Task<UserAnimalModel> GetUserAnimalById(Guid id);
    }
}
