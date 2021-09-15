using System;

namespace FlightServiceAPI.DTO
{
    public enum Trip
    {
        Oneway,
        RoundTrip
    }
    public class SearchDTO
    {
        public DateTime DepartureDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Trip TripType { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
