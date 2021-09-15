using System;

namespace AuthenticationServiceAPI.Exceptions
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
