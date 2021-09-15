using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Models;
using System.Collections.Generic;

namespace FlightBookingServiceAPI.Services
{
    public interface IFlightBookingService
    {
        public List<Booking> GetAllBooking();
        public List<PassengerDetail> GetAllPassengers();
        public string BookTickets(BookingDTO bookingDTO);
        public string CancelSingleTicket(CancelSingleTicketDTO cancelSingleTicket);
        public string CancelAllTickets(string pnr);
        public List<PassengerDetail> GetTicketDetailsOnPNR(string pnr);
        public List<Booking> GetBookingHistoryOfUser(string email);
        public List<string> GetBookedTicketsSeatNumber(BookedTicketsDTO bookedTickets);
    }
}
