using System;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingServiceAPI.Models
{
    public class Booking
    {
        [Key]
        public string PNR { get; set; }
        public string FlightNumber { get; set; }
        public string Email { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public int NumberOfTickets { get; set; }
        public double TicketCost { get; set; }
    }
}
