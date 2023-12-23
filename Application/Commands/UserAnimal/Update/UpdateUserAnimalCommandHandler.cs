#nullable disable
using Application.Dtos.UserAnimal;
using Application.Services.UserAnimal;
using Domain.Models;
using Infrastructure.Repository.Animals;
using Infrastructure.Repository.UserAnimal;
using Infrastructure.Repository.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.UserAnimal.Update
{
    public class UpdateUserAnimalCommandHandler : IRequestHandler<UpdateUserAnimalCommand>
    {
        private readonly IUserAnimalService _userAnimalService;
        private readonly ILogger<UpdateUserAnimalCommandHandler> _logger;

        public UpdateUserAnimalCommandHandler(IUserAnimalService userAnimalService, ILogger<UpdateUserAnimalCommandHandler> logger)
        {
            _userAnimalService = userAnimalService;
            _logger = logger;
        }

        public async Task Handle(UpdateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _userAnimalService.UpdateUserAnimalAsync(request.UpdateUserAnimalDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user animal with ID {UserAnimalId}", request.UpdateUserAnimalDto.UserAnimalId);
                throw;
            }
        }
    }
}
