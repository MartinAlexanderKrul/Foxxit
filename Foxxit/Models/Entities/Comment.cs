using System;
using System.Collections.Generic;

namespace Foxxit.Models.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        
        //For comments hierarchy
        public long OriginalCommentId { get; set; }
        
        public ICollection<Vote> Votes { get; set; }
        
        public FoxxitUser Owner { get; set; }
        public long FoxxitUserId { get; set; }
    }
}