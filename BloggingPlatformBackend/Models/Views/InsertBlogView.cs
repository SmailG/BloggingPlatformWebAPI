using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatformBackend.Models.Views
{
    public class InsertBlogView
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> TagList { get; set; }
    }
}
