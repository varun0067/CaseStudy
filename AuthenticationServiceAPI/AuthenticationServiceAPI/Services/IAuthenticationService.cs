using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Models;

namespace AuthenticationServiceAPI.Services
{
    public interface IAuthenticationService
    {
        public bool Register(User user);
        public User Login(UserLoginDTO userLoginDTO);
    }
}
