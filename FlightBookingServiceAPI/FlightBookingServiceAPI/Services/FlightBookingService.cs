using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Exceptions;
using FlightBookingServiceAPI.Models;
using FlightBookingServiceAPI.Repository;
using System;
using System.Collections.Generic;

namespace FlightBookingServiceAPI.Services
{
    public class FlightBookingService : IFlightBookingService
    {
        private readonly IFlightBookingRepository flightBookingRepository;

        public FlightBookingService(IFlightBookingRepository _flightBookingRepository)
        {
            flightBookingRepository = _flightBookingRepository;
        }
        public string BookTickets(BookingDTO bookingDTO)
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
            var booking = flightBookingRepository.GetBookingByPNR(pnr);
            if (booking != null)
            {
                var day = booking.DepartureDate - DateTime.Now;
                if (day.TotalHours >= 24)
                {
                    var passengers = flightBookingRepository.GetTicketDetailsOnPNR(pnr);
                    return flightBookingRepository.CancelAllTickets(passengers, booking);
                }
                else
                {
                    throw new CancelTicketTimeLimitException("Cannot Cancel the ticket when departure time is less than 24 hours.");
                }
            }
            else
            {
                throw new TicketDetailsNotFoundException($"Ticket Details with PNR : {pnr} not found");
            }     
        }

        public string CancelSingleTicket(CancelSingleTicketDTO cancelSingleTicket)
        {
            var booking = flightBookingRepository.GetBookingByPNR(cancelSingleTicket.PNR);
            if (booking != null)
            {
                var day = booking.DepartureDate - DateTime.Now;
                if (day.TotalHours >= 24)
                {
                    var passengerDetail = flightBookingRepository.GetPassengerDetail(cancelSingleTicket);
                    if (passengerDetail != null)
                    {
                        return flightBookingRepository.CancelSingleTicket(passengerDetail, booking);
                    }
                    else
                    {
                        throw new TicketDetailsNotFoundException($"Ticket Details with Email : {cancelSingleTicket.Email} not found");
                    }
                }
                else
                {
                    throw new CancelTicketTimeLimitException("Cannot Cancel the ticket when departure time is less than 24 hours.");
                }
            }
            else
            {
                throw new TicketDetailsNotFoundException($"Ticket Details with PNR : {cancelSingleTicket.PNR} not found");
            }
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

        public List<string> GetBookedTicketsSeatNumber(BookedTicketsDTO bookedTickets)
        {
            var pnrs = flightBookingRepository.GetBookedTicketsPNR(bookedTickets);
            return flightBookingRepository.GetBookedTicketsSeatNumbers(pnrs);
        }

    }
}
