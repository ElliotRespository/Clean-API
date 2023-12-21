using Domain.Models.UserModels;
using MediatR;


namespace Application.Querys.Users.GetAll
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserModel>>
    {
    }
}
