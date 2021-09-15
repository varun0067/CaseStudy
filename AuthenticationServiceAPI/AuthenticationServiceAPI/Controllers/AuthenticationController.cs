using AuthenticationServiceAPI.AOP;
using AuthenticationServiceAPI.DTO;
using AuthenticationServiceAPI.Models;
using AuthenticationServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionHandler]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ITokenService tokenService;

        public AuthenticationController(IAuthenticationService _authenticationService, ITokenService _tokenService)
        {
            authenticationService = _authenticationService;
            tokenService = _tokenService;
        }
        [HttpPost("register")]
        public ActionResult Register([FromBody] User user)
        {
            return Ok(authenticationService.Register(user));
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = authenticationService.Login(userLoginDTO);
            return Ok(tokenService.GenerateToken(user.Email, user.Password));

        }

    }
}
