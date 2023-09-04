using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<Response<UserLoginRespone>> AuthenticateAsync(UserLoginDto user);
        Task Logout();
    }
}
