using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            Posts = new List<Post>();
            SubReddits = new List<SubReddit>();
        }

        public MainPageViewModel(User actualUser, List<Post> posts, List<SubReddit> subReddits)
        {
            ActualUser = actualUser;
            Posts = posts;
            SubReddits = subReddits;
        }

        public User ActualUser { get; set; }

        public List<Post> Posts { get; set; }
        public List<SubReddit> SubReddits { get; set; }
    }
}