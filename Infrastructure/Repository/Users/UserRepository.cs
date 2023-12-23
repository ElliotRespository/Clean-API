#nullable disable
using Domain.Models.UserModels;
using Infrastructure.Database.SqlDataBases;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<UserModel> RegisterUserAsync(UserModel userToRegister)
        {
            _realDatabase.Users.Add(userToRegister);
            await _realDatabase.SaveChangesAsync();
            return userToRegister;
        }

        public async Task<UserModel> GetUserByIdAsync(Guid userId)
        {
            var user = await _realDatabase.Users.FindAsync(userId);
            return user;
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            List<UserModel> allUsersFromDatabase = await _realDatabase.Users.ToListAsync();
            return await Task.FromResult(allUsersFromDatabase);
        }

        public async Task UpdateUserAsync(UserModel updatedUser)
        {
            var existingUser = await _realDatabase.Users.FindAsync(updatedUser.Id);
            if (existingUser == null)
            {
                throw new ArgumentException("User not found");
            }

            existingUser.UserName = updatedUser.UserName;

            _realDatabase.Users.Update(existingUser);
            await _realDatabase.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var userToDelete = await _realDatabase.Users.FindAsync(userId);
            if (userToDelete == null)
            {
                throw new ArgumentException("User not found");
            }

            _realDatabase.Users.Remove(userToDelete);
            await _realDatabase.SaveChangesAsync();
        }
    }
}
