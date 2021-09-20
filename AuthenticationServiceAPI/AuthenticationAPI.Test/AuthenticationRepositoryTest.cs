using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Models;
using AuthenticationServiceAPI.Repository;
using Xunit;

namespace AuthenticationAPI.Test
{
    public class AuthenticationRepositoryTest : IClassFixture<UserDBFixture>
    {
        private readonly AuthenticationRepository authenticationRepository;

        public AuthenticationRepositoryTest(UserDBFixture _userDBFixture)
        {
            authenticationRepository = new AuthenticationRepository(_userDBFixture.userDBContext);
        }

        [Fact]
        public void TestTo_CheckUserAlreadyExists_WithExistingUser()
        {
            string expectedUserName = "test";

            var user = authenticationRepository.CheckUserAlreadyExists("test@gmail.com");
            var actualUserName = user.Name;

            Assert.Equal(expectedUserName, actualUserName);
        }

        [Fact]
        public void TestTo_CheckUserAlreadyExists_WithNonExistingUser()
        {

            var user = authenticationRepository.CheckUserAlreadyExists("test1@gmail.com");

            Assert.Null(user);
        }

        [Fact]
        public void CheckLogin_WithValidCredentials()
        {
            string expectedUserName = "test";
            var loginDTO = new UserLoginDTO() { Email = "test@gmail.com", Password = "test" };
            var user = authenticationRepository.Login(loginDTO);
            var actualUserName = user.Name;

            Assert.Equal(expectedUserName, actualUserName);
        }

        [Fact]
        public void CheckLogin_WithInValidCredentials()
        {

            var loginDTO = new UserLoginDTO() { Email = "test@gmail.com", Password = "test1" };
            var user = authenticationRepository.Login(loginDTO);

            Assert.Null(user);
        }

        [Fact]
        public void CheckRegister_WithValidUserDetails()
        {
            var expetedUserName = "test1";
            var user = new User() { Email = "test1@gmail.com", Name = "test1", Password = "test1", Age = 20, Gender = "male", Mobile = 8785232122, Admin = false };

            authenticationRepository.Register(user);

            var actualUserName = authenticationRepository.CheckUserAlreadyExists("test1@gmail.com").Name;

            Assert.Equal(expetedUserName, actualUserName);
        }

    }
}
