using FlightServiceAPI.DTO;
using FlightServiceAPI.Models;
using FlightServiceAPI.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace FlightServiceAPI.Test
{
    public class FlightRepositoryTest:IClassFixture<FlightDbFixture>
    {
        readonly IFlightRepository flightRepository;
        public FlightRepositoryTest(FlightDbFixture _flightDbFixture)
        {
            flightRepository = new FlightRepository(_flightDbFixture.flightDbContext);
        }


        [Fact]
        public void TestTo_CheckAddAirline()
        {

            Airline airline = new Airline() { AirlineName = "Kingfisher", IsActive = true };

            flightRepository.AddAirline(airline);

            var allAirlines = flightRepository.GetAllAirlines();
            Assert.Contains(airline,allAirlines);
        }

        [Fact]
        public void TestTo_CheckActivateAirline()
        {
            var airline = flightRepository.GetAirlineById(1);

            flightRepository.ActivateAirline(airline);

            var actualAirline = flightRepository.GetAirlineById(1);
            Assert.True(actualAirline.IsActive);
        }

        [Fact]
        public void TestTo_CheckBlockAirline()
        {
            var airline = flightRepository.GetAirlineById(1);

            flightRepository.BlockAirline(airline);

            var actualAirline = flightRepository.GetAirlineById(1);
            Assert.False(actualAirline.IsActive);
        }

        [Fact]
        public void TestTo_CheckAddFlight()
        {
            
            Flight flight = new Flight() { FlightNumber = "AI458", AirlineId = 1, Departure = "Banglore", Destination = "Chennai", StartDate = new DateTime(20 / 09 / 2021), EndDate = new DateTime(27 / 09 / 2031), NumberOfBusinessClassSeats = 30, NumberOfEconomyClassSeats = 20, ScheduleDays = FlightScheduleDays.WeekDays, TicketCost = 3500 };

            flightRepository.AddFlight(flight);

            var allFlights = flightRepository.GetAllFlightsByAirlineId(1);
            Assert.Contains(flight,allFlights);
        }

        [Fact]
        public void TestTo_CheckDeleteFlight()
        {

            Flight flight = flightRepository.GetFlightByFlightNumber("AI458");

            flightRepository.DeleteFlight(flight);

            var allFlights = flightRepository.GetAllFlightsByAirlineId(1);
            Assert.DoesNotContain(flight, allFlights);
        }

        [Fact]
        public void TestTo_CheckSearchFlight()
        {
            SearchDTO search = new SearchDTO() { DepartureDate = new DateTime(22 / 09 / 2021), From = "Banglore", To = "Mumbai" };

            var expectedFlights = new List<Flight>();


            expectedFlights.Add(flightRepository.GetFlightByFlightNumber("AI856"));
            expectedFlights.Add(flightRepository.GetFlightByFlightNumber("AI396"));
            expectedFlights.Add(flightRepository.GetFlightByFlightNumber("DC355"));

            var actualFlights=flightRepository.SearchFlight(search);

            Assert.Equal(expectedFlights, actualFlights);
        }

        [Fact]
        public void TestTo_CheckGetFlightByFlightNumber()
        {

            var result = flightRepository.GetFlightByFlightNumber("AI123");

            Assert.Equal(1, result.AirlineId);
            Assert.Equal("Banglore", result.Departure);
            Assert.Equal("Mumbai", result.Destination);
        }




        [Fact]
        public void TestTo_CheckGetAirlineById()
        {
                        
            var result = flightRepository.GetAirlineById(1);

            Assert.Equal("Air India", result.AirlineName);

        }

    }
}
