using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Repository.AuthorRepo
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly BookStoreDBContext _context;

        public AuthorRepository(BookStoreDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .Where(a  => a.Id == id)
                .FirstOrDefaultAsync();

            return author ?? new Author();
        }
    }
}
