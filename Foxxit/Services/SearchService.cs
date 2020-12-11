﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;
using Foxxit.Repositories;

namespace Foxxit.Services
{
    public class SearchService
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

        public dynamic Search(string category, string keyword)
        {
            var result = new SearchReturnType();

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

                default:
                    result = new SearchReturnType(SearchInPosts(keyword), SearchInSubReddits(keyword), SearchInComments(keyword));
                    break;
            }

            return result;
        }

        public List<Post> SearchInPosts(string keyword)
        {
            return PostRepository.Filter(p => p.Title.Contains(keyword) || p.Text.Contains(keyword)).Result.ToList();
        }

        public List<SubReddit> SearchInSubReddits(string keyword)
        {
            return SubRedditRepository.Filter(s => s.Name.Contains(keyword) || s.About.Contains(keyword)).Result.ToList();
        }

        public List<Comment> SearchInComments(string keyword)
        {
            return CommentRepository.Filter(c => c.Text.Contains(keyword)).Result.ToList();
        }
    }
}