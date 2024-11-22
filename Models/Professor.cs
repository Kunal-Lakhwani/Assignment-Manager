using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Management.Models
{
    [Table("Professor_Master")]
    public class Professor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("Prof_ID")]
        public int ID { get; set; }
        [Required, Column("Prof_FirstName")]
        public string? FirstName { get; set; }
        [Required, Column("Prof_MiddleName")]
        public string? MiddleName { get; set; }
        [Required, Column("Prof_LastName")]
        public string? LastName { get; set; }
        [Required, Column("Prof_Email")]
        public string? MailID { get; set; }
        [Required, Column("Prof_salt")]
        public string? salt { get; set; }
        [Required, Column("Prof_hash")]
        public string? hash { get; set; }

        // Foreign keys
        public ICollection<Course_Professors> Course_Professors { get; set; }
        public ICollection<Assignments> Assignments { get; set; }

        public string GetJSON()
        {
            return JsonConvert.SerializeObject(new { FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, Email = MailID });
        }
    }
}
