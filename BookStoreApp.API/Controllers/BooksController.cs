using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using AutoMapper;
using BookStoreApp.API.Models.Book;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly ILogger<BooksController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BooksController(BookStoreDBContext context, ILogger<BooksController> logger, IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadOnlyDto>>> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .ToListAsync();

            var booksDto = _mapper.Map<IEnumerable<BookReadOnlyDto>>(books);

            return Ok(booksDto);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookReadOnlyDto>> GetBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                _logger.LogWarning("Book not found!", id);
                return NotFound();
            }

            var bookDto = _mapper.Map<BookReadOnlyDto>(book);
            return bookDto;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutBook([FromBody] BookUpdateDto book)
        {
            if (book.Id == 0)
            {
                return BadRequest();
            }

            try
            {
                var dbBook = _context.Books.Find(book.Id);

                if (dbBook == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(book.ImageData))
                {
                    var imageName = Path.GetFileName(dbBook.Image);
                    var path = $"{_webHostEnvironment.WebRootPath}\\BookCoverImages\\{imageName}";

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    book.Image = CreateFile(book.ImageData, book.OriginalImageName);
                }

                var bk = _mapper.Map(book, dbBook);

                _context.Entry(bk).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.Id))
                {
                    _logger.LogWarning("Book not found!", book.Id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError("Error occured trying to update Book!", book);
                    return StatusCode(500, book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured trying to update Book!", ex);
                return StatusCode(500, book);
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> PostBook(BookCreateDto book)
        {
            try
            {
                if (_context.Books == null)
                {
                    return Problem("Entity set 'BookStoreDBContext.Books'  is null.");
                }

                book.Image = CreateFile(book.ImageData, book.OriginalImageName);

                var bk = _mapper.Map<Book>(book);
                _context.Books.Add(bk);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBook", new { id = bk.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred trying to create Book!", ex);
                return StatusCode(500, book);
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string CreateFile(string imageBase64, string imageName)
        {
            var url = HttpContext.Request.Host.Value;
            var ext = Path.GetExtension(imageName);
            var fileName = $"{Guid.NewGuid()}{ext}";

            var path = $"{_webHostEnvironment.WebRootPath}\\BookCoverImages";
            var filePath = $"{path}\\{fileName}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            byte[] image = Convert.FromBase64String(imageBase64);

            var fileStream = System.IO.File.Create(filePath);
            fileStream.Write(image, 0, image.Length);
            fileStream.Close();

            return $"https://{url}/BookCoverImages/{fileName}";
        }

    }
}
