using AttendanceTracker.API.Data;
using AttendanceTracker.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of all users in the database.
        /// </summary>
        /// <returns>A list of all users in the database.</returns>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            // Retrieve all users from the database and return them as a list.
            return Ok(_context.Users.ToList());
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID, or a 404 Not Found result if no user is found.</returns>
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            // Attempt to find the user with the specified ID in the database
            var user = _context.Users.Find(id);

            // If no user is found, return a 404 Not Found result
            if (user == null)
            {
                return NotFound();
            }

            // If a user is found, return the user with a 200 OK result
            return Ok(user);
        }

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">The user to be created.</param>
        /// <returns>A 201 Created response with the newly created user, or a 400 Bad Request response if the user is null.</returns>
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            // Check if the user object is not null
            if (user != null)
            {
                // Add the user to the database context
                _context.Users.Add(user);

                // Save the changes to the database
                _context.SaveChanges();

                // Return a 201 Created response with the newly created user
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            else
            {
                // Return a 400 Bad Request response if the user is null
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates a user with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="updatedUser">The updated user data.</param>
        /// <returns>NoContentResult if the update is successful, NotFoundResult if the user is not found, or BadRequestResult if the ID is invalid.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            // Check if the ID is valid (greater than 0)
            if (id > 0)
            {
                // Find the user with the specified ID
                var user = _context.Users.Find(id);

                // Check if the user is found
                if (user == null)
                {
                    // Return NotFoundResult if the user is not found
                    return NotFound();
                }
                else
                {
                    // Update the user data
                    user.Name = updatedUser.Name;
                    user.Email = updatedUser.Email;
                    user.PasswordHash = updatedUser.PasswordHash;
                    user.Role = updatedUser.Role;

                    // Save the changes to the database
                    _context.SaveChanges();

                    // Return NoContentResult to indicate a successful update
                    return NoContent();
                }
            }
            else
            {
                // Return BadRequestResult if the ID is invalid
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes a user with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>NoContentResult if the deletion is successful, NotFoundResult if the user is not found.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Attempt to find the user with the specified ID in the database
            var user = _context.Users.Find(id);

            // Check if the user is found
            if (user == null)
            {
                // Return NotFoundResult if the user is not found
                return NotFound();
            }

            // Remove the user from the database context
            _context.Users.Remove(user);

            // Save the changes to the database
            _context.SaveChanges();

            // Return NoContentResult to indicate a successful deletion
            return NoContent();
        }
    }
}
