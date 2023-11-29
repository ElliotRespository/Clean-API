using Domain.Models.Animalmodels;
using Infrastructure.Database;
using MediatR;



namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;
        public DeleteCatByIdCommandHandler(MockDatabase mockdatabase)
        {
            _mockDatabase = mockdatabase;
        }

        public Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            var catToDelete = _mockDatabase.allCats.FirstOrDefault(cat => cat.animalID == request.Id);
            if (catToDelete != null)
            {
                _mockDatabase.allCats.Remove(catToDelete);
                return Task.FromResult(catToDelete);
            }
            else
            {
                throw new Exception("Cat lyckades inte deletas");
            }
        }
    }
}
