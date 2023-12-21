using Application.Validators.User;
using Domain.Models.UserModels;
using Infrastructure.Repository.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User.UserUpdate
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserUpdateValidator _Validator;

        public UpdateUserCommandHandler(IUserRepository userRepository, UserUpdateValidator validator)
        {
            _userRepository = userRepository;
            _Validator = validator;
        }

        public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserByIdAsync(request.UserId); // Använd UserId här

            if (userToUpdate == null)
            {
                throw new KeyNotFoundException($"User with ID {request.UserId} not found"); // Använd UserId här
            }

            // Uppdatera användardata
            userToUpdate.UserName = request.UserUpdateDto.Username; // Använd UserUpdateDto.Username här

            // Kryptera det nya lösenordet om det har ändrats
            if (!string.IsNullOrWhiteSpace(request.UserUpdateDto.Password)) // Använd UserUpdateDto.Password här
            {
                userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(request.UserUpdateDto.Password); // Använd UserUpdateDto.Password här
            }

            // Uppdatera användaren i databasen
            await _userRepository.UpdateUserAsync(userToUpdate);

            return userToUpdate;
        }
    }
}
