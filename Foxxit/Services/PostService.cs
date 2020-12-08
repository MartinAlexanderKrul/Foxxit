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

        public async Task<Post> GetByIdAsync(long id)
        {
            return await PostRepository.GetByIdAsync(id);
        }

        public void Add(Post obj)
        {
            PostRepository.AddAsync(obj);
        }

        public void Update(Post obj)
        {
            PostRepository.Update(obj);
        }

        public void Delete(Post obj)
        {
            PostRepository.Delete(obj);
        }

        public void Save()
        {
            PostRepository.SaveAsync();
        }
    }
}