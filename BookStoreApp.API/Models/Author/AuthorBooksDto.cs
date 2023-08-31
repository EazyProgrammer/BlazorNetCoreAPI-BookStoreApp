using BookStoreApp.API.Models.Book;

namespace BookStoreApp.API.Models.Author
{
    public class AuthorBooksDto : AuthorDetailsDto
    {
        public List<BookReadOnlyDto> Books { get; set; } = new List<BookReadOnlyDto>();
    }
}
