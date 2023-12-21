using Application.Dtos.UserAnimal;
using Infrastructure.Repository.UserAnimal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Querys.UserAnimals.GetAllUserAnimals
{
    public class GetAllUserAnimalsQueryHandler : IRequestHandler<GetAllUserAnimalsQuery, IEnumerable<UserAnimalDto>>
    {
        private readonly IUserAnimalRepository _userAnimalRepository;

        public GetAllUserAnimalsQueryHandler(IUserAnimalRepository userAnimalRepository)
        {
            _userAnimalRepository = userAnimalRepository;
        }

        public async Task<IEnumerable<UserAnimalDto>> Handle(GetAllUserAnimalsQuery request, CancellationToken cancellationToken)
        {
            var userAnimals = await _userAnimalRepository.GetAllUserAnimals();
            var userAnimalDtos = userAnimals.Select(ua => new UserAnimalDto
            {
                UserId = ua.UserId,
                AnimalId = ua.AnimalId
                // Andra egenskaper som behöv
            });

            return userAnimalDtos;
        }
    }
}
