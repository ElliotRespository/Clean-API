using Application.Dtos.Animal;
using Domain.Models.Animalmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Animals.Dogs_Cats
{
    public interface IDogService
    {
        Task<Dog> CreateDogAsync(AnimalDto dogDto);
        Task UpdateDogAsync(Guid id, AnimalDto dogDto);
        Task DeleteDogAsync(Guid id);
        Task<IEnumerable<Dog>> GetAllDogsAsync();
        Task<Dog> GetDogByIdAsync(Guid id);
        Task<IEnumerable<Dog>> GetDogsByBreedWeightAndColorAsync(string breed, int? weight, string color);
        Task<IEnumerable<Dog>> GetDogsByBreedAsync(string breed);
    }
}
