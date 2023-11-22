using System;
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogCommand : IRequest<Dog>
    {
        public Guid AnimalID { get; set; }
    }
}
