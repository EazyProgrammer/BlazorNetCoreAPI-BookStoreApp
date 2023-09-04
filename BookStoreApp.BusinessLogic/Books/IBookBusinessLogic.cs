
namespace BookStoreApp.BusinessLogic.Models.Books
{
    public interface IBookBusinessLogic
    {
        Task<IEnumerable<BookReadOnlyDto>> GetAllActiveBooks();
        Task<IEnumerable<BookReadOnlyDto>> GetAllInActiveBooks();
        Task<BookReadOnlyDto> GetBookById(int id);

        Task UpdateBook(BookUpdateDto book, string rootPath, string url);

        Task<BookReadOnlyDto> AddBook(BookCreateDto book, string rootPath, string url);

        Task DeActivateBook(int id);
    }
}
