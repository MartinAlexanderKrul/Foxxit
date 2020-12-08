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

        Task<Post> GetByIdAsync(long id);

        void Save();

        void Update(Post entity);
    }
}