using FlightServiceAPI.Context;
using FlightServiceAPI.DTO;
using FlightServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightServiceAPI.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDbContext flightDbContext;

        public FlightRepository(FlightDbContext _flightDbContext)
        {
            flightDbContext = _flightDbContext;
        }
        public string ActivateAirline(Airline airline)
        {
            airline.IsActive = true;
            flightDbContext.SaveChanges();
            return "Airline Activated";
        }

        public string AddAirline(Airline airline)
        {
            flightDbContext.Airlines.Add(airline);
            flightDbContext.SaveChanges();
            return "Airline Added successfully";
        }

        public string AddFlight(Flight flight)
        {
            flightDbContext.Flights.Add(flight);
            flightDbContext.SaveChanges();
            return "Flight Added successfully";
        }

        public string BlockAirline(Airline airline)
        {
            airline.IsActive = false;
            flightDbContext.SaveChanges();
            return "Airline Blocked";
        }

        public string DeleteFlight(Flight flight)
        {

            flightDbContext.Flights.Remove(flight);
            flightDbContext.SaveChanges();
            return "Flight deleted successfully";
        }
        public Flight GetFlightByFlightNumber(string flightNumber)
        {
            return flightDbContext.Flights.Where(f => f.FlightNumber == flightNumber).FirstOrDefault();
        }
        public Airline GetAirlineById(int airlineId)
        {
            return flightDbContext.Airlines.Where(a => a.Id == airlineId).FirstOrDefault();
        }

        public List<Airline> GetAllAirlines()
        {
            return flightDbContext.Airlines.ToList();
        }

        public List<Flight> GetAllFlightsByAirlineId(int airlineId)
        {
            return  flightDbContext.Flights.Where(f => f.AirlineId == airlineId).ToList();

        }

        public List<Flight> SearchFlight(SearchDTO search)
        {
            FlightScheduleDays daySearch = FlightScheduleDays.WeekDays;
            var day = search.DepartureDate.DayOfWeek;
            if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
            {
                daySearch = FlightScheduleDays.WeekEnds;
            }
            var flights = flightDbContext.Flights.Where((f => f.Departure == search.From && f.Destination == search.To && (f.ScheduleDays == FlightScheduleDays.Daily || f.ScheduleDays == daySearch))).ToList();

            return flights;
        }
    }
}
