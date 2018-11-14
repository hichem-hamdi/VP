using ApiCore.Interfaces;
using System.Collections.Generic;

namespace ApiCore.Services
{
    public class AWSAuthenticationService : IAWSAuthenticationService
    {
        private readonly IAWSAuthenticationRepository _aWSAuthenticationRepository;
        private readonly IAWSSignService _aWSSignService;
        public AWSAuthenticationService(IAWSAuthenticationRepository aWSAuthenticationRepository,
                                        IAWSSignService aWSSignService)
        {
            _aWSAuthenticationRepository = aWSAuthenticationRepository;
            _aWSSignService = aWSSignService;
        }

        public bool IsAutenticated(string email, string awsAccessKeyId, string awsAccessKey)
        {
            string userSign = GetSign(email, awsAccessKeyId, awsAccessKey);

            var savedAccessKey = _aWSAuthenticationRepository.GetSecretAccessKeyyAccessKeyId(awsAccessKeyId);
            var originalSign = GetSign(email, awsAccessKeyId, savedAccessKey);

            return userSign == originalSign;
        }

        private string GetSign(string email, string awsAccessKeyId, string awsAccessKey)
        {
            Dictionary<string, string> parameters;
            parameters = new Dictionary<string, string>();
            parameters.Add("email", email);
            return _aWSSignService.Sign(parameters, awsAccessKeyId, awsAccessKey);
        }
    }
}
