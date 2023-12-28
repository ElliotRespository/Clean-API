using Application.Dtos.Animal;
using Domain.Models.Animalmodels;
using Infrastructure.Repository.Animals;


namespace Application.Services.Animals.Dogs_Cats
{
    public class DogService : IDogService
    {
        private readonly IAnimalRepository _animalRepository;

        public DogService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Dog> CreateDogAsync(AnimalDto dogDto)
        {
            var dog = new Dog
            {
                Name = dogDto.Name,
                Breed = dogDto.Breed,
                Weight = dogDto.Weight,
                Color = dogDto.Color
            };
            await _animalRepository.AddAsync(dog);
            return dog;
        }

        public async Task UpdateDogAsync(Guid id, AnimalDto dogDto)
        {
            var dog = await _animalRepository.GetDogByIdAsync(id);
            if (dog == null)
                throw new KeyNotFoundException("Dog not found.");

            dog.Name = dogDto.Name;
            dog.Breed = dogDto.Breed;
            dog.Weight = dogDto.Weight;
            dog.Color = dogDto.Color;
            await _animalRepository.UpdateAsync(dog);
        }

        public async Task DeleteDogAsync(Guid id)
        {
            await _animalRepository.DeleteAsync<Dog>(id);
        }

        public async Task<IEnumerable<Dog>> GetAllDogsAsync()
        {
            return await _animalRepository.GetAllDogsAsync();
        }

        public async Task<Dog> GetDogByIdAsync(Guid id)
        {
            return await _animalRepository.GetDogByIdAsync(id);
        }

        public async Task<IEnumerable<Dog>> GetDogsByBreedWeightAndColorAsync(string breed, int? weight, string color)
        {
            var allDogs = await _animalRepository.GetAllDogsAsync();
            var query = allDogs.AsQueryable();

            if (!string.IsNullOrEmpty(breed))
            {
                query = query.Where(d => d.Breed == breed);
            }
            if (weight.HasValue)
            {
                query = query.Where(d => d.Weight >= weight.Value);
            }
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(d => d.Color == color);
            }

            return query.ToList();
        }

        public async Task<IEnumerable<Dog>> GetDogsByBreedAsync(string breed)
        {
            return await _animalRepository.GetDogsByBreedAsync(breed);
        }


    }
}
