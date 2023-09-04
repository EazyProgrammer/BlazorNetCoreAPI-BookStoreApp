using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookStoreDBContext _context;

        public GenericRepository(BookStoreDBContext context)
        {
            _context = context;
        }

        public async Task<int> GetRecordsCountAsyc() => await _context.Set<T>().CountAsync();

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}