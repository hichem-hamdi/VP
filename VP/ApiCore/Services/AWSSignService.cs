using ApiCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ApiCore.Services
{
    public class AWSSignService : IAWSSignService
    {
        private HMACSHA256 mac = null;


        public string Sign(Dictionary<string, string> parameters, string awsAccessKeyId, string awsSecretKey)
        {
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(awsSecretKey);
            mac = new HMACSHA256(secretKeyBytes);

            parameters.Add("AWSAccessKeyId", awsAccessKeyId);
            parameters.Add("Timestamp", DateTime.UtcNow.ToString("s") + "Z");
            string canonical = Canonicalize(parameters);
            string stringToSign = "GET" + "\n"
                            + "endpoint" + "\n"
                            + "REQUEST_URI" + "\n"
                            + canonical;
            string hmac = Hmac(stringToSign);

            return "http://" + "endpoint" + "REQUEST_URI" + "?" + canonical + "&Signature=" + hmac;
        }

        private string Hmac(string stringToSign)
        {
            string signature = null;
            byte[] bytes = Encoding.UTF8.GetBytes(stringToSign);
            byte[] hmac = mac.ComputeHash(bytes);
            signature = Convert.ToBase64String(hmac);

            return signature;
        }

        private string Canonicalize(Dictionary<string, string> paramters)
        {
            if (paramters == null || paramters.Count == 0)
            {
                return "";
            }

            var sb = new StringBuilder();
            foreach (var item in paramters)
            {
                sb.Append(item.Key);
                sb.Append("=");
                sb.Append(item.Value);
                sb.Append("&");
            }

            return sb.ToString();
        }
    }
}
