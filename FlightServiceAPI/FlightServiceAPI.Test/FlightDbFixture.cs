using FlightServiceAPI.Context;
using FlightServiceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlightServiceAPI.Test
{
    public class FlightDbFixture
    {
        public readonly FlightDbContext flightDbContext;

        public FlightDbFixture()
        {
            flightDbContext = new FlightDbContext(new DbContextOptionsBuilder<FlightDbContext>().UseInMemoryDatabase("FlightTestDb").Options);
            flightDbContext.Airlines.Add(new Airline() {Id=1, AirlineName = "Air India", IsActive = true });
            flightDbContext.Airlines.Add(new Airline() {Id=2, AirlineName = "Deccan", IsActive = true });
            flightDbContext.Flights.Add(new Flight() {  FlightNumber = "AI123", AirlineId = 1, Departure = "Banglore", Destination = "Mumbai", StartDate = new DateTime(20 / 09 / 2021), EndDate = new DateTime(27 / 09 / 2031), NumberOfBusinessClassSeats = 30, NumberOfEconomyClassSeats = 20, ScheduleDays = FlightScheduleDays.WeekEnds, TicketCost = 3000 });
            flightDbContext.Flights.Add(new Flight() { FlightNumber = "AI856", AirlineId = 1, Departure = "Banglore", Destination = "Mumbai", StartDate = new DateTime(20 / 09 / 2021), EndDate = new DateTime(27 / 09 / 2031), NumberOfBusinessClassSeats = 30, NumberOfEconomyClassSeats = 20, ScheduleDays = FlightScheduleDays.WeekDays, TicketCost = 3000 });
            flightDbContext.Flights.Add(new Flight() { FlightNumber = "AI396", AirlineId = 1, Departure = "Banglore", Destination = "Mumbai", StartDate = new DateTime(20 / 09 / 2021), EndDate = new DateTime(27 / 09 / 2031), NumberOfBusinessClassSeats = 30, NumberOfEconomyClassSeats = 20, ScheduleDays = FlightScheduleDays.Daily, TicketCost = 3000 });
            flightDbContext.Flights.Add(new Flight() { FlightNumber = "DC123",  AirlineId = 2, Departure = "Mumbai", Destination = "Banglore", StartDate = new DateTime(20 / 09 / 2021), EndDate = new DateTime(27 / 09 / 2031),  NumberOfBusinessClassSeats = 30, NumberOfEconomyClassSeats = 20, ScheduleDays = FlightScheduleDays.WeekEnds, TicketCost = 3000 });
            flightDbContext.Flights.Add(new Flight() { FlightNumber = "DC355", AirlineId = 2, Departure = "Banglore", Destination = "Mumbai", StartDate = new DateTime(20 / 09 / 2021), EndDate = new DateTime(27 / 09 / 2031), NumberOfBusinessClassSeats = 30, NumberOfEconomyClassSeats = 20, ScheduleDays = FlightScheduleDays.WeekDays, TicketCost = 3000 });

            flightDbContext.SaveChanges();
        }
    }
}
