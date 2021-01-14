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

        public MainPageViewModel(User currentUser, List<Post> posts, List<SubReddit> subReddits, SearchReturnModel searchReturnModel, PostViewModel postViewModel)
        {
            CurrentUser = currentUser;
            Posts = posts;
            SubReddits = subReddits;
            SearchReturnModel = searchReturnModel;
            PostViewModel = postViewModel;

        }

        public PostViewModel PostViewModel { get; set; }
        public User CurrentUser { get; set; }
        public SubReddit CurrentSubReddit { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<SubReddit> SubReddits { get; set; }
        public SearchReturnModel SearchReturnModel { get; set; }
    }
}