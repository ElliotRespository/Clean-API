using Application.Services.UserAnimal;
using Domain.Models;
using Infrastructure.Repository.Animals;
using Infrastructure.Repository.UserAnimal;
using Infrastructure.Repository.Users;
using MediatR;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Application.Commands.UserAnimal.Create
{
    public class CreateUserAnimalCommandHandler : IRequestHandler<CreateUserAnimalCommand, Guid>
    {
        private readonly IUserAnimalService _userAnimalService;
        private readonly ILogger<CreateUserAnimalCommandHandler> _logger;

        public CreateUserAnimalCommandHandler(IUserAnimalService userAnimalService, ILogger<CreateUserAnimalCommandHandler> logger)
        {
            _userAnimalService = userAnimalService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _userAnimalService.CreateUserAnimalAsync(request.UserAnimalDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while creating user animal relationship for User ID {request.UserAnimalDto.UserId} and Animal ID {request.UserAnimalDto.AnimalId}");
                throw;
            }
        }
    }
}
