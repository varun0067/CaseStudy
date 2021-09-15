using FlightServiceAPI.DTO;
using FlightServiceAPI.Models;
using System.Collections.Generic;

namespace FlightServiceAPI.Services
{
    public interface IFightService
    {
        public List<Airline> GetAllAirlines();
        public string AddAirline(Airline airline);
        public string BlockAirline(int airlineId);
        public string ActivateAirline(int airlineId);
        public List<Flight> GetAllFlightsByAirlineId(int airlineId);
        public string AddFlight(Flight flight);
        public string DeleteFlight(string flightNumber);
        public List<Flight> SearchFlight(SearchDTO search);

        public HashSet<string> GetAvailableTickets(FlightAvailableTicketsDTO flightAvailableTickets);
    }
}
