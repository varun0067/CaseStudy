using FlightServiceAPI.DTO;
using FlightServiceAPI.Models;
using FlightServiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFightService flightService;

        public FlightController(IFightService _fightService)
        {
            flightService = _fightService;
        }
        [HttpGet("getAllAirline")]
        public ActionResult GetAllAirline()
        {
            return Ok(flightService.GetAllAirlines());
        }

        [HttpPost("addAirline")]
        public ActionResult AddAirline([FromBody] Airline airline)
        {
            return Ok(flightService.AddAirline(airline));
        }

        [HttpPost("blockAirline/{airlineId}")]
        public ActionResult BlockAirline(int airlineId)
        {
            return Ok(flightService.BlockAirline(airlineId));
        }
        [HttpPost("activateAirline/{airlineId}")]
        public ActionResult ActivateAirline(int airlineId)
        {
            return Ok(flightService.ActivateAirline(airlineId));
        }

        [HttpGet("getAllFlightsByAirlineId/{airlineId}")]
        public ActionResult GetAllFlightsByAirlineId(int airlineId)
        {
            return Ok(flightService.GetAllFlightsByAirlineId(airlineId));
        }

        [HttpPost("addFlight")]
        public ActionResult AddFlight(Flight flight)
        {
            return Ok(flightService.AddFlight(flight));
        }
        [HttpPost("deleteFlight/{flightNumber}")]
        public ActionResult DeleteFlight(string flightNumber)
        {
            return Ok(flightService.DeleteFlight(flightNumber));
        }
        [HttpPost("searchFlight")]
        public ActionResult SearchFlight(SearchDTO search)
        {
            return Ok(flightService.SearchFlight(search));
        }
    }
}
