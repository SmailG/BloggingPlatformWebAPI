using BloggingPlatformBackend.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatformBackend.Models.Converters
{
    public class CommentConverter
    {


        public CommentView ToCommentView(Comment comment)
        {
            CommentView commentView = new CommentView {
                CommentID = comment.CommentID,
                Body = comment.Body,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt
            };

            return commentView;
        }

    }
}
