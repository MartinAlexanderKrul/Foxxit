using System;

namespace Foxxit.Models.Entities
{
    public class Comment : PostBase
    {
        public Comment()
        {
        }

        public Comment(string text, long userId, long? originalCommentId = null, long? postId = null)
        {
            Text = text;
            UserId = userId;
            OriginalCommentId = originalCommentId;
            PostId = postId;
        }

        public long? OriginalCommentId { get; set; }
        public Post Post { get; set; }
        public long? PostId { get; set; }
    }
}