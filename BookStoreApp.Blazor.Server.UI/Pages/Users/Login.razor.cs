using BookStoreApp.Blazor.Server.UI.Services.Authentication;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace BookStoreApp.Blazor.Server.UI.Pages.Users
{
    public partial class Login
    {
        [Inject] IAuthenticationService authenticationService { get; set; }
        [Inject] NavigationManager navManager { get; set; }

        UserLoginDto LoginModel = new UserLoginDto();
        string message = string.Empty;

        public async Task HandleLogin()
        {
            try
            {
                var result = await authenticationService.AuthenticateAsync(LoginModel);

                if (result == null)
                {
                    message = "Username / password is invalid. Please try again.";
                    return;
                }

                if (result.Success == false)
                {
                    message = result.Message;
                    return;
                }

                navManager.NavigateTo("/");
            }
            catch (ApiException ex)
            {
                message = ex.Message;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}
