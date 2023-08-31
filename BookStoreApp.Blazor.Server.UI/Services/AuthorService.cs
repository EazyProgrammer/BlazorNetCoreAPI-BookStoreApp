using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService 
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;

        public AuthorService(IClient client, ILocalStorageService localStorageService,
            IMapper mapper) : base(client, localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
            _mapper = mapper;
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

        public async Task<Response<AuthorReadOnlyDto>> GetAuthorAsync(int id)
        {
            Response<AuthorReadOnlyDto> response;

            try
            {
                await GetBearerTojken();
                var data = await _client.AuthorsGETAsync(id);
                response = new Response<AuthorReadOnlyDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<AuthorReadOnlyDto>(ex);
            }

            return response;
        }

        public async Task<Response<AuthorUpdateDto>> GetAuthorForUpdateAsync(int id)
        {
            Response<AuthorUpdateDto> response;

            try
            {
                await GetBearerTojken();
                var data = await _client.AuthorsGETAsync(id);
                var updateAuthor = _mapper.Map<AuthorUpdateDto>(data);
                response = new Response<AuthorUpdateDto>
                {
                    Data = updateAuthor,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<AuthorUpdateDto>(ex);
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

        public async Task<Response<int>> EditAuthor(AuthorUpdateDto author)
        {
            Response<int> response = new Response<int>() { Success = true };

            try
            {
                await GetBearerTojken();
                await _client.AuthorsPUTAsync(author);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }
    }
}
