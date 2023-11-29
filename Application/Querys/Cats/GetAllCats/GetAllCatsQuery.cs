using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Querys.Cats.GetAllCats
{
    public class GetAllCatsQuery : IRequest<List<Cat>>
    {

    }
}
