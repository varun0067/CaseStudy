using AuthenticationServiceAPI.Context;
using AuthenticationServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Test
{
    public class UserDBFixture
    {
        public readonly UserDBContext userDBContext;

        public UserDBFixture()
        {
            userDBContext = new UserDBContext(new DbContextOptionsBuilder<UserDBContext>().UseInMemoryDatabase("UserTestDb").Options);
            userDBContext.Users.Add(new User() { Email = "admin@gmail.com", Name = "Admin", Password = "admin", Admin = true });
            userDBContext.Users.Add(new User() { Email = "test@gmail.com", Name = "test", Password = "test", Age = 20, Gender = "male", Mobile = 8765432122, Admin = false });
            userDBContext.SaveChanges();
        }
    }
}
