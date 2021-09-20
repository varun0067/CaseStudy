using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Exceptions;
using AuthenticationServiceAPI.Models;
using AuthenticationServiceAPI.Repository;
using AuthenticationServiceAPI.Services;
using Moq;
using Xunit;

namespace AuthenticationAPI.Test
{
    public class AuthenticationServiceTest
    {
        private readonly Mock<IAuthenticationRepository> authenticationRepositoryMock;
        private readonly AuthenticationService authenticationService;

        public AuthenticationServiceTest()
        {
            authenticationRepositoryMock = new Mock<IAuthenticationRepository>();
            authenticationService = new AuthenticationService(authenticationRepositoryMock.Object);
        }

        [Fact]
        public void ToCheck_Login_WithValidCredentials()
        {
            var loginDTO = new UserLoginDTO() { Email = "test@gmail.com", Password = "test" };
            var user = new User() { Email = "test@gmail.com", Name = "test", Password = "test", Age = 20, Gender = "male", Mobile = 8785232122, Admin = false };

            authenticationRepositoryMock.Setup(r => r.Login(loginDTO)).Returns(user);

            var expectedUser = authenticationService.Login(loginDTO);

            Assert.Equal(expectedUser, user);
        }

        [Fact]
        public void ToCheck_Login_WithInValidCredentials()
        {
            var loginDTO = new UserLoginDTO() { Email = "test1@gmail.com", Password = "test" };

            User user = null;
            authenticationRepositoryMock.Setup(r => r.Login(loginDTO)).Returns(user);


            Assert.ThrowsAny<InvalidCredentialsException>(() => authenticationService.Login(loginDTO));
        }

        [Fact]
        public void ToCheck_RegisterWith_AlreadyExistingUser()
        {
            var user = new User() { Email = "test@gmail.com", Name = "test", Password = "test", Age = 20, Gender = "male", Mobile = 8785232122, Admin = false };

            authenticationRepositoryMock.Setup(r => r.CheckUserAlreadyExists(user.Email)).Returns(user);

            Assert.ThrowsAny<UserAlreadyExistException>(() => authenticationService.Register(user));
        }

        [Fact]
        public void ToCheck_RegisterWith_NonExistingUser()
        {
            var expextedResult = "User Registered Successfully";
            var user = new User() { Email = "test1@gmail.com", Name = "test1", Password = "test1", Age = 20, Gender = "male", Mobile = 8785232122, Admin = false };

            User user1 = null;
            authenticationRepositoryMock.Setup(r => r.CheckUserAlreadyExists(user.Email)).Returns(user1);
            authenticationRepositoryMock.Setup(r => r.Register(user)).Returns("User Registered Successfully");

            var actualResult = authenticationService.Register(user);
            Assert.Equal(expextedResult, actualResult);
        }
    }
}
