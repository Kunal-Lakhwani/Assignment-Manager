using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Management.Models
{
    public class Course_Professors
    {
        [Key, Column("CourseProf_ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Course Course { get; set; }
        [ForeignKey("Course_ID"), Column("Prof_CourseID")]
        public int CourseID { get; set; }
        
        public Professor Professor { get; set; }
        [ForeignKey("Prof_ID"), Column("Course_Prof")]
        public int ProfID { get; set; }
    }
}
