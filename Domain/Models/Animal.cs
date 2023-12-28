#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Animal
    {
        [Key]
        public Guid AnimalID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public ICollection<UserAnimalModel> UserAnimals { get; set; }
    }
}
