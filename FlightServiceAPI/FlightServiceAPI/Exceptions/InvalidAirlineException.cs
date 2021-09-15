using System;

namespace FlightServiceAPI.Exceptions
{
    public class InvalidAirlineException:ApplicationException
    {
        public InvalidAirlineException()
        {
                
        }
        public InvalidAirlineException(string msg):base(msg)
        {

        }
    }
}
