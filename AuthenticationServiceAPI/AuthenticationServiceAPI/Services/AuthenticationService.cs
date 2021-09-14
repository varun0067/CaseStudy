using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Models;
using AuthenticationServiceAPI.Repository;

namespace AuthenticationServiceAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository authenticationRepository;

        public AuthenticationService(IAuthenticationRepository _authenticationRepository)
        {
            authenticationRepository = _authenticationRepository;
        }
        public User Login(UserLoginDTO userLoginDTO)
        {
            return authenticationRepository.Login(userLoginDTO);
        }

        public bool Register(User user)
        {
            return authenticationRepository.Register(user);
        }
    }
}
