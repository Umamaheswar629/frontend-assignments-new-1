using Microsoft.EntityFrameworkCore;

namespace CollegeDbDemo.Models
{
    public class collegeContext:DbContext

    {
        public collegeContext(DbContextOptions<collegeContext> options)
          : base(options)
        { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
    