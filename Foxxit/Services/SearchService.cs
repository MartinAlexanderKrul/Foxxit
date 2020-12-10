using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;

namespace Foxxit.Services
{
    public class SearchService
    {
        public SearchService(PostRepository postRepository, SubRedditRepository subRedditRepository)
        {
            PostRepository = postRepository;
            SubRedditRepository = subRedditRepository;
        }

        public PostRepository PostRepository { get; set; }
        public SubRedditRepository SubRedditRepository { get; set; }

        public void Search(string category, string keyword)
        {
            switch (category)
            {
                case "post":
                    SearchInPosts(keyword);
                    break;

                case "subReddit":
                    SearchInSubReddits(keyword);
                    break;
            }
        }

        public List<Post> SearchInPosts(string keyword)
        {
            return PostRepository.Filter(p => p.Title.Contains(keyword) || p.Text.Contains(keyword)).Result.ToList();
        }

        public List<SubReddit> SearchInSubReddits(string keyword)
        {
            return SubRedditRepository.Filter(s => s.Name.Contains(keyword) || s.About.Contains(keyword)).Result.ToList();
        }
    }
}