using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // MVC Route: /User/Index
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Region)
                .ToListAsync();
            return View(users);
        }

        // API Route: GET api/users
        [HttpGet("api/users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Region)
                .ToListAsync();
        }

        // API Route: GET api/users/5
        [HttpGet("api/users/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Region)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
                return NotFound();

            return user;
        }

        // API Route: POST api/users
        [HttpPost("api/users")]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            // Set default values if not provided
            if (user.RoleId == null || user.RoleId == 0)
                user.RoleId = 1;
            if (user.RegionId == null || user.RegionId == 0)
                user.RegionId = 1;

            _context.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { error = ex.InnerException?.Message ?? ex.Message });
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        // API Route: PUT api/users/5
        [HttpPut("api/users/{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] User user)
        {
            if (id != user.UserId)
                return BadRequest();

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
                return NotFound();

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            if (user.RoleId != null && user.RoleId > 0)
                existingUser.RoleId = user.RoleId;
            if (user.RegionId != null && user.RegionId > 0)
                existingUser.RegionId = user.RegionId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // API Route: DELETE api/users/5
        [HttpDelete("api/users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}