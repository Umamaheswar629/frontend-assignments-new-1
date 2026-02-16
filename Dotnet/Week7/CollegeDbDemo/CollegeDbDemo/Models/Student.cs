using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CollegeDbDemo.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string? StudentName { get; set; }

        [Range(17, 30)]
        public int Age { get; set; }

        // 🔗 Foreign Key
        public int CourseId { get; set; }

        //  Navigation Property (THIS enables Include)
        [JsonIgnore] // prevents circular JSON issues
        public Course? Course { get; set; }
    }
}
