using Application.Services.PasswordHasher;
using Application.Services.User;
using Application.Validators.User;
using Domain.Models.UserModels;
using Infrastructure.Repository.Users;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User.UserRegister
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserModel>
    {
        private readonly IUserService _userService;
        private readonly ILogger<RegisterUserCommandHandler> _logger;

        public RegisterUserCommandHandler(IUserService userService, ILogger<RegisterUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<UserModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.RegisterUserAsync(request.NewUser);
                _logger.LogInformation("User registered successfully: {Username}", request.NewUser.Username);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while registering user");
                throw;
            }
        }
    }
}
