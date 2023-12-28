using Application.Dtos.Animal;
using Domain.Models.Animalmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Animals.Dogs_Cats
{
    public interface ICatService
    {
        Task<Cat> CreateCatAsync(AnimalDto catDto);
        Task UpdateCatAsync(Guid id, AnimalDto catDto);
        Task DeleteCatAsync(Guid id);
        Task<IEnumerable<Cat>> GetAllCatsAsync();
        Task<Cat> GetCatByIdAsync(Guid id);
        Task<IEnumerable<Cat>> GetCatsByBreedWeightAndColorAsync(string breed, int? weight, string color);
        Task<IEnumerable<Cat>> GetCatsByBreedAsync(string breed);

    }
}
