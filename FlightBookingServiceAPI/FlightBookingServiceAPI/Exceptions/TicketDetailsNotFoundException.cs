using System;

namespace FlightBookingServiceAPI.Exceptions
{
    public class TicketDetailsNotFoundException:ApplicationException
    {
        public TicketDetailsNotFoundException()
        {

        }
        public TicketDetailsNotFoundException(string msg):base(msg)
        {

        }
    }
}
