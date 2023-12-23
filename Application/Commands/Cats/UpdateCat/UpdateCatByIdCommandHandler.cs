using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<UpdateCatByIdCommandHandler> _logger;

        public UpdateCatByIdCommandHandler(IAnimalRepository animalRepository, ILogger<UpdateCatByIdCommandHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cat = await _animalRepository.GetCatByIdAsync(request.Id);
                if (cat == null)
                {
                    _logger.LogWarning("Cat not found for update: {CatId}", request.Id);
                    throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
                }
                cat.Name = request.UpdatedCat.Name;
                await _animalRepository.UpdateAsync(cat);
                _logger.LogInformation("Cat updated successfully: {CatId}", cat.AnimalID);
                return cat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating cat: {CatId}", request.Id);
                throw;
            }
        }
    }
}
