using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Exceptions;
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
            User user=authenticationRepository.Login(userLoginDTO);
            if(user!=null)
            {
                return user;
            }
            else
            {
                throw new InvalidCredentialsException("Invalid Credentials");
            }
        }

        public string Register(User user)
        {
            User userExists = authenticationRepository.CheckUserAlreadyExists(user.Email);

            if (userExists == null)
                return authenticationRepository.Register(user);
            else
                throw new UserAlreadyExistException($"User with Username {user.Email} already exists.Please try with other email.");
        }
    }
}
