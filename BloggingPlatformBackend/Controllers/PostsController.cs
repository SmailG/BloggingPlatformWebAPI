using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingPlatformBackend.Extensions;
using BloggingPlatformBackend.Models;
using BloggingPlatformBackend.Models.Converters;
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
        private BlogPostConverter bpConverter;

        public PostsController(BloggingPlatformDB _db, BlogPostConverter _bpConverter)
        {
            db = _db;
            bpConverter = _bpConverter;
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
               blogPostView = bpConverter.ToBlogPostView(blogPost);
            }
            return blogPostView;
        }

        // POST api/posts
        [HttpPost]
        public ActionResult<BlogPostView> AddBlogPost([FromBody] InsertBlogView ibv)
        {

            BlogPost blogPost = new BlogPost();
            blogPost.Title = ibv.Title;
            blogPost.Description = ibv.Description;
            blogPost.Body = ibv.Body;

            foreach (string tag in ibv.TagList)
            {
                // If for some reason an non-existant an unknown tag is passed
                try
                {
                    PostTags pt = new PostTags { BlogPostID = blogPost.BlogPostID, TagID = db.Tags.SingleOrDefault(t => t.TagName == tag).TagID };
                    if (pt != null)
                    {
                        blogPost.PostTags.Add(pt);
                    }
                }
                catch {
                    continue;
                }
            }

            blogPost.CreatedAt = DateTime.Now;
            blogPost.UpdatedAt = blogPost.CreatedAt;
            blogPost.Favorited = false;
            blogPost.FavoritesCount = 0;
            blogPost.Slug = SlugGenerator(blogPost.Title);

            db.BlogPosts.Add(blogPost);
            db.SaveChanges();

            return bpConverter.ToBlogPostView(blogPost);
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
        public ActionResult<BlogPostView> UpdateBlogPost(string slug, [FromBody] InsertBlogView insertBlogView)
        {
            BlogPost blogPost = db.BlogPosts.Include(bp => bp.PostTags).FirstOrDefault(bp => bp.Slug == slug);

            if (!string.IsNullOrWhiteSpace(insertBlogView.Body))
                blogPost.Body = insertBlogView.Body;

            if (!string.IsNullOrWhiteSpace(insertBlogView.Description))
                blogPost.Description = insertBlogView.Description;

            if (!string.IsNullOrWhiteSpace(insertBlogView.Title) && !blogPost.Title.Equals(insertBlogView.Title))
            {
                blogPost.Title = insertBlogView.Title;
                blogPost.Slug = SlugGenerator(insertBlogView.Title);
            }

            blogPost.UpdatedAt = DateTime.Now;

            db.Entry(blogPost).State = EntityState.Modified;
            db.SaveChanges();

            return bpConverter.ToBlogPostView(blogPost);
        }

        // DELETE api/values/5
        [HttpDelete("{slug}")]
        public void Delete(string slug)
        {
            BlogPost blogPost = db.BlogPosts.Include(bp=>bp.PostTags).FirstOrDefault(bp => bp.Slug == slug);
            db.BlogPosts.Remove(blogPost);
            db.SaveChanges();
        }


        //Favoriting logic
        [HttpPost]
        [Route("{slug}/favorite")]
        public ActionResult<BlogPostView> Favorite(string slug)
        {
            BlogPost blogPost = db.BlogPosts.Include(bp => bp.PostTags).FirstOrDefault(bp => bp.Slug == slug);
            blogPost.FavoritesCount++;
            blogPost.Favorited = true;

            db.Entry(blogPost).State = EntityState.Modified;
            db.SaveChanges();

            return bpConverter.ToBlogPostView(blogPost);
        }

        [HttpDelete]
        [Route("{slug}/favorite")]
        public ActionResult<BlogPostView> UnFavorite(string slug)
        {
            BlogPost blogPost = db.BlogPosts.Include(bp => bp.PostTags).FirstOrDefault(bp => bp.Slug == slug);
            if (blogPost.FavoritesCount > 0)
            {
                blogPost.FavoritesCount--;
            }

            blogPost.Favorited = blogPost.FavoritesCount <= 0 ? false : true;

            db.Entry(blogPost).State = EntityState.Modified;
            db.SaveChanges();

            return bpConverter.ToBlogPostView(blogPost);
        }


    }
}