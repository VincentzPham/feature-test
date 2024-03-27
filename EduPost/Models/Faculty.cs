using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("faculty_id")]
        public int? FacultyId { get; set; }

        [Column("facultyName")]
        public string? FacultyName { get; set; }
    }
}
