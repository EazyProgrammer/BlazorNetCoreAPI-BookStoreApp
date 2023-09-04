using BookStoreApp.BusinessLogic.Models;
using BookStoreApp.BusinessLogic.Models.Authors;

namespace BookStoreApp.BusinessLogic.Authors
{
    public interface IAuthorBusinessLogic
    {
        Task<VirtualizeResponse<TResult>> GetAllActiveAuthorsByParameter<TResult>(QueryParameters queryParameters) where TResult : class;
        Task<List<AuthorReadOnlyDto>> GetAllActiveAuthors();
        Task<IEnumerable<AuthorReadOnlyDto>> GetAllInActiveAuthors();
        Task<AuthorBooksDto> GetAuthorById(int id);

        Task UpdateAuthor(AuthorUpdateDto author);

        Task<AuthorReadOnlyDto> AddAuthor(AuthorCreateDto author);

        Task DeActivateAuthor(int id);
    }
}
