using ApiCore.Entities;
using ApiCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class LoginRepository : ILoginRepository
    {
        public Task<bool> IsAuthenticated(LoginInfo loginInfo)
        {
            return Task.FromResult(VPContext.Context.Any(c => c.Email.Equals(loginInfo.Email, StringComparison.InvariantCultureIgnoreCase) &&
                                              c.Password == loginInfo.Password));
        }
    }
}
