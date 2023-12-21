using Application.Dtos.UserAnimal;
using FluentValidation;


namespace Application.Validators.UserAnimal
{
    public class UserAnimalValidator : AbstractValidator<UserAnimalDto>
    {
        public UserAnimalValidator()
        {
            RuleFor(dto => dto.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .WithErrorCode("REQUIRED");

            RuleFor(dto => dto.AnimalId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .WithErrorCode("REQUIRED");
        }
    }
}
