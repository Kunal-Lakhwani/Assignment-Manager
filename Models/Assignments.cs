using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Management.Models
{
    [Table("Assignment_master")]
    public class Assignments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("Assignment_ID")]
        public int Id { get; set; }

        public Course Course { get; set; }
        [Required, ForeignKey("Course_ID")]
        public int CourseID { get; set; }

        public Professor Professor { get; set; }
        [Required, ForeignKey("Prof_ID"), Column("Assigned_by_prof")]
        public int ProfID { get; set; }

        [Required]
        public int Assignment_No { get; set; }

        [Required, Column("Assignment_Type")]
        public Assign_Type Type { get; set; }

        [Required, Column("Assignment_Title")]
        public string? Title { get; set; }

        [Required, Column("Assignment_Descrip")]
        public string? Description { get; set; }

        [Required, Column("Assigned_on"), DatabaseGenerated(DatabaseGeneratedOption.Computed), DataType(DataType.Date)]
        [DefaultValue("getutcdate()")]
        public DateTime? AssignedOn { get; set; }

        [Required]
        public DateTime? Deadline { get; set; }

        // foreign keys
        public ICollection<Assignment_Images> Images { get; set; } = default!;
    }

    public enum Assign_Type { 
        Writeup=0, Coding=1
    }
}
