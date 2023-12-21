#nullable disable
using Application.Dtos.UserAnimal;
using FluentValidation;


namespace Application.Validators.UserAnimal
{
    public class UpdateUserAnimalDtoValidator : AbstractValidator<UpdateUserAnimalDto>
    {
        public UpdateUserAnimalDtoValidator()
        {
            RuleFor(x => x.UserAnimalId)
                .NotEmpty().WithMessage("UserAnimalId is required.");

            // Validera NewUserId och NewAnimalId om de är tillgängliga
            When(x => x.NewUserId.HasValue, () =>
            {
                RuleFor(x => x.NewUserId.Value)
                    .NotEmpty().WithMessage("New UserId cannot be empty.");
            });

            When(x => x.NewAnimalId.HasValue, () =>
            {
                RuleFor(x => x.NewAnimalId.Value)
                    .NotEmpty().WithMessage("New AnimalId cannot be empty.");
            });
        }
    }

}
