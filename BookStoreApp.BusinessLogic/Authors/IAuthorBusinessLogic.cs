using BookStoreApp.BusinessLogic.Models.Authors;

namespace BookStoreApp.BusinessLogic.Authors
{
    public interface IAuthorBusinessLogic
    {
        Task<IEnumerable<AuthorReadOnlyDto>> GetAllActiveAuthors();
        Task<IEnumerable<AuthorReadOnlyDto>> GetAllInActiveAuthors();
        Task<AuthorBooksDto> GetAuthorById(int id);

        Task UpdateAuthor(AuthorUpdateDto author);

        Task<AuthorReadOnlyDto> AddAuthor(AuthorCreateDto author);

        Task DeActivateAuthor(int id);
    }
}
