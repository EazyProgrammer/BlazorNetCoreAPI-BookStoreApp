using Blazored.LocalStorage;
using BookStoreApp.Blazor.WebAssembly.UI.Providers;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
             : base(httpClient, localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Response<UserLoginRespone>> AuthenticateAsync(UserLoginDto user)
        {
            var result = new Response<UserLoginRespone>();

            try
            {
                var response = await _httpClient.LoginAsync(user);

                //store token
                await _localStorage.SetItemAsync("accessToken", response.Token);

                //change auth state of app
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                result = new Response<UserLoginRespone>()
                {
                    Data = response,
                    Success = true
                };

                return result;
            }
            catch (ApiException ex)
            {
                result = ConvertApiExceptions<UserLoginRespone>(ex);
            }

            return result;
        }

        public async Task Logout()
        {
            //change auth state of app
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }
    }
}
