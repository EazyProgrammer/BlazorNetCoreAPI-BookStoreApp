namespace BookStoreApp.Repository.AuthorRepo
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> GetAuthorAsync(int id);
    }
}
