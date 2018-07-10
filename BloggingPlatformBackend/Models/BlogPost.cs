using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingPlatformBackend.Models
{
    [Table("BlogPost")]
    public partial class BlogPost
    {
        public BlogPost()
        {
            Comments = new HashSet<Comment>();
            PostTags = new HashSet<PostTags>();
        }

        public int BlogPostID { get; set; }
        [Required]
        [StringLength(110)]
        public string Slug { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public string Body { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        public int FavoritesCount { get; set; }
        public bool Favorited { get; set; }

        [InverseProperty("BlogPost")]
        public ICollection<Comment> Comments { get; set; }
        [InverseProperty("BlogPost")]
        public ICollection<PostTags> PostTags { get; set; }
    }
}
