using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Models;
using FlightBookingServiceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingServiceAPI.Services
{
    public class FlightBookingService : IFlightBookingService
    {
        private readonly IFlightBookingRepository flightBookingRepository;

        public FlightBookingService(IFlightBookingRepository _flightBookingRepository)
        {
            flightBookingRepository = _flightBookingRepository;
        }
        public bool BookTickets(BookingDTO bookingDTO)
        {
            string pnr = GeneratePNR();
            Booking booking = new Booking() { PNR = pnr,FlightNumber=bookingDTO.FlightNumber,Email = bookingDTO.Email,
                                              Departure=bookingDTO.Departure,Destination=bookingDTO.Destination
                                              ,DepartureDate = bookingDTO.DepartureDate, NumberOfTickets = bookingDTO.NumberOfTickets
                                                ,TicketCost=bookingDTO.TicketCost};

            List<PassengerDetail> passengers = new List<PassengerDetail>();
            foreach(PassengerDTO passenger in bookingDTO.Passengers)
            {

                PassengerDetail passengerDetail = new PassengerDetail() { PNR = pnr, Email = passenger.Email, Gender = passenger.Gender, Age = passenger.Age, Name = passenger.Name, Meals = passenger.Meals, SeatNumber = passenger.SeatNumber };
                passengers.Add(passengerDetail);
            }

            return flightBookingRepository.BookTickets(booking, passengers);
        }

        public string CancelAllTickets(string pnr)
        {
            return flightBookingRepository.CancelAllTickets(pnr);
        }

        public string CancelSingleTicket(CancelSingleTicketDTO cancelSingleTicket)
        {
            return flightBookingRepository.CancelSingleTicket(cancelSingleTicket);
        }

        public List<Booking> GetBookingHistoryOfUser(string email)
        {
            return flightBookingRepository.GetBookingHistoryOfUser(email);
        }

        public List<PassengerDetail> GetTicketDetailsOnPNR(string pnr)
        {
            return flightBookingRepository.GetTicketDetailsOnPNR(pnr);
        }

        private static string GeneratePNR()
        {
            return System.Guid.NewGuid().ToString();
        }

        public List<Booking> GetAllBooking()
        {
            return flightBookingRepository.GetAllBooking();
        }

        public List<PassengerDetail> GetAllPassengers()
        {
            return flightBookingRepository.GetAllPassengers();
        }
    }
}
