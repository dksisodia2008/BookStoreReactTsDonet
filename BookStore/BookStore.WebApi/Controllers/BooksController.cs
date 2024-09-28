using Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Book;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookRequest request)
        {
            var newBook = new BookDto()
            {
                Title = request.Title,
                Author = request.Author,
                Language = request.Language
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return Ok("Book saved successfully!!");
        }
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<BookDto>> GetBookById([FromRoute] Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (book is null)
            {
                return NotFound("Book not found with this id: " + id);
            }

            return Ok(book);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<BookDto>> UpdateBook([FromRoute] Guid id, [FromBody] BookRequest request)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (book is null)
            {
                return NotFound("Book not found with this id: " + id);
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.Language = request.Language;

            await _context.SaveChangesAsync();

            return Ok("Book Updated Successfully.");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        //[Route("id")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid? id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id.ToString() == id.ToString());
            if (book is null)
            {
                return NotFound("Book not found with this id: " + id);
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok("Book Deleted Successfully.");
        }
    }
}
