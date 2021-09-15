using System;

namespace FlightBookingServiceAPI.Exceptions
{
    public class CancelTicketTimeLimitException:ApplicationException
    {
        public CancelTicketTimeLimitException()
        {

        }
        public CancelTicketTimeLimitException(string msg):base(msg)
        {

        }
    }
}
