using ApiCore.Entities;
using ApiCore.Services;
using Infrastructure.Data;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApiCore.Services.AuthenticationServiceTest
{
    public class IsAuthenticated
    {
        [Fact]
        public async void ReturnsTrue()
        {
            var loginInfo = new LoginInfo("email1@test.fr", "email1");
            bool result = await GetResult(loginInfo);

            Assert.True(result);
        }

        [Fact]
        public async void ReturnsFalse()
        {
            var loginInfo = new LoginInfo("email@test.fr", "wrongpassword");
            bool result = await GetResult(loginInfo);

            Assert.False(result);
        }

        private static async Task<bool> GetResult(LoginInfo loginInfo)
        {
            var sut = new AuthenticationService(new LoginRepository());
            var result = await sut.IsAuthenticated(loginInfo);
            return result;
        }
    }
}
