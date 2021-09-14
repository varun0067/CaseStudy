using FlightBookingServiceAPI.DTO;
using FlightBookingServiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightBookingController : ControllerBase
    {
        private readonly IFlightBookingService flightBookingService;

        public FlightBookingController(IFlightBookingService _flightBookingService)
        {
            flightBookingService = _flightBookingService;
        }
        [HttpGet("AllBookings")]
        public ActionResult GetAllBookings()
        {
            return Ok(flightBookingService.GetAllBooking());
        }
        [HttpGet("AllPassengers")]
        public ActionResult GetAllPassengers()
        {
            return Ok(flightBookingService.GetAllPassengers());
        }
        [HttpPost("BookTickets")]
        public ActionResult BookTickets(BookingDTO booking)
        {
            return Ok(flightBookingService.BookTickets(booking));
        }

        [HttpDelete("CancelSingleTickets")]
        public ActionResult CancelSingleTickets(CancelSingleTicketDTO cancelSingleTicket)
        {
            return Ok(flightBookingService.CancelSingleTicket(cancelSingleTicket));
        }

        [HttpDelete("CancelAllTickets/{pnr}")]
        public ActionResult CancelAllTickets(string pnr)
        {
            return Ok(flightBookingService.CancelAllTickets(pnr));
        }

        [HttpGet("GetTicketDetailsOnPNR/{pnr}")]
        public ActionResult GetTicketDetailsOnPNR(string pnr)
        {
            return Ok(flightBookingService.GetTicketDetailsOnPNR(pnr));
        }
        [HttpGet("GetBookingHistoryOfUser/{email}")]
        public ActionResult GetBookingHistoryOfUser(string email)
        {
            return Ok(flightBookingService.GetBookingHistoryOfUser(email));
        }

    }
}
