using FlightServiceAPI.DTO;
using FlightServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServiceAPI.Repository
{
    public interface IFlightRepository
    {
        public List<Airline> GetAllAirlines();
        public bool AddAirline(Airline airline);
        public bool BlockAirline(int airlineId);
        public bool ActivateAirline(int airlineId);
        public List<Flight> GetAllFlightsByAirlineId(int airlineId);
        public bool AddFlight(Flight flight);
        public bool DeleteFlight(string flightNumber);
        public List<Flight> SearchFlight(SearchDTO search);
    }
}
