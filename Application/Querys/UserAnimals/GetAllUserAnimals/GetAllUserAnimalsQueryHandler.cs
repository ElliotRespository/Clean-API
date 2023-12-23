using Application.Dtos.UserAnimal;
using Application.Services.UserAnimal;
using MediatR;


namespace Application.Querys.UserAnimals.GetAllUserAnimals
{
    public class GetAllUserAnimalsQueryHandler : IRequestHandler<GetAllUserAnimalsQuery, IEnumerable<UserAnimalDto>>
    {
        private readonly IUserAnimalService _userAnimalService;

        public GetAllUserAnimalsQueryHandler(IUserAnimalService userAnimalService)
        {
            _userAnimalService = userAnimalService;
        }

        public async Task<IEnumerable<UserAnimalDto>> Handle(GetAllUserAnimalsQuery request, CancellationToken cancellationToken)
        {
            var userAnimals = await _userAnimalService.GetAllUserAnimalsAsync();
            return userAnimals.Select(ua => new UserAnimalDto
            {
                UserId = ua.UserId,
                AnimalId = ua.AnimalId
            });
        }
    }
}
