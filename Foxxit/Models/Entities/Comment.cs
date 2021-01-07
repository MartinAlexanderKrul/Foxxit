using System;
using System.ComponentModel.DataAnnotations;

namespace Foxxit.Models.Entities
{
    public class Comment : PostBase
    {
        public Comment()
        {
        }

        public Comment(string text, User user, Post post)
        {
            Text = text;
            User = user;
            Post = post;
        }

        public long OriginalCommentId { get; set; }
        public Post Post { get; set; }
        public long PostId { get; set; }
    }
}