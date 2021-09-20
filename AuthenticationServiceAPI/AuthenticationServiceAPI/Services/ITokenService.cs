namespace AuthenticationServiceAPI.Services
{
    public interface ITokenService
    {
        string GenerateToken(string email, string password,bool admin);
    }
}
