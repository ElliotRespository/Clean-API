using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;


namespace Application.Querys.Dogs.GetDogById
{

    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetDogByIdQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            var dog = await _animalRepository.GetDogByIdAsync(request.Id);
            if (dog == null)
            {
                throw new KeyNotFoundException($"Dog with ID {request.Id} was not found.");
            }

            return dog;
        }
    }
}
