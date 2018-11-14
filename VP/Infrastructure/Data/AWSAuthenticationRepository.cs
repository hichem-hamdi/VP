using ApiCore.Interfaces;

namespace Infrastructure.Data
{
    public class AWSAuthenticationRepository : IAWSAuthenticationRepository
    {
        public string GetSecretAccessKeyyAccessKeyId(string accessKeyId)
        {
            return "aws secret key";
        }
    }
}
