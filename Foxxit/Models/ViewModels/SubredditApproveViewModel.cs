using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class SubredditApproveViewModel
    {
        public SubredditApproveViewModel()
        {
            SubReddits = new List<SubReddit>();
        }

        public SubredditApproveViewModel(User currentUser, List<SubReddit> subReddits)
        {
            CurrentUser = currentUser;
            SubReddits = subReddits;
        }

        public User CurrentUser { get; set; }
        public IEnumerable<SubReddit> SubReddits { get; set; }
    }
}
