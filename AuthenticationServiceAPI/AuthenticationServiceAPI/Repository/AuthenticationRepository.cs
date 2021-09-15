using AuthenticationServiceAPI.Context;
using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Models;
using System.Linq;

namespace AuthenticationServiceAPI.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserDBContext userDBContext;

        public AuthenticationRepository(UserDBContext _userDbContext)
        {
            userDBContext = _userDbContext;
        }

        public User CheckUserAlreadyExists(string email)
        {
            return userDBContext.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User Login(UserLoginDTO userLoginDTO)
        {
            return userDBContext.Users.Where(u => u.Email == userLoginDTO.Email && u.Password == userLoginDTO.Password).FirstOrDefault();
        }

        public string Register(User RegisterUser)
        {
            userDBContext.Users.Add(RegisterUser);
            userDBContext.SaveChanges();
            return "User Registered Successfully";
        }
    }
}
