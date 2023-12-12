using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using MediatR;


namespace Application.Querys.Cats.GetCatById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public GetCatByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = _mockDatabase.allCats.Where(cat => cat.animalID == request.Id).FirstOrDefault()!;
            return Task.FromResult(wantedCat);
        }
    }
}
