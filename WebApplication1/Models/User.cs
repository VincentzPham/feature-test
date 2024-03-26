using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class User : IdentityUser<int>
    {
        [Column("user_name")]
        [Required]
        public override string? UserName { get; set; }

        [Column("user_email")]
        [Required]
        public override string? Email { get; set; }

        [Column("password")]
        [Required]
        public override string? PasswordHash { get; set; }

        [Column("user_role")]
        [ForeignKey("role")]
        public int? RoleId {  get; set; }

        public Role? Role { get; set; }
    }
}
