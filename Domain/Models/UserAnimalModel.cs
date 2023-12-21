#nullable disable
using Domain.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserAnimalModel
    {
        [Key]
        public Guid UserAnimalId { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
