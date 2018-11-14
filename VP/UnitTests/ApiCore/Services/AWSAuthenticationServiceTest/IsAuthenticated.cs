using ApiCore.Entities;
using ApiCore.Interfaces;
using ApiCore.Services;
using Moq;
using Xunit;

namespace UnitTests.ApiCore.Services.AWSAuthenticationServiceTest
{
    public class IsAuthenticated
    {
        private Mock<IAWSAuthenticationRepository> _mockAwsAuthenticationRepository;
        private Mock<IAWSAuthenticationService> _mockAwsAuthenticationService;

        public IsAuthenticated()
        {
            _mockAwsAuthenticationRepository = new Mock<IAWSAuthenticationRepository>();
            _mockAwsAuthenticationRepository.Setup(s => s.GetSecretAccessKeyyAccessKeyId("aws secret key id"))
                .Returns("aws secret key");

            _mockAwsAuthenticationService = new Mock<IAWSAuthenticationService>();
        }

        [Fact]
        public void ReturnsTrue()
        {
            var signInfo = new AwsSignInfo("email@test.fr", "aws secret key id", "aws secret key");
            bool result = GetResult(signInfo);

            Assert.True(result);
        }

        [Fact]
        public void ReturnsFalse()
        {
            var signInfo = new AwsSignInfo("email@test.fr", "aws secret key id", "wrong aws secret key");
            bool result = GetResult(signInfo);

            Assert.False(result);
        }

        private bool GetResult(AwsSignInfo signInfo)
        {
            var sut = new AWSAuthenticationService(_mockAwsAuthenticationRepository.Object, new AWSSignService());
            var result = sut.IsAutenticated(signInfo);
            return result;
        }
    }
}

