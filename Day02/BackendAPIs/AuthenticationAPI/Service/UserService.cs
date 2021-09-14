using System.Collections.Generic;
using AuthenticationAPI.Exceptions;
using AuthenticationAPI.Models;
using AuthenticationAPI.Repository;

namespace AuthenticationAPI.Service
{
    public class UserService : IUserService
    {
        readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        #region Register and Login Service Implementation
        public bool RegisterUser(User user)
        {
            var userExist = userRepository.GetUserByName(user.Name);
            if (userExist == null)
            {
                //new Entry
                return userRepository.RegisterUser(user);
            }
            else
            {
                throw new UserAlreadyExistException($"UserName::{user.Name} Already Exist!!");
            }

        }
        public User Login(string userName, string password)
        {
            var userNameExist = userRepository.GetUserNameExistStatus(userName);
            User userPasswordExist = userRepository.GetUserPassWordExistStatus(password);
            if (userNameExist != null && userPasswordExist != null)
            {
                return userRepository.Login(userName, password);
            }
            else
            {
                throw new UserNameandPassWordNullException($"null Exception");
            }

        }

        #endregion
        #region Other Implementation
        public List<User> GetAllUsers()
        {

            return userRepository.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            var userDetails=userRepository.GetUserById(userId);
            if (userDetails != null)
            {
                return userDetails;
            }
            else
            {
                throw new UserNotFoundException($"User with UserId::{userId} Not Found!!");
            }
        }

        public User GetUserByName(string userName)
        {
            var UserDatails=userRepository.GetUserByName(userName);
            if (UserDatails != null)
            {
                return UserDatails;
            }
            else
            {
                throw new UserNotFoundException($"User with UserName::{userName} Not Found!!");
            }
        }
        #endregion


    }
}
