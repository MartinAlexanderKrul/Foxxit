using System;

namespace Foxxit.Models.Entities
{
    public class Post : PostBase
    {
        public Post()
        {
        }

        public Post(string title, string url, string imageUrl, string text, long subRedditId)
        {
            Title = title;
            URL = url;
            ImageURL = imageUrl;
            Text = text;
            SubRedditId = subRedditId;
        }

        public string Title { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public SubReddit SubReddit { get; set; }
        public long SubRedditId { get; set; }
    }
}