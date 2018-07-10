using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingPlatformBackend.Models
{
    [Table("Comment")]
    public partial class Comment
    {
        public int CommentID { get; set; }
        public int BlogPostID { get; set; }
        [Required]
        [StringLength(500)]
        public string Body { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("BlogPostID")]
        [InverseProperty("Comments")]
        public BlogPost BlogPost { get; set; }
    }
}
