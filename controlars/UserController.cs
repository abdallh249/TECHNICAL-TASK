using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize(Roles = "User,Admin")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> GetUser()
        {
            string? userId = User.FindFirstValue("sub");

            if (!int.TryParse(userId, out int id))
            {
                return Unauthorized();
            }

            var user = await _context.Users
                .AsNoTracking()
                .Where(u => u.ID == id)
                .Select(u => new
                {
                    u.ID,
                    u.FullName,
                    u.Email,
                    u.role
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }
    }
}