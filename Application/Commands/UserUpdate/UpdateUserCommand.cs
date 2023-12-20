using Application.Dtos.User;
using Domain.Models.UserModels;
using MediatR;

namespace Application.Commands.UserUpdate
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        public Guid UserId { get; }
        public UserUpdateDto UserUpdateDto { get; }

        public UpdateUserCommand(Guid userId, UserUpdateDto userUpdateDto)
        {
            UserId = userId;
            UserUpdateDto = userUpdateDto;
        }
    }
}
