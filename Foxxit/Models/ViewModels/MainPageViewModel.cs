using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Enums;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            Posts = null;
            SubReddits = new List<SubReddit>();
        }

        public MainPageViewModel(User currentUser, PaginatedList<Post> posts, List<SubReddit> subReddits, SearchReturnModel searchReturnModel)
        {
            CurrentUser = currentUser;
            Posts = posts;
            SubReddits = subReddits;
            SearchReturnModel = searchReturnModel;
        }

        public User CurrentUser { get; set; }
        public SubReddit CurrentSubReddit { get; set; }
        public PostViewModel PostViewModel { get; set; }
        public PaginatedList<Post> Posts { get; set; }
        public IEnumerable<SubReddit> SubReddits { get; set; }
        public SearchReturnModel SearchReturnModel { get; set; }
        public PasswordChangeViewModel PasswordChangeViewModel { get; set; }
        public UsernameChangeViewModel UsernameChangeViewModel { get; set; }
    }
}