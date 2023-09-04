using BookStoreApp.BusinessLogic.Models.Books;

namespace BookStoreApp.BusinessLogic.Models.Authors
{
    public class AuthorBooksDto : AuthorDetailsDto
    {
        public List<BookReadOnlyDto> Books { get; set; } = new List<BookReadOnlyDto>();
    }
}
