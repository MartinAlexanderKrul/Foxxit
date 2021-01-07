using System;
using System.ComponentModel.DataAnnotations;

namespace Foxxit.Models.Entities
{
    public class Comment : PostBase
    {
        public Comment()
        {
        }

        public Comment(string text, long userId, long postId)
        {
            Text = text;
            UserId = userId;
            PostId = postId;
        }

        public long OriginalCommentId { get; set; }
        public Post Post { get; set; }
        public long PostId { get; set; }
    }
}