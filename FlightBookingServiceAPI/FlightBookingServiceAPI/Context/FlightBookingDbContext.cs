using FlightBookingServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingServiceAPI.Context
{
    public class FlightBookingDbContext:DbContext
    {
        public FlightBookingDbContext(DbContextOptions<FlightBookingDbContext> options):base(options)
        {
                
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PassengerDetail> PassengerDetails { get; set; }
    }
}
