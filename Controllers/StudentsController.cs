using AttendanceTracker.API.Data;
using AttendanceTracker.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of all students in the database.
        /// </summary>
        /// <returns>A list of all students in the database.</returns>
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            // Retrieve all students from the database
            var students = _context.Students.ToList();

            // Return the list of students with a 200 OK status code
            return Ok(students);
        }

        /// <summary>
        /// Retrieves a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve.</param>
        /// <returns>The student with the specified ID, or a 404 Not Found result if no student is found.</returns>
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            // Attempt to find the student with the specified ID in the database
            var student = _context.Students.Find(id);

            // Check if the student is found
            if (student == null)
            {
                // Return a 404 Not Found result if the student is not found
                return NotFound();
            }

            // Return the student with a 200 OK result
            return Ok(student);
        }

        /// <summary>
        /// Creates a new student in the database.
        /// </summary>
        /// <param name="student">The student to be created.</param>
        /// <returns>A 201 Created response with the newly created student, or a 400 Bad Request response if the student is null.</returns>
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            // Check if the student object is not null
            if (student != null)
            {
                // Add the student to the database context
                _context.Students.Add(student);

                // Save the changes to the database
                _context.SaveChanges();

                // Return a 201 Created response with the newly created student
                return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
            }
            else
            {
                // Return a 400 Bad Request response if the student is null
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates a student with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the student to update.</param>
        /// <param name="updatedStudent">The updated student data.</param>
        /// <returns>NoContentResult if the update is successful, NotFoundResult if the student is not found.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            // Attempt to find the student with the specified ID in the database
            var student = _context.Students.Find(id);

            // Check if the student is found
            if (student == null)
            {
                // Return NotFoundResult if the student is not found
                return NotFound();
            }

            // Update the student data
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Class = updatedStudent.Class;

            // Save the changes to the database
            _context.SaveChanges();

            // Return NoContentResult to indicate a successful update
            return NoContent();
        }

        /// <summary>
        /// Deletes a student with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the student to delete.</param>
        /// <returns>NoContentResult if the deletion is successful, NotFoundResult if the student is not found.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            // Attempt to find the student with the specified ID in the database
            var student = _context.Students.Find(id);

            // Check if the student is found
            if (student == null)
            {
                // Return a 404 Not Found result if the student is not found
                return NotFound();
            }

            // Remove the student from the database context
            _context.Students.Remove(student);

            // Save the changes to the database
            _context.SaveChanges();

            // Return a 204 No Content result to indicate a successful deletion
            return NoContent();
        }
    }
}
