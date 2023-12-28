using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserAnimal
{
    public class UserAnimalDto
    {
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
        public Guid UserAnimalId { get; set; }
    }
}
