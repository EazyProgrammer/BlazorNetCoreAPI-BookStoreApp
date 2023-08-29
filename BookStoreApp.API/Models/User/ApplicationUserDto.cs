using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.User
{
    public class ApplicationUserDto : UserLoginDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
