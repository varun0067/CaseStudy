using FlightServiceAPI.DTO;
using FlightServiceAPI.Exceptions;
using FlightServiceAPI.Models;
using FlightServiceAPI.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FlightServiceAPI.Services
{
    public class FlightService : IFightService
    {
        private readonly IFlightRepository flightRepository;

        public FlightService(IFlightRepository _flightRepository)
        {
            flightRepository = _flightRepository;
        }
        public string ActivateAirline(int airlineId)
        {
            var airline = flightRepository.GetAirlineById(airlineId);
            if(airline!=null)
            {
                return flightRepository.ActivateAirline(airline);
            }
            else
            {
                throw new InvalidAirlineException($"Airline with id : {airlineId} does not exists");
            }
            
        }

        public string AddAirline(Airline airline)
        {
            return flightRepository.AddAirline(airline);
        }

        public string AddFlight(Flight flight)
        {
            return flightRepository.AddFlight(flight);
        }

        public string BlockAirline(int airlineId)
        {
            var airline = flightRepository.GetAirlineById(airlineId);
            if (airline != null)
            {
                return flightRepository.BlockAirline(airline);
            }
            else
            {
                throw new InvalidAirlineException($"Airline with id : {airlineId} does not exists");
            }
        }

        public string DeleteFlight(string flightNumber)
        {
            var flight = flightRepository.GetFlightByFlightNumber(flightNumber);
            if(flight!=null)
            {
                return flightRepository.DeleteFlight(flight);
            }
            else
            {
                throw new InvalidFlightException($"Airline with Flight Number : {flightNumber} does not exists");
            }
            
        }

        public List<Airline> GetAllAirlines()
        {
            return flightRepository.GetAllAirlines();
        }

        public List<Flight> GetAllFlightsByAirlineId(int airlineId)
        {
            var airline = flightRepository.GetAirlineById(airlineId);
            if (airline != null)
            {
                return flightRepository.GetAllFlightsByAirlineId(airlineId);
            }
            else
            {
                throw new InvalidAirlineException($"Airline with id : {airlineId} does not exists");
            }
        }

        public HashSet<string> GetAvailableTickets(FlightAvailableTicketsDTO flightAvailableTickets)
        {
            var flight = flightRepository.GetFlightByFlightNumber(flightAvailableTickets.FlightNumber);

            HashSet<string> availableTickets = new HashSet<string>();
            
            for(int i = 1; i <= flight.NumberOfBusinessClassSeats; i++)
            {
                availableTickets.Add("BC" + i);
            }

            for (int i = 1; i <= flight.NumberOfEconomyClassSeats; i++)
            {
                availableTickets.Add("EC" + i);
            }

            HttpClient client = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(flightAvailableTickets), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("https://localhost:44322/api/FlightBooking/GetBookedSeats",content).Result;
            
            List<string> bookedTickets = new List<string>();
            bookedTickets = response.Content.ReadAsAsync<List<string>>().Result;
             

            foreach(string b in bookedTickets)
            {
                availableTickets.Remove(b);
            }
            return availableTickets;
        }

        public List<Flight> SearchFlight(SearchDTO search)
        {
            return flightRepository.SearchFlight(search);
        }
    }
}
