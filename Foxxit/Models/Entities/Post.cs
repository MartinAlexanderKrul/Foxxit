using System;

namespace Foxxit.Models.Entities
{
    public class Post : PostBase
    {
        public Post()
        {
        }

        public string Title { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public SubReddit SubReddit { get; set; }
        public long SubRedditId { get; set; }
    }
}