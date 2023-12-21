using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;


namespace Application.Commands.Cats.CreateCat
{
    public class CreateCatCommandHandler : IRequestHandler<CreateCatCommand, Cat>
    {
        private readonly IAnimalRepository _animalRepository;

        public CreateCatCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Cat> Handle(CreateCatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newCat = new Cat
                {
                    Name = request.NewCat.Name,
                    AnimalID = Guid.NewGuid()
                };

                await _animalRepository.AddAsync(newCat);
                return newCat;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ett fel inträffade vid skapandet av katten", ex);
            }
        }
    }
}
