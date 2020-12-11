using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Models.DTO
{
    public class SearchReturnType
    {
        public SearchReturnType(IEnumerable<Post> posts, IEnumerable<SubReddit> subReddits, IEnumerable<Comment> comments)
        {
            Posts = posts;
            SubReddits = subReddits;
            Comments = comments;
        }

        public SearchReturnType()
        {
        }

        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<SubReddit> SubReddits { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}