﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                case "post":
                    result.Posts = SearchInPosts(keyword);
                    break;

                case "subReddit":
                    result.SubReddits = SearchInSubReddits(keyword);
                    break;

                case "comment":
                    result.Comments = SearchInComments(keyword);
                    break;

                case "all":
                    result = new SearchReturnModel(SearchInPosts(keyword), SearchInSubReddits(keyword), SearchInComments(keyword), category);
                    break;
            }

            return result;
        }

        public List<Post> SearchInPosts(string keyword)
        {
            return PostRepository.Filter(p => p.Title.Contains(keyword) || p.Text.Contains(keyword)).ToList();
        }

        public List<SubReddit> SearchInSubReddits(string keyword)
        {
            return SubRedditRepository.Filter(s => s.Name.Contains(keyword) || s.About.Contains(keyword)).ToList();
        }

        public List<Comment> SearchInComments(string keyword)
        {
            return CommentRepository.Filter(c => c.Text.Contains(keyword)).ToList();
        }
    }
}