using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly ICatService _catService;
        private readonly ILogger<UpdateCatByIdCommandHandler> _logger;

        public UpdateCatByIdCommandHandler(ICatService catService, ILogger<UpdateCatByIdCommandHandler> logger)
        {
            _catService = catService;
            _logger = logger;
        }

        public async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _catService.UpdateCatAsync(request.Id, request.UpdatedCat);
                var updatedCat = await _catService.GetCatByIdAsync(request.Id);
                _logger.LogInformation("Cat updated successfully: {CatId}", updatedCat.AnimalID);
                return updatedCat;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Cat not found for update: {CatId}", request.Id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating cat: {CatId}", request.Id);
                throw;
            }
        }
    }
}
