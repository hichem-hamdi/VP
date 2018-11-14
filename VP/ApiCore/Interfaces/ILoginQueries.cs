using ApiCore.Entities;
using System.Threading.Tasks;

namespace ApiCore.Interfaces
{
    public interface ILoginQueries
    {
        Task<bool> IsAuthenticated(LoginInfo loginInfo);
    }
}
