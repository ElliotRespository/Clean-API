using Domain.Models.Animalmodels;
using MediatR;

namespace Application.Querys.Dogs.GetDogById
{
    public class GetDogByIdQuery : IRequest<Dog>
    {
        public GetDogByIdQuery(Guid dogid)
        {
            Id = dogid;
        }

        public Guid Id { get; set; }
    }
}
