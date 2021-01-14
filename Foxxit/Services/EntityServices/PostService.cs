using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public class PostService : GenericEntityService<Post>, IPostService
    {
        public PostService(PostRepository repository)
            : base(repository)
        {
            PostRepository = repository;
        }

        public PostRepository PostRepository { get; private set; }

        public async Task<IEnumerable<Post>> GetAllIncludeCommentsAndUserAsync()
        {
            return await PostRepository.GetAllIncludeCommentsAndUserAsync();
        }

        public async Task<Post> GetByIdIncludeCommentsAndUserAsync(long id)
        {
            return await PostRepository.GetByIdIncludeCommentsAndUserAsync(id);
        }
    }
}