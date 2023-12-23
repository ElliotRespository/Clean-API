using Application.Services.UserAnimal;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.Delete
{
    public class DeleteUserAnimalCommandHandler : IRequestHandler<DeleteUserAnimalCommand>
    {
        private readonly IUserAnimalService _userAnimalService;
        private readonly ILogger<DeleteUserAnimalCommandHandler> _logger;

        public DeleteUserAnimalCommandHandler(IUserAnimalService userAnimalService, ILogger<DeleteUserAnimalCommandHandler> logger)
        {
            _userAnimalService = userAnimalService;
            _logger = logger;
        }

        public async Task Handle(DeleteUserAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _userAnimalService.DeleteUserAnimalAsync(request.UserAnimalId);
                _logger.LogInformation($"UserAnimal with ID {request.UserAnimalId} was successfully deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred deleting UserAnimal with ID {request.UserAnimalId}.");
                throw;
            }
        }
    }
}