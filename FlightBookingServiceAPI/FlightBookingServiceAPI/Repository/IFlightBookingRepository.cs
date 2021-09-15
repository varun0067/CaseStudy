using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Models;
using System.Collections.Generic;

namespace FlightBookingServiceAPI.Repository
{
    public interface IFlightBookingRepository
    {
        public List<Booking> GetAllBooking();
        public List<PassengerDetail> GetAllPassengers();
        public string BookTickets(Booking booking,List<PassengerDetail> passengerDetailsInfo);
        public string CancelSingleTicket(PassengerDetail passenger,Booking booking);
        public string CancelAllTickets(List<PassengerDetail> passengers, Booking booking);
        public List<PassengerDetail> GetTicketDetailsOnPNR(string pnr);
        public List<Booking> GetBookingHistoryOfUser(string email);
        public List<string> GetBookedTicketsPNR(BookedTicketsDTO bookedTickets);
        public List<string> GetBookedTicketsSeatNumbers(List<string> pnrs);
        public Booking GetBookingByPNR(string pnr);
        public PassengerDetail GetPassengerDetail(CancelSingleTicketDTO cancelSingleTicket);
    }
}
