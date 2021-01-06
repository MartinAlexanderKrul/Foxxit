using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.DTO;
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

        public MainPageViewModel(User currentUser, List<Post> posts, List<SubReddit> subReddits, SearchReturnModel searchReturnModel)
        {
            CurrentUser = currentUser;
            Posts = posts;
            SubReddits = subReddits;
            SearchReturnModel = searchReturnModel;
        }

        public User CurrentUser { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<SubReddit> SubReddits { get; set; }
        public SearchReturnModel SearchReturnModel { get; set; }
        public SubReddit SubReddit { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}