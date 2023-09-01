using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;

        public BookService(IClient client, ILocalStorageService localStorageService,
            IMapper mapper) : base(client, localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
            _mapper = mapper;
        }

        public async Task<Response<List<BookReadOnlyDto>>> GetActiveBookListAsync()
        {
            Response<List<BookReadOnlyDto>>? response;

            try
            {
                await GetBearerTojken();
                var data = await _client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<List<BookReadOnlyDto>>(ex);
            }

            return response;
        }

        public async Task<Response<BookReadOnlyDto>> GetBookAsync(int id)
        {
            Response<BookReadOnlyDto> response;

            try
            {
                await GetBearerTojken();
                var data = await _client.BooksGETAsync(id);
                response = new Response<BookReadOnlyDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<BookReadOnlyDto>(ex);
            }

            return response;
        }

        public async Task<Response<BookUpdateDto>> GetBookForUpdateAsync(int id)
        {
            Response<BookUpdateDto> response;

            try
            {
                await GetBearerTojken();
                var data = await _client.BooksGETAsync(id);
                var updateBook = _mapper.Map<BookUpdateDto>(data);
                response = new Response<BookUpdateDto>
                {
                    Data = updateBook,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<BookUpdateDto>(ex);
            }

            return response;
        }

        public async Task<Response<int>> CreateBook(BookCreateDto Book)
        {
            Response<int> response = new Response<int>() { Success = true };

            try
            {
                await GetBearerTojken();
                await _client.BooksPOSTAsync(Book);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }

        public async Task<Response<int>> EditBook(BookUpdateDto Book)
        {
            Response<int> response = new Response<int>() { Success = true };

            try
            {
                await GetBearerTojken();
                await _client.BooksPUTAsync(Book);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }

        public async Task<Response<int>> DeleteBook(int BookId)
        {
            Response<int> response = new Response<int>() { Success = true };

            try
            {
                await GetBearerTojken();
                await _client.BooksDELETEAsync(BookId);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }
    }
}
