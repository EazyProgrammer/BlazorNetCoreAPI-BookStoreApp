using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.User
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string PasswordHash { get; set; } = "";
    }
}
