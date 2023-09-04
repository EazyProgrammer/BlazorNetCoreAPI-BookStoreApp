using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using BookStoreApp.BusinessLogic.Models.Books;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookBusinessLogic _logic;
        private readonly ILogger<BooksController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BooksController(IBookBusinessLogic logic, ILogger<BooksController> logger,
            IWebHostEnvironment webHostEnvironment)
        {
            _logic = logic;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadOnlyDto>>> GetBooks()
        {
            var books = await _logic.GetAllActiveBooks();
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDto>> GetBook(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var book = await _logic.GetBookById(id);

            if (book == null)
            {
                _logger.LogWarning("Book not found!", id);
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutBook([FromBody] BookUpdateDto book)
        {
            try
            {
                if (book == null)
                {
                    return NotFound();
                }

                var url = HttpContext.Request.Host.Value;
                var rootPath = _webHostEnvironment.WebRootPath;
                await _logic.UpdateBook(book, rootPath, url);

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred trying to update Book!", ex);
                return StatusCode(500, book);
            }
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> PostBook(BookCreateDto book)
        {
            try
            {
                if (book == null)
                {
                    return Problem("Book details are required and cannot be null / empty.");
                }

                var url = HttpContext.Request.Host.Value;
                var rootPath = _webHostEnvironment.WebRootPath;
                var bk = await _logic.AddBook(book, rootPath, url);

                return Ok(bk);
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
            if (id == 0)
            {
                return NotFound();
            }

            await _logic.DeActivateBook(id);

            return NoContent();
        }
    }
}
