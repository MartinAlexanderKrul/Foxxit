using System;
using System.Collections.Generic;

namespace Foxxit.Models.Entities
{
    public class Post : PostBase
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }

        //each post belong to one SubReddit
        public SubReddit SubReddit { get; set; }
        public long SubRedditId { get; set; }
    }
}