using System;
using System.Collections.Generic;

namespace Foxxit.Models.Entities
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        
        //each post belong to one SubReddit
        public SubReddit SubReddit { get; set; }
        public long SubRedditId { get; set; }
        
        //each post has one Owner
        public FoxxitUser Owner { get; set; }
        public long FoxxitUserId { get; set; }
        
        //each post has many Votes
        public ICollection<Vote> Votes { get; set; }

        public Post()
        {
            Votes=new List<Vote>();
        }
    }
}