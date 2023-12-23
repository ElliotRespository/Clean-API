using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;



namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<DeleteCatByIdCommandHandler> _logger;

        public DeleteCatByIdCommandHandler(IAnimalRepository animalRepository, ILogger<DeleteCatByIdCommandHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var catToDelete = await _animalRepository.GetCatByIdAsync(request.Id);
                if (catToDelete == null)
                {
                    _logger.LogWarning("Cat not found for deletion: {CatId}", request.Id);
                    throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
                }

                await _animalRepository.DeleteAsync<Cat>(request.Id);
                _logger.LogInformation("Cat deleted: {CatId}", request.Id);
                return catToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting cat: {CatId}", request.Id);
                throw;
            }
        }
    }
}
