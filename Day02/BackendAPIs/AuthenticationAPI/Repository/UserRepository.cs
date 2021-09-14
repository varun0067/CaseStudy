using System.Collections.Generic;
using System.Linq;
using AuthenticationAPI.Context;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserDbContext userDbContext;
        public UserRepository(UserDbContext _userDbContext)
        {
            userDbContext = _userDbContext;
        }

        public User Login(string userName, string password)
        {
            return userDbContext.Users.Where(u => u.Name == userName && u.Password == password).FirstOrDefault();
        }

        public bool RegisterUser(User user)
        {
            userDbContext.Users.Add(user);
            userDbContext.SaveChanges();
            return true;
        }

        public List<User> GetAllUsers()
        {
            return userDbContext.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return userDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public User GetUserByName(string userName)
        {
            return userDbContext.Users.Where(u => u.Name == userName).FirstOrDefault();
        }

        public User GetUserNameExistStatus(string userName)
        {
            return userDbContext.Users.Where(u => u.Name == userName).FirstOrDefault();
        }

        public User GetUserPassWordExistStatus(string password)
        {
            return userDbContext.Users.Where(u => u.Password == password).FirstOrDefault();
        }
    }
}
