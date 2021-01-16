using System;

namespace Foxxit.Models.Entities
{
    public class Post : PostBase
    {
        public Post()
        {
        }

        public Post(string title, string text, string url, string imageUrl, SubReddit subReddit, User user)
        {
            Title = title;
            Text = text;
            URL = url;
            ImageURL = imageUrl;
            SubReddit = subReddit;
            User = user;
        }

        public Post(string title, string text, string url, SubReddit subReddit, User user)
        {
            Title = title;
            Text = text;
            URL = url;
            SubReddit = subReddit;
            User = user;
        }

        public string Title { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public SubReddit SubReddit { get; set; }
        public long SubRedditId { get; set; }
    }
}