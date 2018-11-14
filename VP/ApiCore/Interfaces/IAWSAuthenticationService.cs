using ApiCore.Entities;

namespace ApiCore.Interfaces
{
    public interface IAWSAuthenticationService
    {
        bool IsAutenticated(AwsSignInfo signInfo);
    }
}
