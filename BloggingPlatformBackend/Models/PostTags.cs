using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingPlatformBackend.Models
{
    [Table("PostTags")]
    public partial class PostTags
    {
        public int BlogPostID { get; set; }
        public int TagID { get; set; }

        [ForeignKey("BlogPostID")]
        [InverseProperty("PostTags")]
        public BlogPost BlogPost { get; set; }
        [ForeignKey("TagID")]
        [InverseProperty("PostTags")]
        public Tag Tag { get; set; }
    }
}
