using AttendanceTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

    }
    // Add DbSet properties here (e.g., Students, Attendance)
}
