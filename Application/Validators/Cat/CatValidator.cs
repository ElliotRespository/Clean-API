using Application.Dtos.Animal;
using FluentValidation;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<AnimalDto>
    {
        public CatValidator()
        {
            RuleFor(cat => cat.Name)
                .NotEmpty().WithMessage("Cat name can not be empty!")
                .NotNull().WithMessage("Cat name can not be null!");

            RuleFor(cat => cat.Breed)
                .NotEmpty().When(cat => !string.IsNullOrWhiteSpace(cat.Breed))
                .WithMessage("Breed can not be empty!");

            RuleFor(cat => cat.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than zero!");

            RuleFor(cat => cat.Color)
                .NotEmpty().When(cat => !string.IsNullOrWhiteSpace(cat.Color))
                .WithMessage("Color can not be empty!");
        }
    }
}
