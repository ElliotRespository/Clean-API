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

        public ICollection<UserAnimalModel> UserAnimals { get; set; }
    }
}
