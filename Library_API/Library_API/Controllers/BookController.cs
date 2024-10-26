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
            var books = await (from b in _context.Books select b).ToListAsync();
            return Ok(books);
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
            book.Actual_Stock = updatedBook.Actual_Stock;

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

        // 1. Check if the user has pending fines
        [HttpGet("hasPendingFine/{userId}")]
        public async Task<ActionResult<bool>> HasPendingFine(int userId)
        {
            var pendingFines = await _context.Borrowed_Books
                .Where(b => b.User_ID == userId && b.Book_Status == "Pending Fine")
                .ToListAsync();

            return Ok(pendingFines.Any());
        }

        // 2. Check if the book has available stock
        [HttpGet("getStock/{bookId}")]
        public async Task<ActionResult<int>> GetStock(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
                return NotFound("Book not found");

            return Ok(book.Actual_Stock); // Return the book's stock
        }

        // 3. Check if the user has already reserved a book
        [HttpGet("hasReservedBook/{userId}")]
        public async Task<ActionResult<bool>> HasReservedBook(int userId)
        {
            var reservedBook = await _context.Borrowed_Books
                .Where(b => b.User_ID == userId && b.Book_Status == "Reserved")
                .ToListAsync();

            return Ok(reservedBook.Any());
        }

        // 4. Reserve a book
        [HttpPost("reserveBook")]
        public async Task<ActionResult> ReserveBook([FromBody] Borrowed_Books reservation)
        {
            // Find the book in the database
            var book = await _context.Books.FindAsync(reservation.Book_ID);
            if (book == null)
                return NotFound("Book not found");

            if (book.Actual_Stock <= 0)
                return BadRequest("No stock available");

            // Check if the user has already reserved a book
            var hasReserved = await _context.Borrowed_Books
                .AnyAsync(b => b.User_ID == reservation.User_ID && b.Book_Status == "Reserved");

            if (hasReserved)
                return BadRequest("You have already reserved a book");

            // Create the reservation
            reservation.Borrowed_Date = DateTime.Now;
            reservation.Returned_Date = DateTime.Now.AddDays(3); // Set reservation for 3 days
            reservation.Fine = 0.00;
            reservation.Book_Status = "Reserved";

            _context.Borrowed_Books.Add(reservation);

            // Update book stock
            book.Actual_Stock -= 1;

            await _context.SaveChangesAsync();

            return Ok("Book successfully reserved");
        }
    }
}
