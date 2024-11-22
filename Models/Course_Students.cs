using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment_Management.Models
{
    public class Course_Students
    {
        [Key, Column("Course_Enrolled_ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Course Course { get; set; } = default!;
        [ForeignKey("Course_ID"), Column("Enrolled_CourseID")]
        public int CourseID { get; set; }

        public Student Student { get; set; } = default!;
        [ForeignKey("Student_PRN"), Column("Enrolled_PRN")]
        public long StudentPRN { get; set; }
    }
}
