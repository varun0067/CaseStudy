using AuthenticationServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServiceAPI.Context
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
