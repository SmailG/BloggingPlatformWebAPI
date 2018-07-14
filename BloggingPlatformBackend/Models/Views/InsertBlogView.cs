using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatformBackend.Models.Views
{
    public class InsertBlogView
    {
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(4000)]
        public string Body { get; set; }
        public IEnumerable<string> TagList { get; set; }
    }
}
