using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly ILogger<BooksController> _logger;
        private readonly IMapper _mapper;

        public AuthorsController(BookStoreDBContext context, ILogger<BooksController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        [Route("GetAllActiveAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAllActiveAuthors()
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors
                .Where(a => a.IsDeleted == false).ToListAsync();
            var authorDto = _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(author);
            return Ok(authorDto);
        }

        // GET: api/Authors
        [HttpGet]
        [Route("GetAllInActiveAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAllInActiveAuthors()
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors
                .Where(a => a.IsDeleted == true).ToListAsync();
            var authorDto = _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(author);
            return Ok(authorDto);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBooksDto>> GetAuthor(int id)
        {
            try
            {
                if (_context.Authors == null)
                {
                    return NotFound();
                }

                var author = await _context.Authors
                    .Include(b => b.Books)
                    .Where(a => a.Id == id)
                    .FirstOrDefaultAsync();

                if (author == null)
                {
                    return NotFound();
                }

                var authorDto = _mapper.Map<AuthorBooksDto>(author);

                return authorDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong trying to get author details");
                return NotFound();
            }
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAuthor(AuthorUpdateDto author)
        {
            var auth = _mapper.Map<Author>(author);
            _context.Entry(auth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(auth.Id))
                {
                    _logger.LogError("Author not found!", auth.Id);
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PostAuthor")]
        public async Task<ActionResult> PostAuthor(AuthorCreateDto author)
        {
            if (_context.Authors == null)
            {
                _logger.LogWarning("Entity set 'BookStoreDBContext.Authors'  is null.!");
                return Problem("Entity set 'BookStoreDBContext.Authors'  is null.");
            }

            var auth = _mapper.Map<Author>(author);
            _context.Authors.Add(auth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = auth.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                _logger.LogError("Author not found!", id);
                return NotFound();
            }

            author.IsDeleted = true;

            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
