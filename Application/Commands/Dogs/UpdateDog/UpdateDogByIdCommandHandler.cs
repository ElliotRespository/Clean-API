using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IAnimalRepository _animalRepository;

        public UpdateDogByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            var dog = await _animalRepository.GetDogByIdAsync(request.Id);
            if (dog == null)
            {
                throw new KeyNotFoundException($"Dog with ID {request.Id} was not found.");
            }

            dog.Name = request.UpdatedDog.Name;

            await _animalRepository.UpdateAsync(dog);

            return dog;
        }
    }
}
