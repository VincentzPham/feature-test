using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("file_id")]
        public int? FileId { get; set; }

        [Column("file_name")]
        public string? FileName { get; set; }

        [Column("file_path")]
        public string? FilePath { get; set; }

        public int? ArticleId { get; set; }
    }
}
