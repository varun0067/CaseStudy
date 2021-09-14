using FlightServiceAPI.DTO;
using FlightServiceAPI.Models;
using FlightServiceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServiceAPI.Services
{
    public class FlightService : IFightService
    {
        private readonly IFlightRepository flightRepository;

        public FlightService(IFlightRepository _flightRepository)
        {
            flightRepository = _flightRepository;
        }
        public bool ActivateAirline(int airlineId)
        {
            return flightRepository.ActivateAirline(airlineId);
        }

        public bool AddAirline(Airline airline)
        {
            return flightRepository.AddAirline(airline);
        }

        public bool AddFlight(Flight flight)
        {
            return flightRepository.AddFlight(flight);
        }

        public bool BlockAirline(int airlineId)
        {
            return flightRepository.BlockAirline(airlineId);
        }

        public bool DeleteFlight(string flightNumber)
        {
            return flightRepository.DeleteFlight(flightNumber);
        }

        public List<Airline> GetAllAirlines()
        {
            return flightRepository.GetAllAirlines();
        }

        public List<Flight> GetAllFlightsByAirlineId(int airlineId)
        {
            return flightRepository.GetAllFlightsByAirlineId(airlineId);
        }

        public List<Flight> SearchFlight(SearchDTO search)
        {
            return flightRepository.SearchFlight(search);
        }
    }
}
