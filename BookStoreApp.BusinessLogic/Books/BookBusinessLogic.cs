using AutoMapper;
using BookStoreApp.BusinessLogic.Helpers;
using BookStoreApp.Repository;
using BookStoreApp.Repository.BookRepo;

namespace BookStoreApp.BusinessLogic.Models.Books
{
    public class BookBusinessLogic : IBookBusinessLogic
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;

        public BookBusinessLogic(IBookRepository repository, IMapper mapper, IFileHelper fileHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _fileHelper = fileHelper;
        }

        public async Task<IEnumerable<BookReadOnlyDto>> GetAllActiveBooks()
        {
            var Books = await _repository.GetAllAsync();

            //Business logic to return only active Books
            Books = Books.Where(a => a.IsDeleted == false).ToList();

            var BooksDto = _mapper.Map<IEnumerable<BookReadOnlyDto>>(Books);

            return BooksDto;
        }

        public async Task<IEnumerable<BookReadOnlyDto>> GetAllInActiveBooks()
        {
            var Books = await _repository.GetAllAsync();

            //Business logic to return only active Books
            Books = Books.Where(a => a.IsDeleted == true).ToList();

            var BooksDto = _mapper.Map<IEnumerable<BookReadOnlyDto>>(Books);

            return BooksDto;
        }

        public async Task<BookDetailsDto> GetBookById(int id)
        {
            var Books = await _repository.GetBookAsync(id);
            var BooksDto = _mapper.Map<BookReadOnlyDto>(Books);
            return BooksDto;
        }

        public async Task UpdateBook(BookUpdateDto book, string rootPath, string url)
        {
            var dbBook = await _repository.GetBookAsync(book.Id);

            if (dbBook == null)
                throw new Exception($"Book cannot be found with Id: {book.Id}");

            HandleBookCover(book, dbBook.Image ?? "", rootPath, url);

            var bk = _mapper.Map(book, dbBook);

            await _repository.UpdateAsync(bk);
        }

        public async Task<BookReadOnlyDto> AddBook(BookCreateDto book, string rootPath, string url)
        {
            book.Image = _fileHelper.CreateFile(rootPath, book.ImageData, book.OriginalImageName, url);

            var bk = _mapper.Map<Book>(book);
            var result = await _repository.AddAsync(bk);
            var b = _mapper.Map<BookReadOnlyDto>(result);

            return b;
        }

        public async Task DeActivateBook(int id)
        {
            var a = _repository.GetAsync(id);

            if (a == null)
            {
                throw new Exception("Book could not be found in the system");
            }

            var Book = _mapper.Map<Book>(a);
            Book.IsDeleted = true;
            await _repository.DeleteAsync(Book);
        }

        private void HandleBookCover(BookUpdateDto book, string existingImage, string rootPath, string url)
        {
            if (!string.IsNullOrEmpty(book.ImageData))
            {
                var imageName = Path.GetFileName(existingImage);
                var path = $"{rootPath}\\BookCoverImages\\{imageName}";

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                book.Image = _fileHelper.CreateFile(rootPath, book.ImageData, book.OriginalImageName, url);
            }
        }
    }
}
