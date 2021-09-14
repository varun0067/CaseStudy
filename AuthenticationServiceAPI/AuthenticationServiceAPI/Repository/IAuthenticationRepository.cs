using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Models;

namespace AuthenticationServiceAPI.Repository
{
    public interface IAuthenticationRepository
    {
        public bool Register(User user);
        public User Login(UserLoginDTO userLoginDTO);
    }
}
