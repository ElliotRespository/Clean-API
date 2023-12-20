using Application.Commands.UserRegister;
using Domain.Models.UserModels;
using FluentValidation;
using Infrastructure.Repository.Users;


namespace Application.Validators.User
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(command => command.NewUser.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MustAsync(async (username, cancellation) => await BeUniqueUsernameAsync(username))
            .WithMessage("Username is already taken.");
        }

        private async Task<bool> BeUniqueUsernameAsync(string username)
        {
            var allUsersFromDb = await _userRepository.GetAllUsers();
            return !allUsersFromDb.Any(user => user.UserName == username);
        }
    }
}
