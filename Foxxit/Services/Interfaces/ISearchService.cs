using System.Collections.Generic;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;

namespace Foxxit.Services
{
    public interface ISearchService
    {
        public SearchReturnModel Search(string category, string keyword);

        public IEnumerable<Post> SearchInPosts(string keyword);

        public IEnumerable<SubReddit> SearchInSubReddits(string keyword);

        public IEnumerable<Comment> SearchInComments(string keyword);
    }
}