using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<Response<UserLoginRespone>> AuthenticateAsync(UserLoginDto user);
        Task Logout();
    }
}
