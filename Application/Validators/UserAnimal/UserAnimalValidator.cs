using Application.Dtos.UserAnimal;
using FluentValidation;
using Infrastructure.Repository.Animals;
using Infrastructure.Repository.Users;


namespace Application.Validators.UserAnimal
{
    public class UserAnimalValidator : AbstractValidator<UserAnimalDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAnimalRepository _animalRepository;

        public UserAnimalValidator(IUserRepository userRepository, IAnimalRepository animalRepository)
        {
            _userRepository = userRepository;
            _animalRepository = animalRepository;

            RuleFor(dto => dto.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MustAsync(ExistUser).WithMessage("User does not exist.");

            RuleFor(dto => dto.AnimalId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MustAsync(ExistAnimal).WithMessage("Animal does not exist.");

            // Unikhet för kombination av UserId och AnimalId
            RuleFor(dto => dto)
                .MustAsync(BeUniqueUserAnimal).WithMessage("This User-Animal relationship already exists.");
        }

        private async Task<bool> ExistUser(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user != null;
        }

        private async Task<bool> ExistAnimal(Guid animalId, CancellationToken cancellationToken)
        {
            var cat = await _animalRepository.GetCatByIdAsync(animalId);
            var dog = await _animalRepository.GetDogByIdAsync(animalId);
            return cat != null || dog != null;
        }

        private async Task<bool> BeUniqueUserAnimal(UserAnimalDto dto, CancellationToken cancellationToken)
        {
            var existingUserAnimal = await _animalRepository.GetUserAnimalsByUserAndAnimalId(dto.UserId, dto.AnimalId);
            return !existingUserAnimal.Any();
        }
    }
}
