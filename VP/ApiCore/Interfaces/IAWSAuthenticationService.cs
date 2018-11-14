namespace ApiCore.Interfaces
{
    public interface IAWSAuthenticationService
    {
        bool IsAutenticated(string email, string awsAccessKeyId, string awsAccessKey);
    }
}
