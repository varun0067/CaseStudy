using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightBookingServiceAPI.Models
{
    public enum MealsCategory
    {
        VEG,
        NONVEG
    }
    public class PassengerDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BookingPNR")]
        public string PNR { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int SeatNumber { get; set; }
        public MealsCategory Meals { get; set; }

        [JsonIgnore]
        public Booking BookingPNR { get; set; }
    }
}
