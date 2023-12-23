using Application.Dtos.User;
using Domain.Models.UserModels;


namespace Application.Services.User
{
    public interface IUserService
    {
        Task<UserModel> RegisterUserAsync(UserInfoDto userInfoDto);
        Task<UserModel> UpdateUserAsync(Guid userId, UserUpdateDto userUpdateDto);
        Task<UserModel> GetUserByIdAsync(Guid userId);
        Task<UserModel> GetUserByUsernameAsync(string username);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task DeleteUserAsync(Guid userId);
    }

}
