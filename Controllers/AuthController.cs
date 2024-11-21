using AttendanceTracker.API.Data;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == request.Email);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new { Message = "Login successful", user.Role });
        }
    }
}
