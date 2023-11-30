using Domain.Models.Animalmodels;
using Infrastructure.Database;
using MediatR;


namespace Application.Querys.Dogs.GetDogById
{

    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public GetDogByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {

            Dog wantedDog = _mockDatabase.allDogs.Where(Dog => Dog.animalID == request.Id).FirstOrDefault()!;
            return Task.FromResult(wantedDog);


        }
    }
}
