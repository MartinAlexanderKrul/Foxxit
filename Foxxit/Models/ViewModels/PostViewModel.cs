using System.Collections.Generic;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public User CurrentUser { get; set; }
    }
}