using FlightBookingServiceAPI.Context;
using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FlightBookingServiceAPI.Repository
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        private readonly FlightBookingDbContext flightBookingDbContext;

        public FlightBookingRepository(FlightBookingDbContext _flightBookingDbContext)
        {
            flightBookingDbContext = _flightBookingDbContext;
        }

        public string BookTickets(Booking booking, List<PassengerDetail> passengerDetailsInfo)
        {
            flightBookingDbContext.Bookings.Add(booking);
            flightBookingDbContext.PassengerDetails.AddRange(passengerDetailsInfo);
            flightBookingDbContext.SaveChanges();
            return "Tickets Successfully Booked";
        }

        public string CancelAllTickets(List<PassengerDetail> passengers,Booking booking)
        {
            foreach (PassengerDetail passenger in passengers)
            {
                flightBookingDbContext.PassengerDetails.Remove(passenger);
            }
            flightBookingDbContext.Bookings.Remove(booking);
            flightBookingDbContext.SaveChanges();
            return "Tickets Canceled Successfully";
        }

        public string CancelSingleTicket(PassengerDetail passenger, Booking booking)
        {

            flightBookingDbContext.PassengerDetails.Remove(passenger);
            booking.NumberOfTickets -= 1;
            flightBookingDbContext.SaveChanges();
            return "Succesfully Cancelled";

        }

        public List<Booking> GetAllBooking()
        {
            return flightBookingDbContext.Bookings.ToList();
        }

        public List<PassengerDetail> GetAllPassengers()
        {
            return flightBookingDbContext.PassengerDetails.ToList();
        }

        public List<Booking> GetBookingHistoryOfUser(string email)
        {
            return flightBookingDbContext.Bookings.Where(b => b.Email == email).ToList();
        }

        public List<PassengerDetail> GetTicketDetailsOnPNR(string pnr)
        {
            return flightBookingDbContext.PassengerDetails.Where(p => p.PNR == pnr).ToList();
        }

        public List<string> GetBookedTicketsPNR(BookedTicketsDTO bookedTickets)
        {
            var bookedPNRs = from b in flightBookingDbContext.Bookings
                             where (b.DepartureDate == bookedTickets.DepartureDate && b.FlightNumber == bookedTickets.FlightNumber)
                             select (b.PNR);

            return bookedPNRs.ToList();
        }

        public List<string> GetBookedTicketsSeatNumbers(List<string> pnrs)
        {
            List<string> bookedSeats = new List<string>();
            foreach (string pnr in pnrs)
            {
                var seats = from p in flightBookingDbContext.PassengerDetails
                            where p.PNR == pnr
                            select (p.SeatNumber);

                bookedSeats.AddRange(seats);
            }

            return bookedSeats;
        }

        public Booking GetBookingByPNR(string pnr)
        {
            return flightBookingDbContext.Bookings.Where(b => b.PNR == pnr).FirstOrDefault();
        }

        public PassengerDetail GetPassengerDetail(CancelSingleTicketDTO cancelSingleTicket)
        {
            return flightBookingDbContext.PassengerDetails.Where(p => p.Email == cancelSingleTicket.Email && p.PNR == cancelSingleTicket.PNR).FirstOrDefault();
        }
    }
}
