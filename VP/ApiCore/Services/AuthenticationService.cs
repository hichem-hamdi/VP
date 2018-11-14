using ApiCore.Entities;
using ApiCore.Interfaces;
using System.Threading.Tasks;

namespace ApiCore.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILoginRepository _loginRepository;

        public AuthenticationService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Task<bool> IsAuthenticated(LoginInfo loginInfo)
        {
            return _loginRepository.IsAuthenticated(loginInfo);
        }
    }
}
