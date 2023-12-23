using Application.Services.PasswordHasher;
using Application.Services.User;
using Domain.Models.UserModels;
using Infrastructure.Repository.Authrepository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Querys.Users.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IUserService _userService;
        private readonly AuthRepo _authRepo;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<LoginQueryHandler> _logger;

        public LoginQueryHandler(IUserService userService, IPasswordHasher passwordHasher, AuthRepo authRepo, ILogger<LoginQueryHandler> logger)
        {
            _userService = userService;
            _authRepo = authRepo;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(request.LoginUser.Username);
                if (user == null || !_passwordHasher.VerifyPassword(user.Password, request.LoginUser.Password))
                {
                    _logger.LogWarning("Invalid login attempt for username: {Username}", request.LoginUser.Username);
                    throw new UnauthorizedAccessException("Invalid username or password");
                }
                _logger.LogInformation("User logged in successfully: {Username}", request.LoginUser.Username);
                return _authRepo.GenerateToken(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login attempt failed for username: {Username}", request.LoginUser.Username);
                throw;
            }

        }
    }

}
