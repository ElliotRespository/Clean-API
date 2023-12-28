using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;



namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly ICatService _catService;
        private readonly ILogger<DeleteCatByIdCommandHandler> _logger;

        public DeleteCatByIdCommandHandler(ICatService catService, ILogger<DeleteCatByIdCommandHandler> logger)
        {
            _catService = catService;
            _logger = logger;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cat = await _catService.GetCatByIdAsync(request.Id);
                if (cat == null)
                {
                    _logger.LogWarning("Cat not found for deletion: {CatId}", request.Id);
                    throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
                }

                await _catService.DeleteCatAsync(request.Id);
                _logger.LogInformation("Cat deleted: {CatId}", request.Id);
                return cat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting cat: {CatId}", request.Id);
                throw;
            }
        }
    }
}
