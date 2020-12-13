using System.Collections.Generic;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;

namespace Foxxit.Services
{
    public interface ISearchService
    {
        public SearchReturnModel Search(string category, string keyword);

        public List<Post> SearchInPosts(string keyword);

        public List<SubReddit> SearchInSubReddits(string keyword);

        public List<Comment> SearchInComments(string keyword);
    }
}