using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.BusinessLogic.Models.Authors
{
    public abstract class AuthorDetailsDto : AuthorBaseDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(250)]
        public string Bio { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
