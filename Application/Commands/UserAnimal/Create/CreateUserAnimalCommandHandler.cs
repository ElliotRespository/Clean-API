using Domain.Models;
using Infrastructure.Repository.Animals;
using Infrastructure.Repository.UserAnimal;
using Infrastructure.Repository.Users;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Application.Commands.UserAnimal.Create
{
    public class CreateUserAnimalCommandHandler : IRequestHandler<CreateUserAnimalCommand, Guid>
    {
        private readonly IUserAnimalRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IAnimalRepository _animalRepository;
        public CreateUserAnimalCommandHandler(IUserAnimalRepository repository, IUserRepository userRepository, IAnimalRepository animalRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _animalRepository = animalRepository;
        }
        public async Task<Guid> Handle(CreateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(request.UserAnimalDto.UserId);
                if (user == null)
                {
                    throw new KeyNotFoundException("Användaren hittades inte.");
                }

                var cat = await _animalRepository.GetCatByIdAsync(request.UserAnimalDto.AnimalId);
                var dog = await _animalRepository.GetDogByIdAsync(request.UserAnimalDto.AnimalId);

                if (cat == null && dog == null)
                {
                    throw new KeyNotFoundException("Djuret hittades inte.");
                }

                var userAnimal = new UserAnimalModel
                {
                    UserId = request.UserAnimalDto.UserId,
                    AnimalId = request.UserAnimalDto.AnimalId
                };

                await _repository.CreateUserAnimal(userAnimal);
                return userAnimal.UserAnimalId;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ett fel inträffade vid skapandet av UserAnimal", ex);
            }
        }
    }
}
