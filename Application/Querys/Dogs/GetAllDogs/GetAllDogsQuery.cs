using Domain.Models.Animalmodels;
using MediatR;

namespace Application.Querys.Dogs.GetAllDogs
{
    public class GetAllDogsQuery : IRequest<List<Dog>>
    {

    }
}
