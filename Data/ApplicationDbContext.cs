using Microsoft.EntityFrameworkCore;

namespace AttendanceTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // Add DbSet properties here (e.g., Students, Attendance)
    }
}
