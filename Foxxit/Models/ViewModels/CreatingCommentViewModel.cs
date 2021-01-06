using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class CreatingCommentViewModel
    {
        public CreatingCommentViewModel()
        {
        }

        public CreatingCommentViewModel(long? postId, long? originalCommentId, User user)
        {
            PostId = postId;
            OriginalCommentId = originalCommentId;
            CurrentUser = user;
        }

        public long? PostId { get; set; }

        public long? OriginalCommentId { get; set; }
        public User CurrentUser { get; set; }
    }
}