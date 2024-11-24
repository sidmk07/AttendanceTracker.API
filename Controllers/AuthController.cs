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

        /// <summary>
        /// Handles the login request.
        /// </summary>
        /// <param name="request">The login request containing the email.</param>
        /// <returns>A JSON response with a message and the user's role if the login is successful, otherwise an Unauthorized result.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Attempt to find a user with the provided email in the database
            var user = _context.Users.SingleOrDefault(u => u.Email == request.Email);

            // If no user is found, return an Unauthorized result with a message
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            // If a user is found, return an Ok result with a message and the user's role
            return Ok(new { Message = "Login successful", user.Role });
        }
    }
}
