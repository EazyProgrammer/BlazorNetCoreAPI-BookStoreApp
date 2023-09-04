using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Models;
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

        public async Task<Response<AuthorReadOnlyDtoVirtualizeResponse>> GetActiveAuthorListByParameterAsync(QueryParameters parameters)
        {
            Response<AuthorReadOnlyDtoVirtualizeResponse>? response;

            try
            {
                await GetBearerTojken();
                var data = await _client.GetAllActiveAuthorsByParameterAsync(parameters.StartIndex, parameters.PageSize);
                response = new Response<AuthorReadOnlyDtoVirtualizeResponse>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<AuthorReadOnlyDtoVirtualizeResponse>(ex);
            }

            return response;
        }

        public async Task<Response<List<AuthorReadOnlyDto>>> GetActiveAuthorListAsync()
        {
            Response<List<AuthorReadOnlyDto>>? response;

            try
            {
                await GetBearerTojken();
                var data = await _client.GetAllActiveAuthorsAsync();
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

        public async Task<Response<AuthorBooksDto>> GetAuthorAsync(int id)
        {
            Response<AuthorBooksDto> response;

            try
            {
                await GetBearerTojken();
                var data = await _client.AuthorsGETAsync(id);
                response = new Response<AuthorBooksDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<AuthorBooksDto>(ex);
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

        public async Task<Response<int>> DeleteAuthor(int authorId)
        {
            Response<int> response = new Response<int>() { Success = true };

            try
            {
                await GetBearerTojken();
                await _client.AuthorsDELETEAsync(authorId);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }
    }
}
