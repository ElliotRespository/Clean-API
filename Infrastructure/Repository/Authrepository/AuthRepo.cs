#nullable disable
using Infrastructure.Database.SqlDataBases;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Repository.Authrepository
{
    public class AuthRepo
    {
        private readonly IConfiguration _configuration;
        private readonly RealDatabase _realDatabase;

        public AuthRepo(IConfiguration configuration, RealDatabase realDatabase)
        {
            _configuration = configuration;
            _realDatabase = realDatabase;
        }
        public async Task<UserModel> AuthenticateUser(UserModel userToAuthenticate)
        {
            UserModel user = await _realDatabase.Users.FirstOrDefaultAsync(u => u.UserName == userToAuthenticate.UserName);
            if (user != null && BCrypt.Net.BCrypt.Verify(userToAuthenticate.Password, user.Password))
            {
                return user;
            }
            throw new Exception("User not found");
        }
        public string GenerateToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:Secret"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
