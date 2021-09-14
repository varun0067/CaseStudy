using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingServiceAPI.Services
{
    public interface IFlightBookingService
    {
        public List<Booking> GetAllBooking();
        public List<PassengerDetail> GetAllPassengers();
        public bool BookTickets(BookingDTO bookingDTO);
        public string CancelSingleTicket(CancelSingleTicketDTO cancelSingleTicket);
        public string CancelAllTickets(string pnr);
        public List<PassengerDetail> GetTicketDetailsOnPNR(string pnr);
        public List<Booking> GetBookingHistoryOfUser(string email);
    }
}
