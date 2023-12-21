using Domain.Models.UserModels;


namespace Infrastructure.Repository.Users
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> RegisterUserAsync(UserModel userToRegister);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(Guid userId);
        Task<UserModel> GetUserByIdAsync(Guid userId);

    }
}
