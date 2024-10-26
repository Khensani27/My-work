using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_API.Data;

namespace Library_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Admins/getAdmins
        [HttpGet("getAdmins")]
        public async Task<ActionResult<List<Admins>>> GetAdmins()
        {
            return Ok(await _context.Admins.ToListAsync());
        }

        // GET: api/Admins/getAdmin/{id}
        [HttpGet("getAdmin/{id}")]
        public async Task<ActionResult<Admins>> GetAdminById(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
                return NotFound("Admin not found");

            return Ok(admin);
        }

        // POST: api/Admins/addAdmin
        [HttpPost("addAdmin")]
        public async Task<ActionResult> AddAdmin(Admins admin)
        {
            if (admin == null)
            {
                return BadRequest("Invalid admin data");
            }

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return Ok(admin);  // Return the added admin
        }

        // PUT: api/Admins/updateAdmin/{id}
        [HttpPut("updateAdmin/{id}")]
        public async Task<ActionResult> UpdateAdmin(int id, Admins updatedAdmin)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
                return NotFound("Admin not found");

            admin.Password = updatedAdmin.Password;

            await _context.SaveChangesAsync();

            return Ok(admin);  // Return the updated admin
        }

        // DELETE: api/Admins/removeAdmin/{id}
        [HttpDelete("removeAdmin/{id}")]
        public async Task<ActionResult> RemoveAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
                return NotFound("Admin not found");

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return Ok(admin);  // Return the deleted admin
        }
    }
}
