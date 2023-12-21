using Application.Dtos.UserAnimal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Querys.UserAnimals.GetAllUserAnimals
{
    public class GetAllUserAnimalsQuery : IRequest<IEnumerable<UserAnimalDto>>
    {
    }
}
