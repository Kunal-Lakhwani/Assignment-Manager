using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Management.Models
{
    public class Assignment_Images
    {
        [Required,DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("Image_ID")]
        public int ID { get; set; }

        public Assignments Assignments { get; set; }
        [Required, ForeignKey("Assignment_ID"), Column("Img_AssignID")]
        public int AssignID { get; set; }

        [Required, Column("Img_FilePath")]
        public string? FilePath { get; set; }
    }
}
