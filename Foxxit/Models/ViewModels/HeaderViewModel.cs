using System.Collections.Generic;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class HeaderViewModel
    {
        public User CurrentUser { get; set; }
        public IEnumerable<SubReddit> SubReddits { get; set; }
    }
}
