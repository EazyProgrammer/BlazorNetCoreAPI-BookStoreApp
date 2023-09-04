using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.BusinessLogic.Models.Users
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
