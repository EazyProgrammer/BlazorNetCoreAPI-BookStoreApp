using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Helpers;
using BookStoreApp.API.Models.User;
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
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private JwtTokenHelper _jwtTokenHelper;

        public AuthController(ILogger<AuthController> logger, IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _jwtTokenHelper = new JwtTokenHelper(configuration);
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
                    _logger.LogError("User detials are required and cannot be null", userDto);
                    return BadRequest("User detials are required and cannot be null");
                }

                var user = _mapper.Map<ApplicationUser>(userDto);
                user.UserName = userDto.Email.ToLower();
                user.NormalizedUserName = userDto.Email.ToUpper();

                var result = await _userManager.CreateAsync(user, user.PasswordHash);

                if (result.Succeeded == false)
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(err.Code, err.Description);
                    }

                    _logger.LogError("Error occured trying to add user to database", ModelState);
                    return BadRequest(ModelState);
                }

                if (!string.IsNullOrEmpty(userDto.Role))
                {
                    result = await _userManager.AddToRoleAsync(user, userDto.Role);
                }

                if (result.Succeeded == false)
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(err.Code, err.Description);
                    }

                    _logger.LogError("Error occured trying to assign user to role", ModelState);
                    return BadRequest(ModelState);
                }

                var usr = _mapper.Map<ApplicationUserDetailsDto>(user);

                var role = await _userManager.GetRolesAsync(user);
                usr.Role = role.FirstOrDefault() ?? "INVALID";

                return Ok(usr);
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
                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                if (user == null)
                {
                    _logger.LogError("User cannot be found in the database!", loginDto);
                    return Unauthorized(loginDto);
                }

                var passValid = await _userManager.CheckPasswordAsync(user, loginDto.PasswordHash);

                if (passValid == false)
                {
                    _logger.LogError("User cannot be found in the database!", loginDto);
                    return Unauthorized(loginDto);
                }

                var usr = _mapper.Map<ApplicationUserDetailsDto>(user);
                var roles = await _userManager.GetRolesAsync(user);
                usr.Role = roles.FirstOrDefault() ?? "INVALID";

                var userClaims = await _userManager.GetClaimsAsync(user);

                var token = _jwtTokenHelper.GenerateWebToken(user, roles, userClaims);

                return Ok(new UserLoginRespone { UserDetails = usr, Token = token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while trying to login user!");
                return Problem("Something went wrong while trying to login user!", statusCode: 500);
            }
        }
    }
}
