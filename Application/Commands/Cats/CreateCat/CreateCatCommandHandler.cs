using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using MediatR;


namespace Application.Commands.Cats.CreateCat
{
    public class CreateCatCommandHandler : IRequestHandler<CreateCatCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;
        public CreateCatCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(CreateCatCommand request, CancellationToken cancellationToken)
        {
            var newCat = new Cat
            {
                Name = request.NewCat.Name,
                animalID = Guid.NewGuid(),
                LikesToPlay = request.NewCat.LikesToPlay
            };
            _mockDatabase.allCats.Add(newCat);
            return Task.FromResult(newCat);
        }
    }
}
