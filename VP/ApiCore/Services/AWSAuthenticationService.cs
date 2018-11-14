using ApiCore.Entities;
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

        public bool IsAutenticated(AwsSignInfo signInfo)
        {
            string userSign = GetSign(signInfo.Email, signInfo.AwsAccessKeyId, signInfo.AwsAccessKey);

            var savedAccessKey = _aWSAuthenticationRepository.GetSecretAccessKeyyAccessKeyId(signInfo.AwsAccessKeyId);
            var originalSign = GetSign(signInfo.Email, signInfo.AwsAccessKeyId, savedAccessKey);

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
