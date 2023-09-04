
namespace BookStoreApp.Repository.BookRepo
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetBookAsync(int id);
    }
}
