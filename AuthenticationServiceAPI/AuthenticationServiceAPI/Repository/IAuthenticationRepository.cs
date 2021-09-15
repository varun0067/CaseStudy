using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Models;

namespace AuthenticationServiceAPI.Repository
{
    public interface IAuthenticationRepository
    {
        public string Register(User user);
        public User Login(UserLoginDTO userLoginDTO);
        public User CheckUserAlreadyExists(string email);
    }
}
