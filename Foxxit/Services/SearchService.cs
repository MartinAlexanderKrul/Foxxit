using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Enums;
using Foxxit.Extensions;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;
using Foxxit.Repositories;

namespace Foxxit.Services
{
    public class SearchService : ISearchService
    {
        public SearchService(PostRepository postRepository, SubRedditRepository subRedditRepository, CommentRepository commentRepository)
        {
            PostRepository = postRepository;
            SubRedditRepository = subRedditRepository;
            CommentRepository = commentRepository;
        }

        public PostRepository PostRepository { get; private set; }
        public SubRedditRepository SubRedditRepository { get; private set; }
        public CommentRepository CommentRepository { get; private set; }

        public SearchReturnModel Search(string category, string keyword)
        {
            var result = new SearchReturnModel() { SearchedCategory = category };

            switch (category)
            {
                case nameof(SearchCategory.Post):
                    result.Posts = SearchInPosts(keyword);
                    break;

                case nameof(SearchCategory.SubReddit):
                    result.SubReddits = SearchInSubReddits(keyword);
                    break;

                case nameof(SearchCategory.Comment):
                    result.Comments = SearchInComments(keyword);
                    break;

                case nameof(SearchCategory.All):
                    result = new SearchReturnModel(SearchInPosts(keyword), SearchInSubReddits(keyword), SearchInComments(keyword), category);
                    break;
            }

            return result;
        }

        public IEnumerable<Post> SearchInPosts(string keyword)
        {
            return PostRepository.Filter(p => p.Title.ContainsCaseInsensitive(keyword) || p.Text.ContainsCaseInsensitive(keyword));
        }

        public IEnumerable<SubReddit> SearchInSubReddits(string keyword)
        {
            return SubRedditRepository.Filter(s => s.Name.ContainsCaseInsensitive(keyword) || s.About.ContainsCaseInsensitive(keyword));
        }

        public IEnumerable<Comment> SearchInComments(string keyword)
        {
            return CommentRepository.Filter(c => c.Text.ContainsCaseInsensitive(keyword));
        }
    }
}