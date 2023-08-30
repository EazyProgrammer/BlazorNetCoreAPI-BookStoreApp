using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService 
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;

        public AuthorService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        public async Task<Response<List<AuthorReadOnlyDto>>> GetAuthorListAsync()
        {
            Response<List<AuthorReadOnlyDto>>? response;

            try
            {
                await GetBearerTojken();
                var data = await _client.AuthorsAllAsync();
                response = new Response<List<AuthorReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<List<AuthorReadOnlyDto>>(ex);
            }

            return response;
        }

        public async Task<Response<int>> CreateAuthor(AuthorCreateDto author)
        {
            Response<int> response = new Response<int>() { Success = true };

            try
            {
                await GetBearerTojken();
                await _client.PostAuthorAsync(author);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }
    }
}
