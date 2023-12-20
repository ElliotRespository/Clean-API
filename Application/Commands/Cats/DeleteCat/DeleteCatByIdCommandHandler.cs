using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;



namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly IAnimalRepository _animalRepository;

        public DeleteCatByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            var catToDelete = await _animalRepository.GetCatByIdAsync(request.Id);
            if (catToDelete == null)
            {
                throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
            }

            await _animalRepository.DeleteAsync<Cat>(request.Id);
            return catToDelete;
        }
    }
}
