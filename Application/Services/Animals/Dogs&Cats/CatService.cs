using Application.Dtos.Animal;
using Domain.Models.Animalmodels;
using Infrastructure.Repository.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Animals.Dogs_Cats
{
    public class CatService : ICatService
    {
        private readonly IAnimalRepository _animalRepository;

        public CatService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Cat> CreateCatAsync(AnimalDto catDto)
        {
            var cat = new Cat
            {
                Name = catDto.Name,
                LikesToPlay = catDto.LikesToPlay,
                Breed = catDto.Breed,
                Weight = catDto.Weight,
                Color = catDto.Color
            };
            await _animalRepository.AddAsync(cat);
            return cat;
        }

        public async Task UpdateCatAsync(Guid id, AnimalDto catDto)
        {
            var cat = await _animalRepository.GetCatByIdAsync(id);
            if (cat == null)
                throw new KeyNotFoundException("Cat not found.");

            cat.Name = catDto.Name;
            cat.LikesToPlay = catDto.LikesToPlay;
            cat.Breed = catDto.Breed;
            cat.Weight = catDto.Weight;
            cat.Color = catDto.Color;
            await _animalRepository.UpdateAsync(cat);
        }

        public async Task DeleteCatAsync(Guid id)
        {
            await _animalRepository.DeleteAsync<Cat>(id);
        }

        public async Task<IEnumerable<Cat>> GetAllCatsAsync()
        {
            return await _animalRepository.GetAllCatsAsync();
        }

        public async Task<Cat> GetCatByIdAsync(Guid id)
        {
            return await _animalRepository.GetCatByIdAsync(id);
        }

        public async Task<IEnumerable<Cat>> GetCatsByBreedWeightAndColorAsync(string breed, int? weight, string color)
        {
            var allCats = await _animalRepository.GetAllCatsAsync();
            var query = allCats.AsQueryable();

            if (!string.IsNullOrEmpty(breed))
            {
                query = query.Where(c => c.Breed == breed);
            }
            if (weight.HasValue)
            {
                query = query.Where(c => c.Weight >= weight.Value);
            }
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(c => c.Color == color);
            }

            return query.ToList();
        }
        public async Task<IEnumerable<Cat>> GetCatsByBreedAsync(string breed)
        {
            return await _animalRepository.GetCatsByBreedAsync(breed);
        }
    }
}
