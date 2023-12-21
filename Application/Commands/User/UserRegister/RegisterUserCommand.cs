using Application.Dtos.User;
using Domain.Models.UserModels;
using MediatR;


namespace Application.Commands.User.UserRegister
{
    public class RegisterUserCommand : IRequest<UserModel>
    {
        public RegisterUserCommand(UserInfoDto newUser)
        {
            NewUser = newUser;
        }

        public UserInfoDto NewUser { get; }
    }
}

