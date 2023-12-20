using Application.Validators.User;
using Domain.Models.UserModels;
using Infrastructure.Repository.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserRegister
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly RegisterUserValidator _validator;

        public RegisterUserCommandHandler(IUserRepository userRepository, RegisterUserValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<UserModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerValidation = await _validator.ValidateAsync(request);

            if (!registerValidation.IsValid)
            {
                var allErrors = registerValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
            }

            var userToCreate = new UserModel
            {
                Id = Guid.NewGuid(),
                UserName = request.NewUser.Username,
                Password = request.NewUser.Password,
                Role = "Normal"
            };

            var createdUser = await _userRepository.RegisterUser(userToCreate);

            return createdUser;
        }
    }
}
