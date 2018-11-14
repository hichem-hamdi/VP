using ApiCore.Entities;
using System.Threading.Tasks;

namespace ApiCore.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(LoginInfo loginInfo);
    }
}
