﻿using Application.Dtos.Animal;
using FluentValidation;

namespace Application.Validators.Dog
{
    public class DogValidator : AbstractValidator<AnimalDto>
    {
        public DogValidator()
        {
            RuleFor(dog => dog.Name)
                .NotEmpty().WithMessage("Dog name can not be empty!")
                .NotNull().WithMessage("Dog name can not be null!");

            RuleFor(dog => dog.Breed)
                .NotEmpty().WithMessage("Breed can not be empty!")
                .NotNull().WithMessage("Breed can not be null!");

            RuleFor(dog => dog.Weight)
                .GreaterThan(0).WithMessage("Weight must be greater than zero!");

            RuleFor(dog => dog.Color)
                .NotEmpty().WithMessage("Color can not be empty!")
                .NotNull().WithMessage("Color can not be null!");
        }
    }
}
