using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Services
{
    public interface IPostService
    {
        void Add(Post entity);

        void Delete(Post entity);

        Task<IEnumerable<Post>> GetAllAsync();

        IEnumerable<Post> Filter(Func<Post, bool> condition);

        Task<Post> GetByIdAsync(long id);

        void Save();

        void Update(Post entity);
    }
}