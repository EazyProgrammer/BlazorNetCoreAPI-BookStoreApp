using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using AutoMapper;
using BookStoreApp.API.Models.Book;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly ILogger<BooksController> _logger;
        private readonly IMapper _mapper;

        public BooksController(BookStoreDBContext context, ILogger<BooksController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
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
            var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);

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
        public async Task<IActionResult> PutBook([FromBody] BookUpdateDto book)
        {
            var bk = _mapper.Map<Book>(book);
            _context.Entry(bk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(bk.Id))
                {
                    _logger.LogWarning("Book not found!", bk.Id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError("Error occured trying to update Book!", book);
                    return StatusCode(500, book);
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostBook(BookCreateDto book)
        {
          if (_context.Books == null)
          {
              return Problem("Entity set 'BookStoreDBContext.Books'  is null.");
          }

            var bk = _mapper.Map<Book>(book);
            _context.Books.Add(bk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = bk.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
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
    }
}
