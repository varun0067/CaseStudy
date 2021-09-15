using FlightServiceAPI.DTO;
using FlightServiceAPI.Models;
using System.Collections.Generic;

namespace FlightServiceAPI.Repository
{
    public interface IFlightRepository
    {
        public List<Airline> GetAllAirlines();
        public Airline GetAirlineById(int airlineId);
        public string AddAirline(Airline airline);
        public string BlockAirline(Airline airline);
        public string ActivateAirline(Airline airline);
        public List<Flight> GetAllFlightsByAirlineId(int airlineId);
        public string AddFlight(Flight flight);
        public string DeleteFlight(Flight flight);
        public List<Flight> SearchFlight(SearchDTO search);
        public Flight GetFlightByFlightNumber(string flightNumber);
    }
}
