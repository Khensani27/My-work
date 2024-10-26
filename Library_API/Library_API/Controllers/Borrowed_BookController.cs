using Library_API.Data;
using Library_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Controllers
{
    public class Borrowed_BookController : Controller
    {
        private readonly DataContext _context;

        public Borrowed_BookController(DataContext context)
        {
            _context = context;
        }



        // GET: api/Book/getBorrowed.
        [HttpGet("api/Book/getAllBorrowedBooks")]
        public async Task<ActionResult<List<Borrowed_Books>>> BorrowedBooks()
        {
            return Ok(await _context.Borrowed_Books.ToListAsync());
        }






        // POST: api/BorrowedBooks/borrow
        [HttpPost("borrow")]
        public async Task<ActionResult> BorrowBook(int userId, int bookId)
        {
            // Check if the user and book exist in the database
            var user = await _context.Users.FindAsync(userId);
            var book = await _context.Books.FindAsync(bookId);


            if (user == null)
            {
                return NotFound("User not found");
            }

            if (book == null)
            {
                return NotFound("Book not found");
            }

            if (book.Actual_Stock > 0)
            {
                
                    // Create a new BorrowedBook object
                    var borrowedBook = new Borrowed_Books
                    {
                        User_ID = userId,
                        Book_ID = bookId,
                        Borrowed_Date = DateTime.Now,                    // Set the current date as the borrowed date
                        Returned_Date = DateTime.Now.AddDays(14),        // Set the return date to 14 days from now
                        Fine = 0.00,
                        Book_Status = "Borrowed"// Set the initial fine to 0
                    };

                    // Add the new record to the BorrowedBooks table
                    _context.Borrowed_Books.Add(borrowedBook);
                    await _context.SaveChangesAsync();

                    // Update the Book number of books avalaible 
                    book.Actual_Stock --;
                    _context.Books.Update(book);
                    await _context.SaveChangesAsync();

                return Ok(borrowedBook);  // Return the newly added borrowed book record

                }

                else
                {

                    return Ok(book.Title +" is out of stock");
                }

           
           
           
        }


        // 1. Stats for number of books borrowed per month (Bar Chart)
        [HttpGet("stats/BooksBorrowedPerMonth")]
        public IActionResult GetBooksBorrowedPerMonth()
        {
            var borrowedStats = _context.Borrowed_Books
                .Where(b => b.Borrowed_Date.Year == DateTime.Now.Year)
                .GroupBy(b => b.Borrowed_Date.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Count = g.Count()
                })
                .OrderBy(b => b.Month)
                .ToList();

            return Ok(borrowedStats);  // This can be used for your bar chart
        }


        // 2. Stats for most borrowed books (Pie Chart)
        [HttpGet("stats/MostBorrowedBooks")]
        
        public IActionResult GetMostBorrowedBooks()
        {
            var mostBorrowedBooks = _context.Borrowed_Books
                .GroupBy(b => b.Book_ID)
                .Select(g => new
                {
                    BookId = g.Key,
                    // Safely get the book and its title
                    Title = _context.Books
                             .Where(book => book.Id == g.Key)
                             .Select(book => book.Title)
                             .FirstOrDefault() ?? "Unknown",  // If no book is found, return "Unknown"
                    Count = g.Count()
                })
                .OrderByDescending(b => b.Count)
                .ToList();

            return Ok(mostBorrowedBooks);  // This can be used for your pie chart
        }


    }
}

