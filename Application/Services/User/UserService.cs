#nullable disable
using Application.Dtos.User;
using Application.Services.PasswordHasher;
using Domain.Models.UserModels;
using FluentValidation;
using Infrastructure.Repository.Users;

namespace Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidator<UserInfoDto> _validator;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IValidator<UserInfoDto> validator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _validator = validator;
        }

        public async Task<UserModel> RegisterUserAsync(UserInfoDto userInfoDto)
        {
            // Validera användardata
            var validationResult = await _validator.ValidateAsync(userInfoDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var hashedPassword = _passwordHasher.HashPassword(userInfoDto.Password);
            var newUser = new UserModel
            {
                Id = Guid.NewGuid(),
                UserName = userInfoDto.Username,
                Password = hashedPassword,
                Role = "Normal"
            };

            return await _userRepository.RegisterUserAsync(newUser);
        }

        public async Task<UserModel> UpdateUserAsync(Guid userId, UserUpdateDto userUpdateDto)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            existingUser.UserName = userUpdateDto.Username;
            if (!string.IsNullOrWhiteSpace(userUpdateDto.Password))
            {
                existingUser.Password = _passwordHasher.HashPassword(userUpdateDto.Password);
            }

            await _userRepository.UpdateUserAsync(existingUser);
            return existingUser;
        }
        public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<UserModel> GetUserByIdAsync(Guid userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }

}
