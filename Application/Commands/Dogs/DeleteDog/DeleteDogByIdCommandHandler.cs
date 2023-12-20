using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly IAnimalRepository _animalRepository;

        public DeleteDogByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            var dogToDelete = await _animalRepository.GetDogByIdAsync(request.Id);
            if (dogToDelete == null)
            {
                throw new KeyNotFoundException($"Dog with ID {request.Id} was not found.");
            }

            await _animalRepository.DeleteAsync<Dog>(request.Id);
            return dogToDelete;
        }
    }
}


