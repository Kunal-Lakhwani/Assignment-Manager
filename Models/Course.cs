using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Management.Models
{
    [Table("Course_Master")]
    public class Course
    {
        [Key, Column("Course_ID")]
        public int ID { get; set; }        
        [Required, Column("Course_Name")]
        public string? Name { get; set; }

        [Required, Column("Course_Semester")]
        public int Semester { get; set;}
        
        [Required, Column("Course_link")]
        public string? Link { get; set; }
        
        [Required, Column("Course_Status")]
        public Course_Status Status { get; set; }

        // Foreign keys
        public ICollection<Course_Professors> CourseProfessors { get; set; } = default!;
        public ICollection<Course_Students> CourseStudents { get; set; } = default!;
        public ICollection<Assignments> CourseAssignments { get; set;} = default!;

    }
    public enum Course_Status
    {
        Active=0, Archived=1
    }
}
