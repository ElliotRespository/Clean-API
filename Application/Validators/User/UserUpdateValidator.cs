using Application.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.User
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {

            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            // Regel för lösenord, om användaren vill ändra det
            RuleFor(user => user.Password)
                .Cascade(CascadeMode.Stop) // Sluta validera om en regel misslyckas
                .NotEmpty().When(user => !string.IsNullOrWhiteSpace(user.Password)) // Endast validera om Password inte är tomt
                .Length(6, 100).When(user => !string.IsNullOrWhiteSpace(user.Password)) // Endast validera om Password inte är tomt
                .WithMessage("Password must be between 6 and 100 characters.");
        }
    }
}
