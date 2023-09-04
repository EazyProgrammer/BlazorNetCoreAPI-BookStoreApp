using AutoMapper;
using BookStoreApp.BusinessLogic.Helpers;
using BookStoreApp.BusinessLogic.Models.Users;
using BookStoreApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookStoreApp.BusinessLogic.Authorization
{
    public class AuthorizationBusinessLogic : IAuthorizationBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private JwtTokenHelper _jwtTokenHelper;
        private readonly ILogger<AuthorizationBusinessLogic> _logger;

        public AuthorizationBusinessLogic(IMapper mapper, UserManager<ApplicationUser> userManager, ILogger<AuthorizationBusinessLogic> logger, IConfiguration configuration)
        {
            _mapper = mapper;
            _jwtTokenHelper = new JwtTokenHelper(configuration);
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<ApplicationUserDetailsDto> RegisterUser(ApplicationUserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            user.UserName = userDto.Email.ToLower();
            user.NormalizedUserName = userDto.Email.ToUpper();

            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            if (result.Succeeded == false)
            {
                _logger.LogError("Error occurred trying to add user to database", result.Errors);
                throw new Exception("Error occurred trying to add user to database");
            }

            if (!string.IsNullOrEmpty(userDto.Role))
            {
                result = await _userManager.AddToRoleAsync(user, userDto.Role);
            }

            if (result.Succeeded == false)
            {
                _logger.LogError("Error occurred trying to assign user to role", result.Errors);
                throw new Exception("Error occurred trying to assign user to role");
            }

            var usr = _mapper.Map<ApplicationUserDetailsDto>(user);

            var role = await _userManager.GetRolesAsync(user);
            usr.Role = role.FirstOrDefault() ?? "INVALID";
            return usr;
        }

        public async Task<Tuple<ApplicationUserDetailsDto, string>> LoginUser(UserLoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                _logger.LogError("User cannot be found in the database!", loginDto);
                throw new UnauthorizedAccessException("User cannot be found in the database!");
            }

            var passValid = await _userManager.CheckPasswordAsync(user, loginDto.PasswordHash);

            if (passValid == false)
            {
                _logger.LogError("User cannot be found in the database!", loginDto);
                throw new UnauthorizedAccessException("User cannot be found in the database!");
            }

            var usr = _mapper.Map<ApplicationUserDetailsDto>(user);
            var roles = await _userManager.GetRolesAsync(user);
            usr.Role = roles.FirstOrDefault() ?? "INVALID";

            var userClaims = await _userManager.GetClaimsAsync(user);

            var token = _jwtTokenHelper.GenerateWebToken(user, roles, userClaims);

            var result = Tuple.Create(usr, token);
            return result;
        }
    }
}
