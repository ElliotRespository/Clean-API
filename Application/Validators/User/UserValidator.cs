using Application.Dtos.User;
using FluentValidation;
using Infrastructure.Repository.Users;


namespace Application.Validators.User
{
    public class UserValidator : AbstractValidator<object>
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleSet("Register", () =>
            {
                When(x => x is UserInfoDto, () =>
                {
                    RuleFor(user => ((UserInfoDto)user).Username)
                        .NotEmpty().WithMessage("Username is required.")
                        .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                        .MaximumLength(20).WithMessage("Username cannot exceed 20 characters.")
                        .Matches("^[a-zA-Z0-9_-]+$").WithMessage("Username can only contain letters, numbers, underscores, and hyphens.")
                        .MustAsync(BeUniqueUsername).WithMessage("Username is already taken.");

                    RuleFor(user => ((UserInfoDto)user).Password)
                        .NotEmpty().WithMessage("Password is required.")
                        .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                        .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                        .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                        .Matches("[0-9]").WithMessage("Password must contain at least one numeric digit.")
                        .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.")
                        .NotEqual("password", System.StringComparer.OrdinalIgnoreCase)
                            .WithMessage("Password cannot be 'password'.");
                });
            });

            RuleSet("Login", () =>
            {
                When(x => x is UserInfoDto, () =>
                {
                    RuleFor(user => ((UserInfoDto)user).Username)
                        .NotEmpty().WithMessage("Username is required.");

                    RuleFor(user => ((UserInfoDto)user).Password)
                        .NotEmpty().WithMessage("Password is required.");
                });
            });

            // Validering för UserUpdateDto
            When(x => x is UserUpdateDto, () =>
            {
                RuleFor(user => ((UserUpdateDto)user).Username)
                    .NotEmpty().WithMessage("Username is required.")
                    .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                    .MaximumLength(20).WithMessage("Username cannot exceed 20 characters.");

                // Antag att ett tomt lösenordsfält betyder att lösenordet inte ska ändras
                RuleFor(user => ((UserUpdateDto)user).Password)
                    .NotEmpty().When(user => !string.IsNullOrWhiteSpace(((UserUpdateDto)user).Password))
                    .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                    .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                    .Matches("[0-9]").WithMessage("Password must contain at least one numeric digit.")
                    .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.")
                    .NotEqual("password", System.StringComparer.OrdinalIgnoreCase)
                        .WithMessage("Password cannot be 'password'.");
            });
        }

        private async Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();
            return !users.Any(u => u.UserName.Equals(username, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
