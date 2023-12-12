
using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<AnimalDto>
    {
        public CatValidator()
        {
            RuleFor(cat => cat.Name)
                .NotEmpty().WithMessage("Cat name can not be empty !")
                .NotNull().WithMessage("Cat name can not be null !");

        }
    }
}
