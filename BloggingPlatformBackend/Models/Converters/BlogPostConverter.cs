using BloggingPlatformBackend.Models.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatformBackend.Models.Converters
{
    public class BlogPostConverter
    {
        private BloggingPlatformDB db;
        

        public BlogPostConverter(BloggingPlatformDB _db)
        {
            db = _db;
           
        }

        public BlogPostView ToBlogPostView(BlogPost blogPost)
        {
            //Eager loads tags
            db.PostTags.Include(pt => pt.Tag).ToList();

            BlogPostView blogPostView = new BlogPostView
                {
                    Slug = blogPost.Slug,
                    Title = blogPost.Title,
                    Description = blogPost.Description,
                    Body = blogPost.Body,
                    CreatedAt = blogPost.CreatedAt,
                    UpdatedAt = blogPost.UpdatedAt,
                    FavoritesCount = blogPost.FavoritesCount,
                    Favorited = blogPost.Favorited,
                    TagList = blogPost.PostTags.Select(pt => pt.Tag.TagName)
                };

             return blogPostView;
        }
            
            

     }
   }

