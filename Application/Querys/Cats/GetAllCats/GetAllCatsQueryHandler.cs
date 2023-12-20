using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;


namespace Application.Querys.Cats.GetAllCats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllCatsQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            return await _animalRepository.GetAllCatsAsync();
        }
    }
}
