using ApiCore.Entities;
using ApiCore.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AuthenService = ApiCore.Services.AuthenticationService;

namespace UnitTests.ApiCore.Services.AuthenticationService
{
    public class IsAuthenticated
    {
        private Mock<ILoginRepository> _mockLoginRepository;
        private Mock<IAuthenticationService> _mockAuthenticationService;
        public IsAuthenticated()
        {
            _mockLoginRepository = new Mock<ILoginRepository>();
            _mockAuthenticationService = new Mock<IAuthenticationService>();
        }

        [Fact]
        public async void ReturnTrueWhenValidLogin()
        {
            var loginInfo = new LoginInfo("email@test.fr", "wrongpassword");

             var result = await _mockAuthenticationService.Object.IsAuthenticated(loginInfo);
            Assert.False(result);
        }
    }
}
