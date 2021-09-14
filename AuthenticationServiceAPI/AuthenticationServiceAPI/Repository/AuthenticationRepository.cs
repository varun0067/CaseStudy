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
        public User Login(UserLoginDTO userLoginDTO)
        {
            var User = userDBContext.Users.Where(u => u.Email == userLoginDTO.Email && u.Password == userLoginDTO.Password).FirstOrDefault();
            if (User != null)
            {
                return (User);
            }
            else
                return null;
        }

        public bool Register(User RegisterUser)
        {
            var User= userDBContext.Users.Where(u => u.Email == RegisterUser.Email).FirstOrDefault();
            if (User == null)
            {
                userDBContext.Users.Add(RegisterUser);
                userDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
