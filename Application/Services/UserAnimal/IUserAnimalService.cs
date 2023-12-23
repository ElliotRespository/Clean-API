using Application.Dtos.UserAnimal;


namespace Application.Services.UserAnimal
{
    public interface IUserAnimalService
    {
        Task<Guid> CreateUserAnimalAsync(UserAnimalDto userAnimalDto);
        Task UpdateUserAnimalAsync(UpdateUserAnimalDto updateUserAnimalDto);
        Task DeleteUserAnimalAsync(Guid userAnimalId);
        Task<IEnumerable<UserAnimalDto>> GetAllUserAnimalsAsync();
        Task<UserAnimalDto> GetUserAnimalByIdAsync(Guid userAnimalId);
    }
}
