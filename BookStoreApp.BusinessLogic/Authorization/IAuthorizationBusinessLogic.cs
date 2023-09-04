using BookStoreApp.BusinessLogic.Models.Users;

namespace BookStoreApp.BusinessLogic.Authorization
{
    public interface IAuthorizationBusinessLogic
    {
        Task<ApplicationUserDetailsDto> RegisterUser(ApplicationUserDto userDto);
        Task<Tuple<ApplicationUserDetailsDto, string>> LoginUser(UserLoginDto loginDto);
    }
}
