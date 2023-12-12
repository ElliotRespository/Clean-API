using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using MediatR;

namespace Application.Querys.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllDogsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromMockDB = _mockDatabase.allDogs;
            return Task.FromResult(allDogsFromMockDB);
        }
    }
}
