using FlightServiceAPI.DTO;
using FlightServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServiceAPI.Repository
{
    public class FlightRepository : IFlightRepository
    {
        public List<Airline> Airlines;
        public List<Flight> Flights;

        public FlightRepository()
        {
            Airlines = new List<Airline>();
            Flights = new List<Flight>();
        }
        public bool ActivateAirline(int airlineId)
        {
            var airline = Airlines.Where(a => a.Id == airlineId).FirstOrDefault();
            if (airline != null)
            {
                airline.IsActive = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddAirline(Airline airline)
        {
            Airlines.Add(airline);
            return true;
        }

        public bool AddFlight(Flight flight)
        {
            Flights.Add(flight);
            return true;
        }

        public bool BlockAirline(int airlineId)
        {
            var airline = Airlines.Where(a => a.Id == airlineId).FirstOrDefault();
            if (airline != null && airline.IsActive == true)
            {
                airline.IsActive = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteFlight(string flightNumber)
        {
            var flight = Flights.Where(f => f.FlightNumber == flightNumber).FirstOrDefault();
            if (flight != null)
            {
                Flights.Remove(flight);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Airline> GetAllAirlines()
        {
            return Airlines.ToList();
        }

        public List<Flight> GetAllFlightsByAirlineId(int airlineId)
        {
            return Flights.Where(f => f.AirlineId == airlineId).ToList();

        }

        public List<Flight> SearchFlight(SearchDTO search)
        {
            FlightScheduleDays daySearch = FlightScheduleDays.WeekDays;
            var day = search.DepartureDate.DayOfWeek;
            if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
            {
                daySearch = FlightScheduleDays.WeekEnds;
            }
            var flights = Flights.Where((f => f.Departure == search.From && f.Destination == search.To && (f.ScheduleDays == FlightScheduleDays.Daily || f.ScheduleDays == daySearch))).ToList();

            return flights;
        }
    }
}
