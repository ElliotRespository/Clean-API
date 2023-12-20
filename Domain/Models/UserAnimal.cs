#nullable disable
using Domain.Models.UserModels;

namespace Domain.Models
{
    public class UserAnimal
    {
        public Guid UserId { get; set; }
        public UserModel user { get; set; }

        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
