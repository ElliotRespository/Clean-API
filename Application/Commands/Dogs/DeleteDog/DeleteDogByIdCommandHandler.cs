﻿using Application.Commands.Dogs.DeleteDog;
using Domain.Models.Animalmodels;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogByIdCommandHandler(MockDatabase mockdatabase)
        {
            _mockDatabase = mockdatabase;
        }

        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            var dogToDelete = _mockDatabase.allDogs.FirstOrDefault(dog => dog.animalID == request.Id);
            if (dogToDelete != null)
            {
                _mockDatabase.allDogs.Remove(dogToDelete);
                return Task.FromResult(dogToDelete);
            }
            else
            {
                return Task.FromResult<Dog>(null!);
            }
        }
    }
}

