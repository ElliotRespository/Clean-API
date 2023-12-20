using Domain.Models.UserModels;
using MediatR;


namespace Application.Querys.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserModel>>
    {
    }
}
