using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPost.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [Column("user_name")]
        public override string? UserName { get; set; }

        [Column("user_email")]
        [Required]
        public override string? Email { get; set; }

        //[Required]
        [Column("faculty_id")]
        public int? FacultyId { get; set; }

        //[Required]
        [Column("role_id")]
        public int? RoleId { get; set; }
    }
}