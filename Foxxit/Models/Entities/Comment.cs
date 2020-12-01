using System;
using System.Collections.Generic;

namespace Foxxit.Models.Entities
{
    public class Comment:PostBase
    {
        //For comments hierarchy
        public ICollection<Comment> Comments { get; set; }
        public long OriginalCommentId { get; set; }
        
        public Post Post { get; set; }
        public long PostId { get; set; }
    }
}