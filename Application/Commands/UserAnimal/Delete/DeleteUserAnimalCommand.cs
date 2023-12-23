using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.Delete
{
    public class DeleteUserAnimalCommand : IRequest
    {
        public Guid UserAnimalId { get; }

        public DeleteUserAnimalCommand(Guid userAnimalId)
        {
            UserAnimalId = userAnimalId;
        }
    }
}
