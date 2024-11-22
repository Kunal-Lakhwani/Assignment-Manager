using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Management.Models
{
    public class Submissions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Assignments Assignments { get; set; }
        [Required, ForeignKey("Assignment_ID"), Column("Assign_ID")]
        public int AssignID { get; set; }

        public Student Student { get; set; }
        [Required, ForeignKey("Student_PRN"), Column("Student_PRN")]
        public long SubmittedBy { get; set;}

        [Required, Column("Submitted_on")]
        public DateTime? SubmittedDate { get; set;}

        [Required, Column("Submission_FilePath")]
        public string FilePath { get; set; }
    }
}
