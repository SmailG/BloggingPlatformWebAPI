using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingPlatformBackend.Extensions;
using BloggingPlatformBackend.Models;
using BloggingPlatformBackend.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BloggingPlatformBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BloggingPlatformDB db;

        public PostsController(BloggingPlatformDB _db)
        {
            db = _db;
        }

        // GET api/posts
        [HttpGet]
        public ActionResult<IEnumerable<BlogPostView>> Get(string tag , int skipPosts = 0, int pageSize = 10)
        {
            IEnumerable<BlogPostView> postList = db.BlogPosts
                .OrderByDescending(bp => bp.UpdatedAt)
                .Select(bp => new BlogPostView
                {
                    Slug = bp.Slug,
                    Title = bp.Title,
                    Description = bp.Description,
                    Body = bp.Body,
                    CreatedAt = bp.CreatedAt,
                    UpdatedAt = bp.UpdatedAt,
                    FavoritesCount = bp.FavoritesCount,
                    Favorited = bp.Favorited,
                    TagList = bp.PostTags.Select(pt => pt.Tag.TagName)
                });

            if (tag != null)
            {
               postList = postList.Where(bp => bp.TagList.Contains(tag));
            }

            postList.Skip(skipPosts)
            .Take(pageSize);
          
            return postList.ToList();

        }

        // GET api/posts/java-programming
        [HttpGet("{slug}")]
        public ActionResult<BlogPostView> GetBySlug(string slug)
        {
            BlogPostView blogPostView = null;
            BlogPost blogPost = db.BlogPosts.Where(bp => bp.Slug == slug).Include(bp => bp.PostTags).FirstOrDefault();

            if (blogPost != null)
            {
                 blogPostView = new BlogPostView {
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
            }
            return blogPostView;
        }

        // POST api/posts
        [HttpPost]
        public void Post([FromBody] InsertBlogView ibv)
        {

            BlogPost bp = new BlogPost();
            bp.Title = ibv.Title;
            bp.Description = ibv.Description;
            bp.Body = ibv.Body;

            foreach (string tag in ibv.TagList)
            {
                // If for some reason an non-existant an unknown tag is passed
                try
                {
                    PostTags pt = new PostTags { BlogPostID = bp.BlogPostID, TagID = db.Tags.SingleOrDefault(t => t.TagName == tag).TagID };
                    if (pt != null)
                    {
                        bp.PostTags.Add(pt);
                    }
                }
                catch {
                    continue;
                }
                
               
            }

            bp.CreatedAt = DateTime.Now;
            bp.UpdatedAt = bp.CreatedAt;
            bp.Favorited = false;
            bp.FavoritesCount = 0;
            bp.Slug = SlugGenerator(bp.Title);

            db.BlogPosts.Add(bp);
            db.SaveChanges();

            RedirectToAction("GetBySlug", new { slug = bp.Slug });
        }

        //Generates blog post slug from blog title
        private string SlugGenerator(string slug)
        {
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", "!", "?", "{", "}", "[", "]", "(", ")" };
            foreach (var c in charsToRemove)
            {
                slug = slug.Replace(c, string.Empty);
            }

            slug = slug.ToLower().Trim();
            slug = slug.RemoveDiacritics().Replace(' ', '-');

            return slug;
        }

        // PUT api/values/slug
        [HttpPut("{slug}")]
        public void Put(string slug, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}