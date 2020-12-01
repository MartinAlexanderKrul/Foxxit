using System;
using System.Collections.Generic;

namespace Foxxit.Models.Entities
{
    public class PostBase
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public ICollection<Vote> Votes { get; set; }
        
        public FoxxitUser Owner { get; set; }
        public long FoxxitUserId { get; set; }
        
        public PostBase()
        {
            Votes=new List<Vote>();
        }
        
    }
}