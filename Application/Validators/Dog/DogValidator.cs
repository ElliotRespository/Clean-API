using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Dog
{
    public class DogValidator : AbstractValidator<AnimalDto>
    {
        public DogValidator()
        {
            RuleFor(dog => dog.Name)
                .NotEmpty().WithMessage("Dog name can not be empty !")
                .NotNull().WithMessage("Dog name can not be null !");

        }
    }
}
