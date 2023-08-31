using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.Book
{
    public class BookCreateDto
    {
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [Required]
        [Range(1900, int.MaxValue)]
        public int? Year { get; set; }

        [Required]
        public string Isbn { get; set; } = string.Empty;

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string? Summary { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal? Price { get; set; }

        public string Image { get; set; } = string.Empty;
        public string ImageData { get; set; } = string.Empty;
        public string OriginalImageName { get; set; } = string.Empty;

        [Required]
        public int? AuthorId { get; set; }
    }
}
