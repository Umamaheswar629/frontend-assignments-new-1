using System.ComponentModel.DataAnnotations;
using CollegeDbDemo.Models;

namespace CollegeDbDemo.Models
{
    public class Course
    {
        [Key] // Primary Key
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string? CourseName { get; set; }

        [Range(1, 60, ErrorMessage = "Duration must be between 1 and 60 months")]
        public int DurationInMonths { get; set; }

        // Navigation Property
        public ICollection<Student>? Students { get; set; }

    }
}
