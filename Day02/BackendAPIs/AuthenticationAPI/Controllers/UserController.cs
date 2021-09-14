using Microsoft.AspNetCore.Mvc;
using System;
using AuthenticationAPI.AOP;
using AuthenticationAPI.Exceptions;
using AuthenticationAPI.Models;
using AuthenticationAPI.Service;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionHandler]
    public class UserController : ControllerBase
    {
        readonly IUserService userService;
        readonly ITokenGenerator tokenGenerator;
        public UserController(IUserService _userService, ITokenGenerator _tokenGenerator)
        {
            userService = _userService;
            tokenGenerator = _tokenGenerator;
        }

        #region Register and Login Actions
        [HttpPost]
        [Route("register")]
        public ActionResult RegisterUser([FromBody] User user)
        {
            #region RegisterOldCode
            //try
            //{
            //    var userRegistred = userService.RegisterUser(user);
            //    return Ok(userRegistred);
            //}
            //catch (UserAlreadyExistException uaex)
            //{
            //    //return StatusCode(409, uaex.Message);
            //    return Conflict(uaex.Message);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
            #endregion
            var userRegistred = userService.RegisterUser(user);
            return Ok(userRegistred);
        }
        //Login
        [HttpPost]
        [Route("login")]
        public ActionResult Login(string userName, string password)
        {
            #region Login OldCode
            //try
            //{
            //    var userExist = userService.Login(userName, password);
            //    return Ok(userExist.Name);
            //}
            //catch (UserNameandPassWordNullException upne)
            //{
            //    return NotFound(upne.Message);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
            #endregion
            var userExist = userService.Login(userName, password);
            var tokenResult=tokenGenerator.GenerateToken(userExist.Id, userExist.Name);
            return Ok(tokenResult);
        }

        #endregion
        #region OtherActions
        //GetAllUsers
        [HttpGet]
        [Route("getAllUsers")]
        public ActionResult GetAllUsers()
        {
            return Ok(userService.GetAllUsers());
        }

        //getUserById

        [HttpGet]
        [Route("getUserById")]
        public ActionResult GetUserDetailsById(int userId)
        {
            var userDetails = userService.GetUserById(userId);
            return Ok(userDetails);
        }

        //getUserByname

        [HttpGet]
        [Route("getuserByName")]
        public ActionResult GetUserDetailsByName(string userName)
        {
            var userByName = userService.GetUserByName(userName);
            return Ok(userByName);
        }

        #endregion
    }
}
