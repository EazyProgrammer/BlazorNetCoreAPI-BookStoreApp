using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> GetAuthorListAsync();
        Task<Response<AuthorReadOnlyDto>> GetAuthorAsync(int id);
        Task<Response<AuthorUpdateDto>> GetAuthorForUpdateAsync(int id);
        Task<Response<int>> CreateAuthor(AuthorCreateDto author);
        Task<Response<int>> EditAuthor(AuthorUpdateDto author);
    }
}