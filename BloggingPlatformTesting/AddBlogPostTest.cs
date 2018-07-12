using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BloggingPlatformBackend.Controllers;
using BloggingPlatformBackend.Models;
using BloggingPlatformBackend.Models.Converters;



namespace BloggingPlatformTesting
{
    class AddBlogPostTest
    {
        private readonly PostsController postController;

        public AddBlogPostTest()
        {
            postController = new PostsController(new BloggingPlatformDB(), new BlogPostConverter(new BloggingPlatformDB()));
        }


    }
}
