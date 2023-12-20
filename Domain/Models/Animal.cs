#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Animal
    {
        [Key]
        public Guid animalID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
