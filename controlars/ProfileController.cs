using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            string? email = User.FindFirst("email")?.Value;

            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var user = await _context.Users
                .AsNoTracking()
                .Where(u => u.Email == email)
                .Select(u => new
                {
                    u.FullName,
                    u.Email
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