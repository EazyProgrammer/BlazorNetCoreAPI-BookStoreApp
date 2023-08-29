namespace BookStoreApp.API.Models.User
{
    public class UserLoginRespone
    {
        public ApplicationUserDetailsDto UserDetails { get;set; } = new ApplicationUserDetailsDto();
        public string Token { get; set; } = string.Empty;
    }
}
