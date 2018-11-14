namespace ApiCore.Entities
{
    public class LoginInfo
    {
        public string Email { get; }
        public string Password { get; }

        public LoginInfo(string email, 
                         string password)
        {
            Email = email;
            Password = password;
        }
    }
}
