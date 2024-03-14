using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPost.Models
{
    public class Role : IdentityRole<int>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("role_id")]
        public override int Id { get => base.Id; set => base.Id = value; }
        //public int? RoleId { get; set; }

        [Column("rolename")]
        public override string? Name { get => base.Name; set => base.Name = value; }
        //[Required]
        //public string? RoleName { get; set; }
    }
}
