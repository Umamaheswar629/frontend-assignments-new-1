using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CollegeApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(40)]
        public string? StudentName { get; set; }
        [Range(17,30,ErrorMessage ="Age must be 17 to 30")]
        public int Age { get; set; }
        [Required]
        [ForeignKey("Course")]
        //foriegn key
        public int CousrseId { get; set; }
    }
}