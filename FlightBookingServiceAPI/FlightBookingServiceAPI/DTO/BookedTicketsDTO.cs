using System;

namespace FlightBookingServiceAPI.DTO
{
    public class BookedTicketsDTO
    {
        public DateTime DepartureDate { get; set; }
        public string FlightNumber { get; set; }
    }
}
