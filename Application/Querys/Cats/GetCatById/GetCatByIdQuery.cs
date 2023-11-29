using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Querys.Cats.GetCatById
{
    public class GetCatByIdQuery : IRequest<Cat>
    {
        public GetCatByIdQuery(Guid catid)
        {
            Id = catid;
        }

        public Guid Id { get; set; }
    }
}
