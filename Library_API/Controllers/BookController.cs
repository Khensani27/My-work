using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library_API.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Library_API.Data;

namespace Library_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Book/getBooks
        [HttpGet("getBooks")]
        public async Task<ActionResult<List<Books>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        // GET: api/Book/getBook/{id}
        [HttpGet("getBook/{id}")]
        public async Task<ActionResult<Books>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound("Book not found");

            return Ok(book);
        }

        // POST: api/Book/addBook
        [HttpPost("addBook")]
        public async Task<ActionResult> AddBook(Books book)
        {
            if (book != null)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return Ok(book);  // Return the added book
            }
            return BadRequest("Invalid book data");
        }

        // PUT: api/Book/updateBook/{id}
        [HttpPut("updateBook/{id}")]
        public async Task<ActionResult> UpdateBook(int id, Books updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound("Book not found");

            book.Author = updatedBook.Author;
            book.Title = updatedBook.Title;
            book.Edition = updatedBook.Edition;
            book.Publisher = updatedBook.Publisher;
            book.Publication_Date = updatedBook.Publication_Date;
            book.Genre = updatedBook.Genre;
            book.ISBN = updatedBook.ISBN;
            book.Description = updatedBook.Description;
            book.Book_Status = updatedBook.Book_Status;

            await _context.SaveChangesAsync();

            return Ok(book);  // Return the updated book
        }

        // DELETE: api/Book/removeBook/{id}
        [HttpDelete("removeBook/{id}")]
        public async Task<ActionResult<Books>> RemoveBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound("Book not found");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);  // Return the deleted book
        }

        // GET: api/Book/search
        [HttpGet("search")]
        public async Task<ActionResult<List<Books>>> SearchBooks(string? title, string? author, string? genre, string? isbn)
        {
            var query = _context.Books.AsQueryable();

            // Filter by Title
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by Author
            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by Genre
            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by ISBN
            if (!string.IsNullOrEmpty(isbn))
            {
                query = query.Where(b => b.ISBN.Contains(isbn));
            }

            var books = await query.ToListAsync();

            if (!books.Any())
            {
                return NotFound("No books found matching the search criteria");
            }

            return Ok(books);
        }
    }
}
