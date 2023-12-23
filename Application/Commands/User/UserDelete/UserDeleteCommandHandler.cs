using Application.Services.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.User.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserDeleteCommandHandler> _logger;

        public UserDeleteCommandHandler(IUserService userService, ILogger<UserDeleteCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _userService.DeleteUserAsync(request.UserId);
                _logger.LogInformation("User deleted successfully: {UserId}", request.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user: {UserId}", request.UserId);
                throw;
            }
        }
    }
}
