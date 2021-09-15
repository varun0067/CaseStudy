using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightServiceAPI.Models
{
    public enum FlightScheduleDays
    {
        Daily=0,
        WeekDays=1,
        WeekEnds=2
    }
    public class Flight
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FlightNumber { get; set; }
        [ForeignKey("Airline")]
        public int AirlineId { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public FlightScheduleDays ScheduleDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int NumberOfBusinessClassSeats { get; set; }
        public int NumberOfEconomyClassSeats { get; set; }
        public double TicketCost { get; set; }

        [JsonIgnore]
        public Airline Airline { get; set; }

    }
}
