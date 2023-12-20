using Application.Dtos.User;
using MediatR;


namespace Application.Querys.Users
{
    public class LoginQuery : IRequest<string>
    {
        public LoginQuery(UserInfoDto loginUser)
        {
            LoginUser = loginUser;
        }

        public UserInfoDto LoginUser { get; }
    }
}
