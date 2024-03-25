using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPost.Models
{
    public class Role :IdentityRole<int>
    {
        [Column("role_id")]
        [Required]
        public override int Id { get; set; }

        [Column("roleName")]
        [Required]
        public override string? Name { get; set; }
    }
}
