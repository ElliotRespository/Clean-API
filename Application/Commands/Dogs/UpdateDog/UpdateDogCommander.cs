using Domain.Models;
using MediatR;


namespace Application.Commands.Dogs.UpdateDog
{
    public  class UpdateDogCommander : IRequest<Dog>
    {
        public Guid AnimalID { get; set; }
        public string Name { get; set; }

    }
}
