using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightBookingServiceAPI.Models
{
    public class PassengerDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Booking")]
        public string PNR { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string SeatNumber { get; set; }
        public string Meals { get; set; }

        [JsonIgnore]
        public Booking Booking { get; set; }
    }
}
