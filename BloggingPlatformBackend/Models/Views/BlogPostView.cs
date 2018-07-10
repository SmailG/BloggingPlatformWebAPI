using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatformBackend.Models.Views
{
    public class BlogPostView
    {
        
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int FavoritesCount { get; set; }
        public bool Favorited { get; set; }
        public IEnumerable<string> TagList { get; set; }

    }
}
