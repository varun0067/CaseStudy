using Microsoft.EntityFrameworkCore;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext>options):base(options)
        {
            Database.EnsureCreated();
        }

        //Table
        public DbSet<User> Users { get; set; }

    }
}
