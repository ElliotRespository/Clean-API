using Domain.Models.UserModels;
using Infrastructure.Repository.Users;
using MediatR;


namespace Application.Querys.Users.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _userRepository.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ett fel inträffade vid hämtning av alla användare", ex);
            }
        }
    }
}
