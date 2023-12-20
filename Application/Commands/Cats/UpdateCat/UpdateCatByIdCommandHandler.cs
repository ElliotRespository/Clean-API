using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;


namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly IAnimalRepository _animalRepository;

        public UpdateCatByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            var cat = await _animalRepository.GetCatByIdAsync(request.Id);
            if (cat == null)
            {
                throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
            }

            cat.Name = request.UpdatedCat.Name;

            await _animalRepository.UpdateAsync(cat);

            return cat;
        }
    }
}
