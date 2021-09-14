using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingServiceAPI.Repository
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        public List<Booking> Bookings;
        public List<PassengerDetail> PassengerDetails;

        public FlightBookingRepository()
        {
            Bookings = new List<Booking>();
            PassengerDetails = new List<PassengerDetail>();
        }

        public bool BookTickets(Booking booking, List<PassengerDetail> passengerDetailsInfo)
        {
            Bookings.Add(booking);
            PassengerDetails.AddRange(passengerDetailsInfo);
            return true;
        }

        public string CancelAllTickets(string pnr)
        {
            var booking = Bookings.Where(b => b.PNR == pnr).FirstOrDefault();

            var day = booking.DepartureDate - DateTime.Now;
            if (day.TotalHours >= 24)
            {
                var passengers = PassengerDetails.Where(p => p.PNR == pnr).ToList();
                foreach (PassengerDetail passenger in passengers)
                {
                    PassengerDetails.Remove(passenger);
                }
                Bookings.Remove(booking);
                return "Tickets Canceled Successfully";
            }
            else
            {
                return "Cannot Cancel the ticket when departure time is less than 24 hours.";
            }
           
        }

        public string CancelSingleTicket(CancelSingleTicketDTO cancelSingleTicket)
        {
            var booking = Bookings.Where(b => b.PNR == cancelSingleTicket.PNR).FirstOrDefault();
            if (booking != null)
            {
                var day = booking.DepartureDate - DateTime.Now;
                if (day.TotalHours >= 24)
                {
                    var passengerDetail = PassengerDetails.Where(p => p.Email == cancelSingleTicket.Email && p.PNR == cancelSingleTicket.PNR).FirstOrDefault();
                    if (passengerDetail != null)
                    {
                        PassengerDetails.Remove(passengerDetail);
                        booking.NumberOfTickets -= 1;
                        return "Succesfully Cancelled";
                    }
                    else
                    {
                        return "No ticket details found.";
                    }
                }
                else
                {
                    return "Cannot Cancel the ticket when departure time is less than 24 hours.";
                    ;
                }
            }
            else
            {
                return "No ticket details found.";
            }

        }

        public List<Booking> GetAllBooking()
        {
            return Bookings.ToList();
        }

        public List<PassengerDetail> GetAllPassengers()
        {
            return PassengerDetails.ToList();
        }

        public List<Booking> GetBookingHistoryOfUser(string email)
        {
            return Bookings.Where(b => b.Email == email).ToList();
        }

        public List<PassengerDetail> GetTicketDetailsOnPNR(string pnr)
        {
            return PassengerDetails.Where(p => p.PNR == pnr).ToList();
        }
    }
}
