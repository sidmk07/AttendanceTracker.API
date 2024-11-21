using AttendanceTracker.API.Data;
using AttendanceTracker.API.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public IActionResult GetAllAttendance()
        {
            var attendance = _context.Attendances.ToList();
            return Ok(attendance);
        }

        [HttpPost]
        public IActionResult MarkAttendance([FromBody] Attendance attendance)
        {
            if (attendance == null)
                return BadRequest();

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok(new { message = "Attendance marked successfully" });
        }
    }
}
