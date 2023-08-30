using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> GetAuthorListAsync();
        Task<Response<int>> CreateAuthor(AuthorCreateDto author);
    }
}