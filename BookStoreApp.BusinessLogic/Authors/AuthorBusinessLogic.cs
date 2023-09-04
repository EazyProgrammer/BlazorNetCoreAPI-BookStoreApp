using AutoMapper;
using BookStoreApp.BusinessLogic.Authors;
using BookStoreApp.Repository;
using BookStoreApp.Repository.AuthorRepo;

namespace BookStoreApp.BusinessLogic.Models.Authors
{
    public class AuthorBusinessLogic : IAuthorBusinessLogic
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorBusinessLogic(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorReadOnlyDto>> GetAllActiveAuthors()
        {
            var authors = await _repository.GetAllAsync();

            //Business logic to return only active authors
            authors = authors.Where(a => a.IsDeleted == false).ToList();

            var authorsDto = _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors);

            return authorsDto;
        }

        public async Task<IEnumerable<AuthorReadOnlyDto>> GetAllInActiveAuthors()
        {
            var authors = await _repository.GetAllAsync();

            //Business logic to return only active authors
            authors = authors.Where(a => a.IsDeleted == true).ToList();

            var authorsDto = _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors);

            return authorsDto;
        }

        public async Task<AuthorBooksDto> GetAuthorById(int id)
        {
            var authors = await _repository.GetAuthorAsync(id);
            var authorsDto = _mapper.Map<AuthorBooksDto>(authors);
            return authorsDto;
        }

        public async Task UpdateAuthor(AuthorUpdateDto author)
        {
            var a = _mapper.Map<Author>(author);
            await _repository.UpdateAsync(a);
        }

        public async Task<AuthorReadOnlyDto> AddAuthor(AuthorCreateDto author)
        {
            var a = _mapper.Map<Author>(author);
            var result = await _repository.AddAsync(a);
            var b = _mapper.Map<AuthorReadOnlyDto>(result);
            return b;
        }

        public async Task DeActivateAuthor(int id)
        {
            var a = _repository.GetAsync(id);

            if (a == null)
            {
                throw new Exception("Author could not be found in the system");
            }

            var author = _mapper.Map<Author>(a);
            await _repository.DeleteAsync(author);
        }
    }
}