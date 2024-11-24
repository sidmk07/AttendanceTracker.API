using AttendanceTracker.API.Data;
using AttendanceTracker.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of all attendance records.
        /// </summary>
        /// <returns>A list of attendance records.</returns>
        [HttpGet]
        public IActionResult GetAllAttendance()
        {
            // Retrieve all attendance records from the database
            var attendance = _context.Attendances.ToList();

            // Return the attendance records with a 200 OK status code
            return Ok(attendance);
        }

        /// <summary>
        /// Marks attendance for a student.
        /// </summary>
        /// <param name="attendance">The attendance object containing student ID, date, and status.</param>
        /// <returns>A success message if attendance is marked successfully.</returns>
        [HttpPost]
        public IActionResult MarkAttendance([FromBody] Attendance attendance)
        {
            // Check if the attendance object is null
            if (attendance == null)
            {
                // Return bad request if attendance object is null
                return BadRequest();
            }

            // Add attendance to the database context
            _context.Attendances.Add(attendance);

            // Save changes to the database
            _context.SaveChanges();

            // Return a success message
            return Ok(new { message = "Attendance marked successfully" });
        }
    }
}
