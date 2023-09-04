using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Repository.BookRepo
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly BookStoreDBContext _context;

        public BookRepository(BookStoreDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var book = await _context.Books
                .Include(x => x.Author)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return book ?? new Book();
        }
    }
}
