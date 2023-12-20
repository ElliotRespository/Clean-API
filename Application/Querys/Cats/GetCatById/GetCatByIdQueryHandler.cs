using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;


namespace Application.Querys.Cats.GetCatById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetCatByIdQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            var cat = await _animalRepository.GetCatByIdAsync(request.Id);
            if (cat == null)
            {
                throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
            }

            return cat;
        }
    }
}
