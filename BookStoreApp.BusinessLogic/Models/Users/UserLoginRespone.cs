namespace BookStoreApp.BusinessLogic.Models.Users
{
    public class UserLoginRespone
    {
        public ApplicationUserDetailsDto UserDetails { get;set; } = new ApplicationUserDetailsDto();
        public string Token { get; set; } = string.Empty;
    }
}
