using AutoMapper;
using BookStoreApp.BusinessLogic.Authorization;
using BookStoreApp.BusinessLogic.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthorizationBusinessLogic _logic;

        public AuthController(ILogger<AuthController> logger, IAuthorizationBusinessLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ApplicationUserDetailsDto>> Register(ApplicationUserDto userDto)
        {
            try
            {
                if (userDto == null)
                {
                    _logger.LogError("User details are required and cannot be null", userDto);
                    return BadRequest("User details are required and cannot be null");
                }

                var user = await _logic.RegisterUser(userDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while trying to register user!");
                return Problem("Something went wrong while trying to register user!", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginRespone>> Login(UserLoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                {
                    _logger.LogError("User login details are required and cannot be null / empty!", loginDto);
                    return Unauthorized(loginDto);
                }

                var result = await _logic.LoginUser(loginDto);

                return Ok(new UserLoginRespone { UserDetails = result.Item1, Token = result.Item2 });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while trying to login user!");
                return Problem("Something went wrong while trying to login user!", statusCode: 500);
            }
        }
    }
}
