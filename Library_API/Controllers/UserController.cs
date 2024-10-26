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
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: api/User/getUsers
        [HttpGet("getUsers")]
        public async Task<ActionResult<List<Users>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        // GET: api/User/getUser?email={email}&password={password}
        [HttpGet("getUser")]
        public async Task<ActionResult<Users>> GetUser(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // POST: api/User/addUser
        [HttpPost("addUser")]
        public async Task<ActionResult> AddUser(Users user)
        {
            if (user != null)
            {
               
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);  // Return the added user
            }
            return BadRequest("Invalid user data");
        }

        // GET: api/User/getUserByID?id={id}
        [HttpGet("getUserByID")]
        public async Task<ActionResult<Users>> GetUserByID(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // DELETE: api/User/removeUser?userID={userID}
        [HttpDelete("removeUser")]
        public async Task<ActionResult<Users>> RemoveUser(int userID)
        {
            var user = await _context.Users.FindAsync(userID);

            if (user == null)
                return NotFound("User not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);  // Return the deleted user
        }
    }
}
