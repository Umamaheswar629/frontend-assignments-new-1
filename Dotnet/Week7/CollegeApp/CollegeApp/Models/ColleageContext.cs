using Microsoft.EntityFrameworkCore;
namespace CollegeApp.Models
{
    public class ColleageContext: DbContext
    {
        public ColleageContext(DbContextOptions<ColleageContext> options)
           : base(options)
        { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
