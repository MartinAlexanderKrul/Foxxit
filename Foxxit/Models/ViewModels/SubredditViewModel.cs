using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class SubRedditViewModel
    {
        public SubRedditViewModel()
        {
        }

        [Required]
        [StringLength(50, ErrorMessage = "Name must be between 3 and 50 characters!", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "About must be between 3 and 100 characters!", MinimumLength = 3)]
        public string About { get; set; }

        public string DisplayName { get; set; }
        public string AvatarUrl { get; set; }
        public SubReddit SubReddit { get; set; }
        public User User { get; set; }
        public IEnumerable<SubReddit> SubReddits { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}
