using BookStoreApp.Blazor.Server.UI.Models;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        //get
        Task<Response<AuthorReadOnlyDtoVirtualizeResponse>> GetActiveAuthorListByParameterAsync(QueryParameters parameters);
        Task<Response<List<AuthorReadOnlyDto>>> GetActiveAuthorListAsync();
        Task<Response<AuthorBooksDto>> GetAuthorAsync(int id);
        Task<Response<AuthorUpdateDto>> GetAuthorForUpdateAsync(int id);

        //create
        Task<Response<int>> CreateAuthor(AuthorCreateDto author);

        //update
        Task<Response<int>> EditAuthor(AuthorUpdateDto author);

        //delete
        Task<Response<int>> DeleteAuthor(int authorId);
    }
}