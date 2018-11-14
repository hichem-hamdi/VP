using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCore.Entities
{
    public class AwsSignInfo
    {
        public string Email { get; }
        public string AwsAccessKeyId { get; }
        public string AwsAccessKey { get; set; }
        public AwsSignInfo(string email,
                           string awsAccessKeyId,
                           string awsAccessKey)
        {
            Email = email;
            AwsAccessKeyId = awsAccessKeyId;
            AwsAccessKey = awsAccessKey;
        }
    }
}
