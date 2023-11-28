﻿using System;
using Domain.Models.Animalmodels;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public DeleteDogByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}