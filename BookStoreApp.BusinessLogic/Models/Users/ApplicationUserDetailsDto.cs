﻿using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.BusinessLogic.Models.Users
{
    public class ApplicationUserDetailsDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
