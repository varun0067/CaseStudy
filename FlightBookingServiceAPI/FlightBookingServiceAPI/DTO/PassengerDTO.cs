using FlightBookingServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingServiceAPI.DTO
{
    public class PassengerDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int SeatNumber { get; set; }
        public MealsCategory Meals { get; set; }
    }
}
