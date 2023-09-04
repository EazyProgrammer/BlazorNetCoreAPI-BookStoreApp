using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BookStoreApp.BusinessLogic.Models.Authors;
using BookStoreApp.BusinessLogic.Authors;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorBusinessLogic _logic;
        private readonly ILogger<BooksController> _logger;

        public AuthorsController(IAuthorBusinessLogic logic, ILogger<BooksController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        [Route("GetAllActiveAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAllActiveAuthors()
        {
            var authors = await _logic.GetAllActiveAuthors();

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        // GET: api/Authors
        [HttpGet]
        [Route("GetAllInActiveAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAllInActiveAuthors()
        {
            var authors = await _logic.GetAllInActiveAuthors();

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBooksDto>> GetAuthor(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var author = await _logic.GetAuthorById(id);

                if (author == null)
                {
                    return NotFound();
                }

                return author;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong trying to get author details");
                return NotFound();
            }
        }

        // PUT: api/Authors/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutAuthor(AuthorUpdateDto author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest();
                }

                await _logic.UpdateAuthor(author);
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Something went wrong trying to update Author, please try again!");
                return NotFound();
            }
        }

        // POST: api/Authors
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PostAuthor")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> PostAuthor(AuthorCreateDto author)
        {
            try
            {
                if (author == null)
                {
                    _logger.LogWarning("Author details are required and cannot be null / empty!");
                    return Problem("Author details are required and cannot be null / empty!");
                }

                var a = await _logic.AddAuthor(author);

                return Ok(author);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Something went wrong trying to update Author, please try again!");
                return NotFound();
            }
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _logic.DeActivateAuthor(id);

            return NoContent();
        }
    }
}
