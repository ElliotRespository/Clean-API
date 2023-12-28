using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Commands.Cats.CreateCat
{
    public class CreateCatCommandHandler : IRequestHandler<CreateCatCommand, Cat>
    {
        private readonly ILogger<CreateCatCommandHandler> _logger;
        private readonly ICatService _catService;
        public CreateCatCommandHandler(ICatService catService, ILogger<CreateCatCommandHandler> logger)
        {
            _catService = catService;
            _logger = logger;
        }

        public async Task<Cat> Handle(CreateCatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newCat = await _catService.CreateCatAsync(request.NewCat);
                _logger.LogInformation("New cat created: {CatId}", newCat.AnimalID);
                return newCat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new cat");
                throw;
            }

        }
    }
}
