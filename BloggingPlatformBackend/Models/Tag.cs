using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingPlatformBackend.Models
{
    [Table("Tag")]
    public partial class Tag
    {
        public Tag()
        {
            PostTags = new HashSet<PostTags>();
        }

        public int TagID { get; set; }
        [Required]
        [StringLength(50)]
        public string TagName { get; set; }

        [InverseProperty("Tag")]
        public ICollection<PostTags> PostTags { get; set; }
    }
}
