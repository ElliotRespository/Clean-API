using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, Dog>
    {
        private readonly IAnimalRepository _animalRepository;

        public CreateDogCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Dog> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newDog = new Dog
                {
                    Name = request.NewDog.Name,
                    AnimalID = Guid.NewGuid()
                };

                await _animalRepository.AddAsync(newDog);
                return newDog;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ett fel inträffade vid skapandet av hunden", ex);
            }
        }
    }
}
