using System.Collections.Generic;

namespace ApiCore.Interfaces
{
    public interface IAWSSignService
    {
        string Sign(Dictionary<string, string> parameters, string awsAccessKeyId, string awsSecretKey);
    }
}
