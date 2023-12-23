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

namespace Application.Commands.User.UserUpdate
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserService userService, ILogger<UpdateUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(request.UserId, request.UserUpdateDto);
                _logger.LogInformation("User updated successfully: {UserId}", request.UserId);
                return updatedUser;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "User not found for update: {UserId}", request.UserId);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user: {UserId}", request.UserId);
                throw;
            }
        }
    }
}
