using FlightServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightServiceAPI.Context
{
    public class FlightDbContext:DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options):base(options)
        {

        }

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
