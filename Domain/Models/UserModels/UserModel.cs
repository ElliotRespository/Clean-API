#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.UserModels
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        public virtual ICollection<UserAnimal> UserAnimals { get; set; } = new List<UserAnimal>();
    }
}
