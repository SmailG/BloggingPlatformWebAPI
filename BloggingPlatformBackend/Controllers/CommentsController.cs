using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingPlatformBackend.Models;
using BloggingPlatformBackend.Models.Converters;
using BloggingPlatformBackend.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformBackend.Controllers
{
    [Route("api/Posts")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private BloggingPlatformDB db;
        private CommentConverter commentConverter;

        public CommentsController(BloggingPlatformDB _db, CommentConverter _commentConverter)
        {
            db = _db;
            commentConverter = _commentConverter;
            
        }

        //Get comments from blog post
        [HttpGet]
        [Route("{slug}/comments")]
        public ActionResult<IEnumerable<CommentView>> GetComments(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return BadRequest();
            }
            BlogPost blogPost = db.BlogPosts.Include(bp => bp.Comments).FirstOrDefault(bp => bp.Slug == slug);
            if (blogPost != null)
            {
                IEnumerable<CommentView> commentList = blogPost.Comments.Select(c => commentConverter.ToCommentView(c));

                return commentList.ToList();
            }

            return BadRequest();
        }

        //Add comment
        [HttpPost]
        [Route("{slug}/comments")]
        public ActionResult<CommentView> AddComment(string slug, [FromBody] string body)
        {
            if (!string.IsNullOrWhiteSpace(body))
            {
                BlogPost blogPost = db.BlogPosts.Include(bp => bp.Comments).FirstOrDefault(bp => bp.Slug == slug);
                if (blogPost != null)
                {
                    Comment comment = new Comment
                    {
                        BlogPostID = blogPost.BlogPostID,
                        Body = body,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    blogPost.Comments.Add(comment);
                    db.Entry(blogPost).State = EntityState.Modified;
                    db.SaveChanges();

                    return commentConverter.ToCommentView(comment);
                }

                return NotFound();
            }

            else {
                return BadRequest();
            }
        }

        //Delete comment
        [HttpDelete]
        [Route("{slug}/comments/{id}")]
        public void DeleteComment(string slug, int id)
        {
            BlogPost blogPost = db.BlogPosts.Include(bp => bp.Comments).FirstOrDefault(bp => bp.Slug == slug);
            if (blogPost != null)
            {
                Comment comment = blogPost.Comments.FirstOrDefault(c => c.CommentID == id);

                if (comment != null)
                {
                    blogPost.Comments.Remove(comment);
                    db.Entry(blogPost).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

    }
}