using System;

namespace Foxxit.Models.Entities
{
    public class Comment : PostBase
    {
        public Comment()
        {
            CreatedAt = DateTime.Now;
        }

        public long OriginalCommentId { get; set; }
        public Post Post { get; set; }
        public long PostId { get; set; }
    }
}