using Domain.Models.Animalmodels;
using Infrastructure.Database;
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
                Name = request.Cat.Name,
                animalID = Guid.NewGuid(),
                LikesToPlay = request.Cat.LikesToPlay
            };
            _mockDatabase.allCats.Add(newCat);
            return Task.FromResult(newCat);
        }
    }
}
