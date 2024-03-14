using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("comment_id")]
        public int? Comment_id { get; set; }

        [Column("context")]
        [Required]
        public string? Context { get; set; }

        [Column("article_id")]
        [Required]
        public int? Artice_id { get; set; }

        [Column("user_id")]
        [Required]
        public int? User_id { get; set; }

        [Column("commentDate")]
        [Required]
        public DateTimeOffset? CreatedDate { get; set; }
    }
}