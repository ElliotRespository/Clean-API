using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;

namespace Application.Querys.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllDogsQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            return await _animalRepository.GetAllDogsAsync();
        }
    }
}
