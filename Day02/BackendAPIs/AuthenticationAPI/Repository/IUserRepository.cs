using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repository
{
    public interface IUserRepository
    {
        bool RegisterUser(User user);
        User GetUserByName(string userName);
        User GetUserById(int userId);
        List<User> GetAllUsers();
        User Login(string userName, string password);
        User GetUserNameExistStatus(string userName);
        User GetUserPassWordExistStatus(string userName);
    }
}
