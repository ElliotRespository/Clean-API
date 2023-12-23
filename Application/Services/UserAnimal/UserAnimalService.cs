using Application.Dtos.UserAnimal;
using Application.Services.UserAnimal;
using Domain.Models;
using Infrastructure.Repository.UserAnimal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserAnimalService
{
    public class UserAnimalService : IUserAnimalService
    {
        private readonly IUserAnimalRepository _userAnimalRepository;

        public UserAnimalService(IUserAnimalRepository userAnimalRepository)
        {
            _userAnimalRepository = userAnimalRepository;
        }

        public async Task<Guid> CreateUserAnimalAsync(UserAnimalDto userAnimalDto)
        {
            var userAnimal = new UserAnimalModel
            {
                UserId = userAnimalDto.UserId,
                AnimalId = userAnimalDto.AnimalId
            };

            return await _userAnimalRepository.CreateUserAnimal(userAnimal);
        }

        public async Task UpdateUserAnimalAsync(UpdateUserAnimalDto updateUserAnimalDto)
        {
            var userAnimal = await _userAnimalRepository.GetUserAnimalById(updateUserAnimalDto.UserAnimalId);
            if (userAnimal == null)
                throw new KeyNotFoundException("UserAnimal not found.");

            if (updateUserAnimalDto.NewUserId.HasValue)
                userAnimal.UserId = updateUserAnimalDto.NewUserId.Value;

            if (updateUserAnimalDto.NewAnimalId.HasValue)
                userAnimal.AnimalId = updateUserAnimalDto.NewAnimalId.Value;

            await _userAnimalRepository.UpdateUserAnimal(userAnimal);
        }

        public async Task DeleteUserAnimalAsync(Guid userAnimalId)
        {
            await _userAnimalRepository.DeleteUserAnimal(userAnimalId);
        }

        public async Task<IEnumerable<UserAnimalDto>> GetAllUserAnimalsAsync()
        {
            var userAnimals = await _userAnimalRepository.GetAllUserAnimals();
            return userAnimals.Select(ua => new UserAnimalDto
            {
                UserId = ua.UserId,
                AnimalId = ua.AnimalId
            });
        }

        public async Task<UserAnimalDto> GetUserAnimalByIdAsync(Guid userAnimalId)
        {
            var userAnimal = await _userAnimalRepository.GetUserAnimalById(userAnimalId);
            if (userAnimal == null)
                throw new KeyNotFoundException("UserAnimal not found.");

            return new UserAnimalDto
            {
                UserId = userAnimal.UserId,
                AnimalId = userAnimal.AnimalId
            };
        }
    }
}
