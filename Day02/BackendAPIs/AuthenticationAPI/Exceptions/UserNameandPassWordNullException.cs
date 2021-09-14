using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Exceptions
{
    public class UserNameandPassWordNullException:ApplicationException
    {
        public UserNameandPassWordNullException()
        {

        }
        public UserNameandPassWordNullException(string msg):base(msg)
        {

        }
    }
}
