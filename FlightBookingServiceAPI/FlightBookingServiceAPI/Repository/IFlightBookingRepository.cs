using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingServiceAPI.Repository
{
    public interface IFlightBookingRepository
    {
        public List<Booking> GetAllBooking();
        public List<PassengerDetail> GetAllPassengers();
        public bool BookTickets(Booking booking,List<PassengerDetail> passengerDetailsInfo);
        public string CancelSingleTicket(CancelSingleTicketDTO cancelSingleTicket);
        public string CancelAllTickets(string pnr);
        public List<PassengerDetail> GetTicketDetailsOnPNR(string pnr);
        public List<Booking> GetBookingHistoryOfUser(string email);
    }
}
