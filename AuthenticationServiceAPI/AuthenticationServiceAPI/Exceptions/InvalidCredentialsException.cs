﻿using System;

namespace AuthenticationServiceAPI.Exceptions
{
    public class InvalidCredentialsException:ApplicationException
    {
        public InvalidCredentialsException()
        {
                
        }
        public InvalidCredentialsException(string msg):base(msg)
        {

        }
    }
}
