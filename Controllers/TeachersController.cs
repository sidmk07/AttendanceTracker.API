using AttendanceTracker.API.Data;
using AttendanceTracker.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of all teachers in the database.
        /// </summary>
        /// <returns>A list of all teachers in the database.</returns>
        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            // Retrieve all teachers from the database
            var teachers = _context.Teachers.ToList();
            // Return the list of teachers with a 200 OK status code
            return Ok(teachers);
        }

        /// <summary>
        /// Retrieves a teacher by their ID.
        /// </summary>
        /// <param name="id">The ID of the teacher to retrieve.</param>
        /// <returns>The teacher with the specified ID, or a 404 Not Found result if no teacher is found.</returns>
        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            // Attempt to find the teacher with the specified ID in the database
            var teacher = _context.Teachers.Find(id);

            // Check if the teacher is found
            if (teacher == null)
            {
                // Return a 404 Not Found result if the teacher is not found
                return NotFound();
            }

            // Return the teacher with a 200 OK status code
            return Ok(teacher);
        }

        /// <summary>
        /// Creates a new teacher in the database.
        /// </summary>
        /// <param name="teacher">The teacher to be created.</param>
        /// <returns>A 201 Created response with the newly created teacher, or a 400 Bad Request response if the teacher is null.</returns>
        [HttpPost]
        public IActionResult CreateTeacher([FromBody] Teacher teacher)
        {
            // Check if the teacher object is not null
            if (teacher != null)
            {
                // Add the teacher to the database context
                _context.Teachers.Add(teacher);

                // Save the changes to the database
                _context.SaveChanges();

                // Return a 201 Created response with the newly created teacher
                return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
            }
            else
            {
                // Return a 400 Bad Request response if the teacher is null
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates a teacher with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the teacher to update.</param>
        /// <param name="updatedTeacher">The updated teacher data.</param>
        /// <returns>NoContentResult if the update is successful, NotFoundResult if the teacher is not found.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher updatedTeacher)
        {
            // Attempt to find the teacher with the specified ID in the database
            var teacher = _context.Teachers.Find(id);

            // Check if the teacher is found
            if (teacher == null)
            {
                // Return NotFoundResult if the teacher is not found
                return NotFound();
            }

            // Update the teacher data
            teacher.Name = updatedTeacher.Name;

            // Save the changes to the database
            _context.SaveChanges();

            // Return NoContentResult to indicate a successful update
            return NoContent();
        }

        /// <summary>
        /// Deletes a teacher with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the teacher to delete.</param>
        /// <returns>NoContentResult if the deletion is successful, NotFoundResult if the teacher is not found.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            // Attempt to find the teacher with the specified ID in the database
            var teacher = _context.Teachers.Find(id);

            // Check if the teacher is found
            if (teacher == null)
            {
                // Return NotFoundResult if the teacher is not found
                return NotFound();
            }

            // Remove the teacher from the database context
            _context.Teachers.Remove(teacher);

            // Save the changes to the database
            _context.SaveChanges();

            // Return NoContentResult to indicate a successful deletion
            return NoContent();
        }
    }
}
