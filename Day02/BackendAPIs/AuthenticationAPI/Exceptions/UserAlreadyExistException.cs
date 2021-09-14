using System;

namespace AuthenticationAPI.Exceptions
{
    public class UserAlreadyExistException:ApplicationException
    {
        public UserAlreadyExistException()
        {

        }
        public UserAlreadyExistException(string msg):base(msg)
        {

        }
    }
}
