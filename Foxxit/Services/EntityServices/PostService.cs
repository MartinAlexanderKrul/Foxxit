using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;

namespace Foxxit.Services
{
    public class PostService : IPostService
    {
        public PostService(PostRepository postRepository)
        {
            PostRepository = postRepository;
        }

        public PostRepository PostRepository { get; private set; }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await PostRepository.GetAllAsync();
        }

        public IEnumerable<Post> Filter(Func<Post, bool> condition)
        {
            return PostRepository.Filter(condition);
        }

        public async Task<Post> GetByIdAsync(long id)
        {
            return await PostRepository.GetByIdAsync(id);
        }

        public void Add(Post entity)
        {
            PostRepository.AddAsync(entity);
        }

        public void Update(Post entity)
        {
            PostRepository.Update(entity);
        }

        public void Delete(Post entity)
        {
            PostRepository.Delete(entity);
        }

        public void Save()
        {
            PostRepository.SaveAsync();
        }
    }
}