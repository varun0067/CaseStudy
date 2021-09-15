using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightServiceAPI.Models
{
    public class Airline
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public bool IsActive { get; set; }
    }
}
