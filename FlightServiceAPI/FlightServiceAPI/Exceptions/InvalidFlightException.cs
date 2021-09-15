using System;

namespace FlightServiceAPI.Exceptions
{
    public class InvalidFlightException:ApplicationException
    {
        public InvalidFlightException()
        {

        }
        public InvalidFlightException(string msg):base(msg)
        {

        }
    }
}
