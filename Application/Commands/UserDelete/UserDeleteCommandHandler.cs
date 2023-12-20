using Infrastructure.Repository.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userToDelete = await _userRepository.GetUserById(request.UserId);
                if (userToDelete == null)
                {
                    throw new KeyNotFoundException($"User with ID {request.UserId} not found");
                }

                await _userRepository.DeleteUser(request.UserId);
            }
            catch (Exception ex)
            {
                // Hantera undantag här, t.ex. genom att logga dem
                throw new ApplicationException($"Error deleting user: {ex.Message}", ex);
            }
        }
    }
}

