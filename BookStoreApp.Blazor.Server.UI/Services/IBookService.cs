using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IBookService
    {
        //get
        Task<Response<List<BookReadOnlyDto>>> GetActiveBookListAsync();
        Task<Response<BookReadOnlyDto>> GetBookAsync(int id);
        Task<Response<BookUpdateDto>> GetBookForUpdateAsync(int id);

        //create
        Task<Response<int>> CreateBook(BookCreateDto Book);

        //update
        Task<Response<int>> EditBook(BookUpdateDto Book);

        //delete
        Task<Response<int>> DeleteBook(int BookId);
    }
}