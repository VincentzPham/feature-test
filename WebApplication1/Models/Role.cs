using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class Role : IdentityRole<int>
    {
        
        [Column("role_id")]
        [Required]
        public override int Id { get; set; }

        [Column("role_name")]
        [Required]
        public override string? Name { get; set; }

        public List<User>? Users { get; set; }
    }
}
