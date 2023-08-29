﻿using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.User
{
    public class ApplicationUserDetailsDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required]
        public string Role { get; set; } = "";
    }
}
