

using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Animal
    {
        [Key]
        public Guid animalID { get; set; }
        public required string Name { get; set; }
    }
}
