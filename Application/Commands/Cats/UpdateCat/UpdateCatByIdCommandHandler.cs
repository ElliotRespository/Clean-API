using Domain.Models.Animalmodels;
using Infrastructure.Database;
using MediatR;


namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateCatByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            var catToUpdate = _mockDatabase.allCats.FirstOrDefault(cat => cat.animalID == request.Id);
            if (catToUpdate != null)
            {
                catToUpdate.Name = request.UpdatedCat.Name;
                catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;
                return Task.FromResult(catToUpdate);
            }
            else
            {
                throw new Exception("Cat lyckades inte updateras");
            }
        }
    }
}
