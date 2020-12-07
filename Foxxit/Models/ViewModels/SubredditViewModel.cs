using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class SubredditViewModel
    {
        public SubReddit Subreddit { get; set; }
        public User User { get; set; }
    }
}
