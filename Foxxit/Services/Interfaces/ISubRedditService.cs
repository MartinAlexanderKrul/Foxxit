using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Services
{
    public interface ISubRedditService
    {
        void Add(SubReddit obj);

        void Delete(SubReddit obj);

        Task<IEnumerable<SubReddit>> GetAllAsync();

        Task<SubReddit> GetByIdAsync(long id);

        void Save();

        void Update(SubReddit obj);
    }
}