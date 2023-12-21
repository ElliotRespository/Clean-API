#nullable disable
using Application.Dtos.UserAnimal;
using Domain.Models;
using Infrastructure.Repository.Animals;
using Infrastructure.Repository.UserAnimal;
using Infrastructure.Repository.Users;
using MediatR;

namespace Application.Commands.UserAnimal.Update
{
    public class UpdateUserAnimalCommandHandler : IRequestHandler<UpdateUserAnimalCommand, UserAnimalDto>
    {
        private readonly IUserAnimalRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IAnimalRepository _animalRepository;

        public UpdateUserAnimalCommandHandler(IUserAnimalRepository repository, IUserRepository userRepository, IAnimalRepository animalRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _animalRepository = animalRepository;
        }

        public async Task<UserAnimalDto> Handle(UpdateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Hämta den befintliga UserAnimal-relationen
                var userAnimalToUpdate = await _repository.GetUserAnimalById(request.UpdateUserAnimalDto.UserAnimalId);

                if (userAnimalToUpdate == null)
                {
                    throw new KeyNotFoundException("Specified UserAnimal relationship not found");
                }

                // Uppdatera UserId om ett nytt UserId tillhandahålls
                if (request.UpdateUserAnimalDto.NewUserId.HasValue)
                {
                    var newUser = await _userRepository.GetUserByIdAsync(request.UpdateUserAnimalDto.NewUserId.Value);
                    if (newUser != null)
                    {
                        userAnimalToUpdate.UserId = request.UpdateUserAnimalDto.NewUserId.Value;
                    }
                    else
                    {
                        throw new KeyNotFoundException("New user not found");
                    }
                }

                // Uppdatera AnimalId om ett nytt AnimalId tillhandahålls
                if (request.UpdateUserAnimalDto.NewAnimalId.HasValue)
                {
                    var cat = await _animalRepository.GetCatByIdAsync(request.UpdateUserAnimalDto.NewAnimalId.Value);
                    var dog = await _animalRepository.GetDogByIdAsync(request.UpdateUserAnimalDto.NewAnimalId.Value);
                    if (cat != null || dog != null)
                    {
                        userAnimalToUpdate.AnimalId = request.UpdateUserAnimalDto.NewAnimalId.Value;
                    }
                    else
                    {
                        throw new KeyNotFoundException("New animal not found");
                    }
                }

                await _repository.UpdateUserAnimal(userAnimalToUpdate);

                // Returnera en UserAnimalDto
                return new UserAnimalDto
                {
                    UserId = userAnimalToUpdate.UserId,
                    AnimalId = userAnimalToUpdate.AnimalId
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error updating UserAnimal: {ex.Message}", ex);
            }
        }
    }
}
