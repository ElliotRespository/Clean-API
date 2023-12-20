using Domain.Models.UserModels;


namespace Infrastructure.Repository.Users
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> RegisterUser(UserModel userToRegister);
        Task UpdateUser(UserModel user);
        Task DeleteUser(Guid userId);
        Task<UserModel> GetUserById(Guid userId);

    }
}
