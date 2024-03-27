using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("image_id")]
        public int? ImageId { get; set; }

        [Column("image_name")]
        public string? ImageName { get; set; }

        [Column("image_path")]
        public string? ImagePath { get; set; }

        public int? ArticleId { get; set; }
    }
}
