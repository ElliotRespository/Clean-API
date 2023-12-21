using Domain.Models.UserModels;
using Infrastructure.Repository.Authrepository;
using MediatR;

namespace Application.Querys.Users.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly AuthRepo _authRepo;

        public LoginQueryHandler(AuthRepo authRepository)
        {
            _authRepo = authRepository;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            UserModel user2 = new UserModel()
            {
                UserName = request.LoginUser.Username,
                Password = request.LoginUser.Password,
            };
            var user = await _authRepo.AuthenticateUser(user2);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            string token = _authRepo.GenerateToken(user);
            return token;
        }
    }
}
