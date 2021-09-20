using FlightServiceAPI.Exceptions;
using FlightServiceAPI.Models;
using FlightServiceAPI.Repository;
using FlightServiceAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FlightServiceAPI.Test
{
    public class FlightServiceTest
    {
        private IFightService flightService;
        private Mock<IFlightRepository> mock;
        public FlightServiceTest()
        {
            mock = new Mock<IFlightRepository>();
            flightService = new FlightService(mock.Object);

        }

        [Fact]
        public void TestToAddAirline()
        {
            Airline airline = new Airline() { Id = 0, AirlineName = "Alaska", IsActive = true };
            mock.Setup(p => p.AddAirline(airline)).Returns("Airline Added");
            var result = flightService.AddAirline(airline);
            Assert.Equal("Airline Added", result);

        }

        [Fact]
        public void TestTo_ActivateAirlineWithValidAirlineId()
        {
            Airline airline = new Airline() { Id = 1, AirlineName = "Air India", IsActive = true };

            mock.Setup(p => p.GetAirlineById(1)).Returns(airline);

            mock.Setup(p => p.ActivateAirline(airline)).Returns("Airline Activated");
            var result = flightService.ActivateAirline(1);
            Assert.Equal("Airline Activated", result);

        }

        [Fact]
        public void TestTo_ActivateAirlineWithInValidAirlineId()
        {
            Airline airline = null;

            mock.Setup(p => p.GetAirlineById(14)).Returns(airline);

            Assert.ThrowsAny<InvalidAirlineException>(()=>flightService.ActivateAirline(14));

        }


        [Fact]
        public void TestTo_BlockAirlineWithValidAirlineId()
        {
            Airline airline = new Airline() { Id = 1, AirlineName = "Air India", IsActive = true };

            mock.Setup(p => p.GetAirlineById(1)).Returns(airline);

            mock.Setup(p => p.BlockAirline(airline)).Returns("Airline Blocked");
            var result = flightService.BlockAirline(1);
            Assert.Equal("Airline Blocked", result);

        }

        [Fact]
        public void TestTo_BlockAirlineWithInvalidAirlineId()
        {
            Airline airline = null;

            mock.Setup(p => p.GetAirlineById(14)).Returns(airline);

            Assert.ThrowsAny<InvalidAirlineException>(() => flightService.BlockAirline(14));

        }

        [Fact]
        public void TestTo_CheckAddFlight()
        {
            Flight flight = new Flight() { AirlineId = 1, Departure = "Indore", Destination = "Pune", StartDate = new DateTime(20 / 09 / 2021), EndDate = new DateTime(27 / 09 / 2021), FlightNumber = "GO123", NumberOfBusinessClassSeats = 30, NumberOfEconomyClassSeats = 20, ScheduleDays = FlightScheduleDays.WeekDays, TicketCost = 3000 };

            mock.Setup(p => p.AddFlight(flight)).Returns("Flight Added");
            var result = flightService.AddFlight(flight);
            Assert.Equal("Flight Added", result);

        }



        [Fact]
        public void TestTo_CheckDeleteAirline()
        {
            Flight flight = new Flight() { AirlineId = 1, Departure = "Indore", Destination = "Pune", StartDate = new DateTime(20 / 09 / 2021), EndDate = new DateTime(27 / 09 / 2021), FlightNumber = "GO123", NumberOfBusinessClassSeats = 30, NumberOfEconomyClassSeats = 20, ScheduleDays = FlightScheduleDays.WeekEnds, TicketCost = 3000 };

            mock.Setup(p => p.GetFlightByFlightNumber("GO123")).Returns(flight);

            mock.Setup(p => p.DeleteFlight(flight)).Returns("Flight Deleted");
            var result = flightService.DeleteFlight("GO123");
            Assert.Equal("Flight Deleted", result);

        }


    }
}
