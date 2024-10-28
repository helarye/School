using Microsoft.EntityFrameworkCore;
using School.Models;


namespace School.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudItem> StudItem { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
    }
}
