using System.Collections.Generic;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {
        }

        public PostViewModel(User currentUser, bool shouldLoadComments)
        {
            CurrentUser = currentUser;
            ShouldLoadComments = shouldLoadComments;
        }

        public PostViewModel(User currentUser, Post post, bool shouldLoadComments)
        {
            CurrentUser = currentUser;
            Post = post;
            ShouldLoadComments = shouldLoadComments;
        }

        public User CurrentUser { get; set; }
        public Post Post { get; set; }
        public bool ShouldLoadComments { get; set; }

        public bool ShouldShowButton
        {
            get { return !ShouldLoadComments; }
        }

        public VoteViewModel VoteViewModel { get; set; }
    }
}