
namespace Application.Dtos.UserAnimal
{
    public class UpdateUserAnimalDto
    {
        public Guid? NewUserId { get; set; }
        public Guid? NewAnimalId { get; set; }
        public Guid UserAnimalId { get; set; }
    }
}
