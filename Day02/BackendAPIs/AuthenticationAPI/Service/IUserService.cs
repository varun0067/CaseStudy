using System.Collections.Generic;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Service
{
    public interface IUserService
    {
        bool RegisterUser(User user);
        User GetUserByName(string userName);
        User GetUserById(int userId);
        List<User> GetAllUsers();
        User Login(string userName, string password);

    }
}
