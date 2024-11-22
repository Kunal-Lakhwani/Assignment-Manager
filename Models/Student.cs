using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Management.Models
{
    [Table("Student_Master")]
    public class Student
    {
        [Key, Column("Student_PRN"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PRN { get; set; }
        [Required, Column("Student_FirstName")]
        public string? FirstName { get; set; }
        [Required, Column("Student_MiddleName")]
        public string? MiddleName { get; set; }
        [Required, Column("Student_LastName")]
        public string? LastName { get; set; }
        [Required, Column("Student_EMail")]
        public string? MailID { get; set; }
        [Required, Column("Student_salt")]
        public string? salt { get; set; }
        [Required, Column("Student_hash")]
        public string? hash { get; set; }

        // Foreign keys
        public ICollection<Course_Students> Course_Students { get; set; } = default!;
        public ICollection<Submissions> Submissions { get; set; }

        public string GetJSON()
        {
            return JsonConvert.SerializeObject(new { PRN = PRN, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, Email = MailID });
        }
    }
}
